using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenConstructingInstance
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void MustHaveAllBitsSetToPreferredValue(bool defaultValue)
        {
            BitArray1024 bitArray = new(defaultValue);

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().Be(defaultValue);
            }
        }

        [Fact]
        public void MustCopyBitArray()
        {
            BitArray1024 bitArray;

            for (var i = 0; i < bitArray.LengthInBits; i += 2)
            {
                bitArray[i] = true;
            }

            BitArray1024 bitArrayCopy = bitArray;

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().Be(bitArrayCopy[i]);
            }
        }
    }
}