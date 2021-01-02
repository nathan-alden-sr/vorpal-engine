using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenPerformingBitwiseNot
    {
        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void MustSetBitsAccordingToXorTruthTable(bool bit, bool expectedResult)
        {
            BitArray1024 bitArray;

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i] = bit;
            }

            bitArray.Not();

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().Be(expectedResult);
            }
        }
    }
}