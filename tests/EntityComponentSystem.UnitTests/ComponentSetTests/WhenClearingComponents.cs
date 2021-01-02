using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests
{
    public class WhenClearingComponents
    {
        [Fact]
        public void MustRemoveAllIds()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            componentSet.Clear();

            for (var i = 0; i < 3; i++)
            {
                componentSet.Contains(i).Should().BeFalse();
            }

            componentSet.Count.Should().Be(0);
        }
    }
}