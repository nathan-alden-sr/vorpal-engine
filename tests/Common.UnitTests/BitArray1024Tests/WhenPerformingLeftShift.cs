using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenPerformingLeftShift
    {
        [Theory]
        [InlineData(0b00000001, 3)]
        public void MustShiftBitsLeft(byte value, int shift)
        {
            BitArray1024 bitArray;

            for (var j = 0; j < bitArray.LengthInBits; j += 8)
            for (var k = 0; k < sizeof(byte) * 8; k++)
            {
                bool bit = ((value >> k) & 1) == 1;

                bitArray[j + k] = bit;
            }

            bitArray.LeftShift(shift);

            value <<= shift;

            for (var j = 0; j < bitArray.LengthInBits; j += 8)
            for (var k = 0; k < sizeof(byte) * 8; k++)
            {
                bool expected = ((value >> k) & 1) == 1;

                bitArray[j + k].Should().Be(expected);
            }
        }
    }
}