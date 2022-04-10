using FluentAssertions;
using Xunit;

namespace VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests;

public sealed class WhenRemovingComponents
{
    [Fact]
    public void MustAdjustCount()
    {
        var componentSet = new ComponentSet<char>();

        componentSet.Add(0, 'A');
        componentSet.Add(1, 'B');
        componentSet.Add(2, 'C');

        _ = componentSet.Remove(1);

        _ = componentSet.Count.Should().Be(2);
    }

    [Fact]
    public void MustRemoveId()
    {
        var componentSet = new ComponentSet<char>();

        componentSet.Add(0, 'A');
        componentSet.Add(1, 'B');
        componentSet.Add(2, 'C');

        _ = componentSet.Remove(1).Should().BeTrue();

        _ = componentSet.Contains(1).Should().BeFalse();
    }
}
