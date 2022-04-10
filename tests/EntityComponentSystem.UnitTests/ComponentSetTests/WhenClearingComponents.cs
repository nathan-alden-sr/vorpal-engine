using FluentAssertions;
using Xunit;

namespace VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests;

public sealed class WhenClearingComponents
{
    [Fact]
    public void MustRemoveAllIds()
    {
        var componentSet = new ComponentSet<char>();

        componentSet.Add(0, 'A');
        componentSet.Add(1, 'B');
        componentSet.Add(2, 'C');

        componentSet.Clear();

        for (var i = 0; i < 3; i++)
        {
            _ = componentSet.Contains(i).Should().BeFalse();
        }

        _ = componentSet.Count.Should().Be(0);
    }
}
