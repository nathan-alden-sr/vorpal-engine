using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenTestingSubsets
    {
        [Fact]
        public void MustReturnTrueIfSubset()
        {
            BitArray1024 bitArray1 = new(true);
            BitArray1024 bitArray2;

            for (var i = 0; i < bitArray1.LengthInBits; i += 2)
            {
                bitArray2.Set(i, true);
            }

            bitArray2.IsSubsetOf(in bitArray1).Should().BeTrue();
        }

        [Fact]
        public void MustReturnFalseIfNotSubset()
        {
            BitArray1024 bitArray1;
            BitArray1024 bitArray2;

            for (var i = 0; i < bitArray1.LengthInBits; i += 2)
            {
                bitArray2.Set(i, true);
            }

            bitArray2.IsSubsetOf(in bitArray1).Should().BeFalse();
        }
    }
}