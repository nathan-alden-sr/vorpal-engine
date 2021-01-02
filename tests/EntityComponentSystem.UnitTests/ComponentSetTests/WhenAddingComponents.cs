using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests
{
    public class WhenAddingComponents
    {
        [Fact]
        public void MustAssociateValueWithId()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            for (var i = 0; i < componentSet.Count; i++)
            {
                componentSet[i].Should().Be((i, (char)('A' + i)));
            }
        }

        [Fact]
        public void MustAdjustCount()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            componentSet.Count.Should().Be(3);
        }
    }
}