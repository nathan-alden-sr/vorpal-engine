using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenAddingItems
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 4)]
        [InlineData(5, 8)]
        [InlineData(9, 16)]
        public void MustGrowCapacityByPowersOfTwo(int itemsToAdd, int expectedCapacity)
        {
            ListEx<int> list = new();

            list.Capacity.Should().Be(0);

            list.AddRange(itemsToAdd);

            list.Capacity.Should().Be(expectedCapacity);
        }

        [Fact]
        public void MustAddToEndOfList()
        {
            ListEx<int> list = new();

            for (var i = 0; i < 3; i++)
            {
                list.Add(i);
                list[^1].Should().Be(i);
            }
        }

        [Fact]
        public void MustAdjustCount()
        {
            ListEx<int> list = new();

            list.AddRange(3);

            list.Count.Should().Be(3);
        }
    }
}