using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenTrimmingExcessCapacityWithItemsPresent
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 1, 2)]
        [InlineData(5, 2, 4)]
        public void MustSetCapacityToNearestPowerOfTwo(int itemsToAdd, int itemsToRemove, int expectedCapacity)
        {
            ListEx<int> list = new();

            list.AddRange(itemsToAdd);

            for (var i = 0; i < itemsToRemove; i++)
            {
                list.RemoveAt(0);
            }

            list.TrimExcess();

            list.Capacity.Should().Be(expectedCapacity);
        }
    }
}