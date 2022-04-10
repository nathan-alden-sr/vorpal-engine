using FluentAssertions;
using Xunit;

namespace VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests;

public sealed class WhenGettingAllComponents
{
    [Fact]
    public void MustReturnComponents()
    {
        var componentSet = new ComponentSet<char>();
        var components = new[] { 'A', 'B', 'C' };

        for (var i = 0; i < components.Length; i++)
        {
            componentSet.Add(i, components[i]);
        }

        foreach (var component in componentSet.GetAll())
        {
            _ = components.Should().Contain(component);
        }
    }
}
