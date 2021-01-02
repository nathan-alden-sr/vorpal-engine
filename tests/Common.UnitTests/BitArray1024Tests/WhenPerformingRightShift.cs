using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenPerformingRightShift
    {
        [Theory]
        [InlineData(0b10000000, 3)]
        public void MustShiftBitsRight(byte value, int shift)
        {
            BitArray1024 bitArray;

            for (var j = 0; j < bitArray.LengthInBits; j += 8)
            for (var k = 0; k < sizeof(byte) * 8; k++)
            {
                bool bit = ((value >> k) & 1) == 1;

                bitArray[j + k] = bit;
            }

            bitArray.RightShift(shift);

            value >>= shift;

            for (var j = 0; j < bitArray.LengthInBits; j += 8)
            for (var k = 0; k < sizeof(byte) * 8; k++)
            {
                bool expected = ((value >> k) & 1) == 1;

                bitArray[j + k].Should().Be(expected);
            }
        }
    }
}