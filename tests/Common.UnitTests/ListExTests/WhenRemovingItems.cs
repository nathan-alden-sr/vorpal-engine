using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenRemovingItems
    {
        [Fact]
        public void MustAdjustCount()
        {
            ListEx<int> list = new();

            list.AddRange(new[] { 1, 2, 3 });
            list.RemoveAt(1);

            list.Count.Should().Be(2);
        }

        [Fact]
        public void MustAdjustItems()
        {
            ListEx<int> list = new();

            list.AddRange(new[] { 1, 2, 3 });
            list.RemoveAt(1);

            list[0].Should().Be(1);
            list[1].Should().Be(3);
        }
    }
}