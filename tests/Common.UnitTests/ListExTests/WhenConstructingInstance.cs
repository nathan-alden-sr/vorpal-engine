using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenConstructingInstance
    {
        [Fact]
        public void MustSetCapacity()
        {
            const int expected = 8;
            ListEx<int> list = new(expected);

            list.Capacity.Should().Be(expected);
        }

        [Fact]
        public void MustNotTreatCapacityAsCount()
        {
            ListEx<int> list = new(8);

            list.Count.Should().Be(0);
        }
    }
}