using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>A struct-based bit array of exactly 1024 bits.</summary>
    /// <remarks>
    ///     Inspired by
    ///     <a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.bitarray?view=net-5.0">System.Collections.BitArray</a>
    ///     .
    /// </remarks>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public unsafe struct BitArray1024
    {
        private const int SizeInBits = 1024;
        private const int SizeInBytes = SizeInBits / 8;

        // ReSharper disable once InconsistentNaming
        private const int SizeInInt32s = SizeInBytes / BytesPerInt32;
        private const int BitsPerInt32 = BytesPerInt32 * 8;
        private const int BytesPerInt32 = sizeof(int);
        private const uint Vector128ByteCount = 128 / 8;
        private const uint Vector128IntCount = Vector128ByteCount / BytesPerInt32;
        private const uint Vector256ByteCount = 256 / 8;
        private const uint Vector256IntCount = Vector256ByteCount / BytesPerInt32;
        private const int BitShiftPerInt32 = 5;
#pragma warning disable 649
        private fixed int _data[SizeInInt32s];
#pragma warning restore 649

        /// <summary>Initializes a new instance of the <see cref="BitArray1024" /> struct.</summary>
        /// <param name="defaultValue">The default value of each bit.</param>
        public BitArray1024(bool defaultValue)
        {
            if (defaultValue)
            {
                SetAll(true);
            }
        }

        /// <summary>Gets the length of the bit array in bits.</summary>
        [SuppressMessage("Performance", "CA1822:Mark members as static")]
        public readonly int LengthInBits => SizeInBits;

        /// <summary>Gets the length of the bit array in bytes.</summary>
        [SuppressMessage("Performance", "CA1822:Mark members as static")]
        public readonly int LengthInBytes => SizeInBytes;

        /// <summary>Gets or sets the bit at the specified index.</summary>
        /// <param name="index">The index of the bit.</param>
        /// <returns>The bit at the specified index.</returns>
        public bool this[int index]
        {
            readonly get => Get(index);
            set => Set(index, value);
        }

        private readonly string DebuggerDisplay
        {
            get
            {
                var stringBuilder = new StringBuilder();

                for (var i = 0; i < SizeInInt32s; i++)
                {
                    stringBuilder.Append(Convert.ToString(ReverseBits(_data[i]), 2).PadLeft(32, '0'));
                }

                return stringBuilder.ToString();
            }
        }

        /// <summary>Gets the bit at the specified index.</summary>
        /// <param name="index">The index of the bit.</param>
        /// <returns>The bit at the specified index.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Get(int index)
        {
            if ((uint)index >= SizeInBits)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(index), index);
            }

            return (_data[index >> 5] & (1 << index)) != 0;
        }

        /// <summary>Sets the bit at the specified index.</summary>
        /// <param name="index">The index of the bit.</param>
        /// <param name="value">The new value of the bit.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(int index, bool value)
        {
            if ((uint)index >= SizeInBits)
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(index), index);
            }

            int bitMask = 1 << index;
            ref int segment = ref _data[index >> 5];

            if (value)
            {
                segment |= bitMask;
            }
            else
            {
                segment &= ~bitMask;
            }
        }

        /// <summary>Sets all bits to the specified value.</summary>
        /// <param name="value">The new value for all bits.</param>
        public void SetAll(bool value) => Unsafe.InitBlock(ref Unsafe.As<int, byte>(ref _data[0]), value ? 0b11111111 : 0, SizeInBytes);

        /// <summary>Performs a bitwise AND between this instance and <paramref name="bitArray" />, mutating this instance.</summary>
        /// <param name="bitArray">The bit array to AND with this instance.</param>
        public void And(in BitArray1024 bitArray)
        {
            // This method uses unsafe code to manipulate data in the BitArrays.  To avoid issues with
            // buggy code concurrently mutating these instances in a way that could cause memory corruption,
            // we snapshot the arrays from both and then operate only on those snapshots, while also validating
            // that the count we iterate to is within the bounds of both arrays.  We don't care about such code
            // corrupting the BitArray data in a way that produces incorrect answers, since BitArray is not meant
            // to be thread-safe; we only care about avoiding buffer overruns.

            uint i = 0;

            if (Avx2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector256IntCount - 1u); i += Vector256IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector256<int> leftVector = Unsafe.As<int, Vector256<int>>(ref leftData);
                    Vector256<int> rightVector = Unsafe.As<int, Vector256<int>>(ref rightData);

                    Unsafe.As<int, Vector256<int>>(ref _data[i]) = Avx2.And(leftVector, rightVector);
                }
            }
            else if (Sse2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = Sse2.And(leftVector, rightVector);
                }
            }
            else if (AdvSimd.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = AdvSimd.And(leftVector, rightVector);
                }
            }

            for (; i < SizeInInt32s; i++)
            {
                _data[i] &= bitArray._data[i];
            }
        }

        /// <summary>Performs a bitwise OR between this instance and <paramref name="bitArray" />, mutating this instance.</summary>
        /// <param name="bitArray">The bit array to OR with this instance.</param>
        public void Or(in BitArray1024 bitArray)
        {
            // This method uses unsafe code to manipulate data in the BitArrays.  To avoid issues with
            // buggy code concurrently mutating these instances in a way that could cause memory corruption,
            // we snapshot the arrays from both and then operate only on those snapshots, while also validating
            // that the count we iterate to is within the bounds of both arrays.  We don't care about such code
            // corrupting the BitArray data in a way that produces incorrect answers, since BitArray is not meant
            // to be thread-safe; we only care about avoiding buffer overruns.

            uint i = 0;

            if (Avx2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector256IntCount - 1u); i += Vector256IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector256<int> leftVector = Unsafe.As<int, Vector256<int>>(ref leftData);
                    Vector256<int> rightVector = Unsafe.As<int, Vector256<int>>(ref rightData);

                    Unsafe.As<int, Vector256<int>>(ref _data[i]) = Avx2.Or(leftVector, rightVector);
                }
            }
            else if (Sse2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = Sse2.Or(leftVector, rightVector);
                }
            }
            else if (AdvSimd.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = AdvSimd.Or(leftVector, rightVector);
                }
            }

            for (; i < SizeInInt32s; i++)
            {
                _data[i] |= bitArray._data[i];
            }
        }

        /// <summary>Performs a bitwise XOR between this instance and <paramref name="bitArray" />, mutating this instance.</summary>
        /// <param name="bitArray">The bit array to XOR with this instance.</param>
        public void Xor(in BitArray1024 bitArray)
        {
            // This method uses unsafe code to manipulate data in the BitArrays.  To avoid issues with
            // buggy code concurrently mutating these instances in a way that could cause memory corruption,
            // we snapshot the arrays from both and then operate only on those snapshots, while also validating
            // that the count we iterate to is within the bounds of both arrays.  We don't care about such code
            // corrupting the BitArray data in a way that produces incorrect answers, since BitArray is not meant
            // to be thread-safe; we only care about avoiding buffer overruns.

            uint i = 0;

            if (Avx2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector256IntCount - 1u); i += Vector256IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector256<int> leftVector = Unsafe.As<int, Vector256<int>>(ref leftData);
                    Vector256<int> rightVector = Unsafe.As<int, Vector256<int>>(ref rightData);

                    Unsafe.As<int, Vector256<int>>(ref _data[i]) = Avx2.Xor(leftVector, rightVector);
                }
            }
            else if (Sse2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = Sse2.Xor(leftVector, rightVector);
                }
            }
            else if (AdvSimd.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref _data[i];
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = AdvSimd.Xor(leftVector, rightVector);
                }
            }

            for (; i < SizeInInt32s; i++)
            {
                _data[i] ^= bitArray._data[i];
            }
        }

        /// <summary>Performs a bitwise NOT, mutating this instance.</summary>
        public void Not()
        {
            // This method uses unsafe code to manipulate data in the BitArray.  To avoid issues with
            // buggy code concurrently mutating this instance in a way that could cause memory corruption,
            // we snapshot the array then operate only on this snapshot.  We don't care about such code
            // corrupting the BitArray data in a way that produces incorrect answers, since BitArray is not meant
            // to be thread-safe; we only care about avoiding buffer overruns.

            uint i = 0;

            if (Avx2.IsSupported)
            {
                Vector256<int> ones = Vector256.Create(-1);

                for (; i < SizeInInt32s - (Vector256IntCount - 1u); i += Vector256IntCount)
                {
                    Vector256<int> vector = Unsafe.As<int, Vector256<int>>(ref _data[i]);

                    Unsafe.As<int, Vector256<int>>(ref _data[i]) = Avx2.Xor(vector, ones);
                }
            }
            else if (Sse2.IsSupported)
            {
                Vector128<int> ones = Vector128.Create(-1);

                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    Vector128<int> vector = Unsafe.As<int, Vector128<int>>(ref _data[i]);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = Sse2.Xor(vector, ones);
                }
            }
            else if (AdvSimd.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    Vector128<int> vector = Unsafe.As<int, Vector128<int>>(ref _data[i]);

                    Unsafe.As<int, Vector128<int>>(ref _data[i]) = AdvSimd.Not(vector);
                }
            }

            for (; i < SizeInInt32s; i++)
            {
                _data[i] = ~_data[i];
            }
        }

        /// <summary>Performs a left shift, mutating this instance.</summary>
        /// <param name="count">The number of bits to shift left by.</param>
        public void LeftShift(int count)
        {
            if (count <= 0)
            {
                if (count < 0)
                {
                    ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(count), count);
                }
            }

            int lengthToClear;

            if (count < SizeInBits)
            {
                int lastIndex = (SizeInBits - 1) >> BitShiftPerInt32; // Divide by 32.

                lengthToClear = Math.DivRem(count, 32, out int shiftCount);

                if (shiftCount == 0)
                {
                    Span<int> sourceSpan = MemoryMarshal.CreateSpan(ref _data[0], SizeInInt32s - lengthToClear);
                    Span<int> destinationSpan = MemoryMarshal.CreateSpan(ref _data[lengthToClear], lastIndex + 1 - lengthToClear);

                    sourceSpan.CopyTo(destinationSpan);
                }
                else
                {
                    int fromindex = lastIndex - lengthToClear;

                    unchecked
                    {
                        while (fromindex > 0)
                        {
                            int left = _data[fromindex] << shiftCount;
                            uint right = (uint)_data[--fromindex] >> (BitsPerInt32 - shiftCount);

                            _data[lastIndex] = left | (int)right;
                            lastIndex--;
                        }

                        _data[lastIndex] = _data[fromindex] << shiftCount;
                    }
                }
            }
            else
            {
                lengthToClear = SizeInInt32s; // Clear all
            }

            MemoryMarshal.CreateSpan(ref _data[0], lengthToClear).Clear();
        }

        /// <summary>Performs a right shift, mutating this instance.</summary>
        /// <param name="count">The number of bits to shift right by.</param>
        public void RightShift(int count)
        {
            if (count <= 0)
            {
                if (count < 0)
                {
                    ExceptionHelper.ThrowArgumentOutOfRangeException(nameof(count), count);
                }
            }

            var toIndex = 0;

            if (count < SizeInBits)
            {
                int fromIndex = Math.DivRem(count, 32, out int shiftCount);

                _ = Math.DivRem(SizeInBits, 32, out int extraBits);

                if (shiftCount == 0)
                {
                    unchecked
                    {
                        // Cannot use `(1u << extraBits) - 1u` as the mask
                        // because for extraBits == 0, we need the mask to be 111...111, not 0.
                        // In that case, we are shifting a uint by 32, which could be considered undefined.
                        // The result of a shift operation is undefined ... if the right operand
                        // is greater than or equal to the width in bits of the promoted left operand,
                        // https://docs.microsoft.com/en-us/cpp/c-language/bitwise-shift-operators?view=vs-2017
                        // However, the compiler protects us from undefined behaviour by constraining the
                        // right operand to between 0 and width - 1 (inclusive), i.e. right_operand = (right_operand % width).

                        uint mask = uint.MaxValue >> (BitsPerInt32 - extraBits);

                        _data[SizeInInt32s - 1] &= (int)mask;
                    }

                    Span<int> sourceSpan = MemoryMarshal.CreateSpan(ref _data[fromIndex], SizeInInt32s - fromIndex);
                    Span<int> destinationSpan = MemoryMarshal.CreateSpan(ref _data[0], SizeInBytes);

                    sourceSpan.CopyTo(destinationSpan);

                    toIndex = SizeInInt32s - fromIndex;
                }
                else
                {
                    const int lastIndex = SizeInInt32s - 1;

                    unchecked
                    {
                        while (fromIndex < lastIndex)
                        {
                            uint right = (uint)_data[fromIndex] >> shiftCount;
                            int left = _data[++fromIndex] << (BitsPerInt32 - shiftCount);

                            _data[toIndex++] = left | (int)right;
                        }

                        uint mask = uint.MaxValue >> (BitsPerInt32 - extraBits);

                        mask &= (uint)_data[fromIndex];
                        _data[toIndex++] = (int)(mask >> shiftCount);
                    }
                }
            }

            MemoryMarshal.CreateSpan(ref _data[toIndex], SizeInInt32s - toIndex).Clear();
        }

        /// <summary>
        ///     Determines if <see langword="true" /> bits in this instance match <see langword="true" /> bits in the specified bit
        ///     array.
        /// </summary>
        /// <param name="bitArray">The bit array to compare to.</param>
        /// <returns>
        ///     <see langword="true" /> if <see langword="true" /> bits in this instance match <see langword="true" /> bits in the
        ///     specified bit array; otherwise, <see langword="false" />.
        /// </returns>
        public readonly bool IsSubsetOf(in BitArray1024 bitArray)
        {
            uint i = 0;

            if (Avx2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector256IntCount - 1u); i += Vector256IntCount)
                {
                    ref int leftData = ref Unsafe.AsRef(in _data[i]);
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector256<int> leftVector = Unsafe.As<int, Vector256<int>>(ref leftData);
                    Vector256<int> rightVector = Unsafe.As<int, Vector256<int>>(ref rightData);

                    if (!Avx2.And(leftVector, rightVector).Equals(leftVector))
                    {
                        return false;
                    }
                }
            }
            else if (Sse2.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref Unsafe.AsRef(in _data[i]);
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    if (!Sse2.And(leftVector, rightVector).Equals(leftVector))
                    {
                        return false;
                    }
                }
            }
            else if (AdvSimd.IsSupported)
            {
                for (; i < SizeInInt32s - (Vector128IntCount - 1u); i += Vector128IntCount)
                {
                    ref int leftData = ref Unsafe.AsRef(in _data[i]);
                    ref int rightData = ref Unsafe.AsRef(in bitArray._data[i]);

                    Vector128<int> leftVector = Unsafe.As<int, Vector128<int>>(ref leftData);
                    Vector128<int> rightVector = Unsafe.As<int, Vector128<int>>(ref rightData);

                    if (!AdvSimd.And(leftVector, rightVector).Equals(leftVector))
                    {
                        return false;
                    }
                }
            }

            for (; i < SizeInInt32s; i++)
            {
                if ((_data[i] & bitArray._data[i]) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj) => obj is BitArray1024 other && Equals(in other);

        /// <summary>Determines if the bits in two bit arrays are the same.</summary>
        /// <param name="bitArray">The bit array to compare this instance to.</param>
        /// <returns><see langword="true" /> if the bits in the two bit arrays are the same; otherwise, <see langword="false" />.</returns>
        public readonly bool Equals(in BitArray1024 bitArray) => this == bitArray;

        /// <inheritdoc />
        public override readonly int GetHashCode()
        {
            ExceptionHelper.ThrowNotSupportedException();
            return default;
        }

        /// <inheritdoc />
        public override readonly string ToString() => DebuggerDisplay;

        /// <summary>Determines if the bits in two bit arrays are the same.</summary>
        /// <param name="left">The left bit array.</param>
        /// <param name="right">The right bit array.</param>
        /// <returns><see langword="true" /> if the bits in the two bit arrays are the same; otherwise, <see langword="false" />.</returns>
        public static bool operator ==(in BitArray1024 left, in BitArray1024 right)
        {
            Span<int> leftSpan = MemoryMarshal.CreateSpan(ref Unsafe.AsRef(left._data[0]), SizeInInt32s);
            Span<int> rightSpan = MemoryMarshal.CreateSpan(ref Unsafe.AsRef(right._data[0]), SizeInInt32s);

            return leftSpan.SequenceEqual(rightSpan);
        }

        /// <summary>Determines if the bits in two bit arrays are not the same.</summary>
        /// <param name="left">The left bit array.</param>
        /// <param name="right">The right bit array.</param>
        /// <returns><see langword="true" /> if the bits in the two bit arrays are not the same; otherwise, <see langword="false" />.</returns>
        public static bool operator !=(in BitArray1024 left, in BitArray1024 right) => !(left == right);

        private static int ReverseBits(int value)
        {
            const int numberOfBits = sizeof(int) * 8;
            var reversedNumber = 0;

            for (var i = 0; i < numberOfBits; i++)
            {
                reversedNumber |= (value & (1 << i)) != 0 ? 1 << (numberOfBits - 1 - i) : 0;
            }

            return reversedNumber;
        }
    }
}