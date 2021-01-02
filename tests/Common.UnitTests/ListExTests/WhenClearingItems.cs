using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenClearingItems
    {
        [Fact]
        public void MustResetCount()
        {
            ListEx<int> list = new();

            list.AddRange(3);

            list.Count.Should().Be(3);

            list.Clear();

            list.Count.Should().Be(0);
        }
    }
}