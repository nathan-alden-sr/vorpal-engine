using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenTestingEquality
    {
        [Fact]
        public void Must()
        {
            BitArray1024 bitArray1;
            BitArray1024 bitArray2;

            for (var i = 0; i < bitArray1.LengthInBits; i += 4)
            {
                bitArray1[i] = true;
                bitArray2[i] = true;
            }

            bitArray1.Equals(in bitArray2).Should().BeTrue();
        }
    }
}