using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.BitArray1024Tests
{
    public class WhenGettingAndSettingBits
    {
        [Fact]
        public void MustSetBitsToDesiredValue()
        {
            BitArray1024 bitArray;

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().BeFalse();
            }

            for (var i = 0; i < bitArray.LengthInBits; i += 2)
            {
                bitArray[i] = true;
            }

            for (var i = 0; i < bitArray.LengthInBits; i++)
            {
                bitArray[i].Should().Be(i % 2 == 0);
            }
        }
    }
}