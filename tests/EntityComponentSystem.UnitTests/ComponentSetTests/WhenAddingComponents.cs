using FluentAssertions;
using Xunit;

namespace VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests;

public sealed class WhenAddingComponents
{
    [Fact]
    public void MustAssociateValueWithId()
    {
        var componentSet = new ComponentSet<char>();

        componentSet.Add(0, 'A');
        componentSet.Add(1, 'B');
        componentSet.Add(2, 'C');

        for (var i = 0; i < componentSet.Count; i++)
        {
            var component = componentSet[i];

            _ = component.Should().Be((char)('A' + i));
        }
    }

    [Fact]
    public void MustAdjustCount()
    {
        var componentSet = new ComponentSet<char>();

        componentSet.Add(0, 'A');
        componentSet.Add(1, 'B');
        componentSet.Add(2, 'C');

        _ = componentSet.Count.Should().Be(3);
    }
}
