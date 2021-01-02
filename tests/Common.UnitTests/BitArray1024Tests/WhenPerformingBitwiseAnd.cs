using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenPerformingBitwiseAnd
    {
        [Theory]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(true, false, false)]
        [InlineData(true, true, true)]
        public void MustSetBitsAccordingToAndTruthTable(bool bit1, bool bit2, bool expectedResult)
        {
            BitArray1024 bitArray1;
            BitArray1024 bitArray2;

            for (var i = 0; i < bitArray1.LengthInBits; i++)
            {
                bitArray1[i] = bit1;
                bitArray2[i] = bit2;
            }

            bitArray1.And(in bitArray2);

            for (var i = 0; i < bitArray1.LengthInBits; i++)
            {
                bitArray1[i].Should().Be(expectedResult);
            }
        }
    }
}