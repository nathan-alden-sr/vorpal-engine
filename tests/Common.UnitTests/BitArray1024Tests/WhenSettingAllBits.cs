using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenSettingAllBits
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void MustSetBitsToDesiredValue(bool value)
        {
            BitArray1024 bitArray;

            bitArray.SetAll(value);

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().Be(value);
            }
        }
    }
}