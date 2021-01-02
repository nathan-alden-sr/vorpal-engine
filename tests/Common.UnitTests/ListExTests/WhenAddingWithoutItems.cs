using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenAddingWithoutItems
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 5)]
        public void MustSetCount(int itemsToAdd, int expectedLength)
        {
            ListEx<int> list = new();

            list.AddRange(itemsToAdd);
            list.Count.Should().Be(expectedLength);
        }
    }
}