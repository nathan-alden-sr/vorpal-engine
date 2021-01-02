using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests
{
    public class WhenRemovingComponents
    {
        [Fact]
        public void MustAdjustCount()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            componentSet.Remove(1);

            componentSet.Count.Should().Be(2);
        }

        [Fact]
        public void MustRemoveId()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            componentSet.Remove(1).Should().BeTrue();

            componentSet.Contains(1).Should().BeFalse();
        }
    }
}