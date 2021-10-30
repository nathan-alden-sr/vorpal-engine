using FluentAssertions;
using Xunit;

namespace VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests;

public sealed class WhenGettingAllComponents
{
    [Fact]
    public void MustReturnComponents()
    {
        ComponentSet<char> componentSet = new();
        char[] components = { 'A', 'B', 'C' };

        for (var i = 0; i < components.Length; i++)
        {
            componentSet.Add(i, components[i]);
        }

        foreach (char component in componentSet.GetAll())
        {
            components.Should().Contain(component);
        }
    }
}