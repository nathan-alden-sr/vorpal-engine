using System.Runtime.CompilerServices;

namespace NathanAldenSr.VorpalEngine.Common
{
    /// <summary>A bitmap consisting of 256 groups of bits, each group consisting of four bits.</summary>
    public unsafe struct Bitmap256GroupsWith4StateBits
    {
        private const int Groups = 256;
        private const int BitsPerGroup = 4;
        private const int BitsPerField = sizeof(uint) * 8;
        private const int Fields = BitsPerGroup * Groups / BitsPerField;
        private const int GroupsPerField = BitsPerField / BitsPerGroup;
        private const int GroupMask = (1 << BitsPerGroup) - 1;
#pragma warning disable 649
        private fixed uint _data[Fields];
#pragma warning restore 649

        /// <summary>Gets a group of bits.</summary>
        /// <param name="groupIndex">The index of the group to retrieve.</param>
        /// <returns>The bits in the group. Bits not in <see cref="GroupMask" /> will be set to zero.</returns>
        public byte Get(byte groupIndex)
        {
            int shift = GetShift(groupIndex);

            return (byte)((_data[GetFieldIndex(groupIndex)] & (GroupMask << shift)) >> shift);
        }

        /// <summary>Sets a group of bits.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="value">A value containing the bits to set. Bits not in <see cref="GroupMask" /> will be discarded.</param>
        public void Set(byte groupIndex, byte value)
        {
            int fieldIndex = GetFieldIndex(groupIndex);
            int shift = GetShift(groupIndex);

            _data[fieldIndex] = (_data[fieldIndex] & ~((uint)GroupMask << shift)) | ((uint)PrepareValue(value) << shift);
        }

        /// <summary>Sets a group of bits by performing a bitwise complement (<c>~</c>) on the current bits.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        public void BitwiseComplement(byte groupIndex) => Set(groupIndex, (byte)(~Get(groupIndex) & GroupMask));

        /// <summary>Sets a group of bits by performing left shift (<c>&lt;&lt;</c>) on the current bits.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="shift">The number of bits to left shift by.</param>
        public void LeftShift(byte groupIndex, int shift) => Set(groupIndex, (byte)((Get(groupIndex) << shift) & GroupMask));

        /// <summary>Sets a group of bits by performing right shift (<c>&gt;&gt;</c>) on the current bits.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="shift">The number of bits to right shift by.</param>
        public void RightShift(byte groupIndex, int shift) => Set(groupIndex, (byte)((Get(groupIndex) >> shift) & GroupMask));

        /// <summary>Sets a group of bits by performing a logical AND (<c>&amp;</c>) with the current bits and <paramref name="value" />.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="value">
        ///     A value containing the bits to logical AND (<c>&amp;</c>) on the current bits. Bits not in
        ///     <see cref="GroupMask" /> will be discarded.
        /// </param>
        public void LogicalAnd(byte groupIndex, byte value) => Set(groupIndex, (byte)(Get(groupIndex) & value));

        /// <summary>Sets a group of bits by performing a logical AND (<c>|</c>) on the current bits and <paramref name="value" />.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="value">
        ///     A value containing the bits to logical OR (<c>|</c>) with the current bits. Bits not in
        ///     <see cref="GroupMask" /> will be discarded.
        /// </param>
        public void LogicalOr(byte groupIndex, byte value) => Set(groupIndex, (byte)(Get(groupIndex) | value));

        /// <summary>Sets a group of bits by performing a logical exclusive OR (<c>^</c>) on the current bits and <paramref name="value" />.</summary>
        /// <param name="groupIndex">The index of the group to set.</param>
        /// <param name="value">
        ///     A value containing the bits to logical exclusive OR (<c>^</c>) on the current bits. Bits not in
        ///     <see cref="GroupMask" /> will be discarded.
        /// </param>
        public void LogicalExclusiveOr(byte groupIndex, byte value) => Set(groupIndex, (byte)(Get(groupIndex) ^ value));

        /// <summary>Resets all bits to zero.</summary>
        public void Reset() => this = default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetFieldIndex(byte groupIndex) => groupIndex * BitsPerGroup / BitsPerField;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetShift(byte groupIndex) => groupIndex % GroupsPerField * BitsPerGroup;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte PrepareValue(byte value) => (byte)(value & GroupMask);
    }
}