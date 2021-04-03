using System;
using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.EntityComponentSystem.UnitTests.ComponentSetTests
{
    public class WhenGettingAllComponents
    {
        [Fact]
        public void MustReturnComponents()
        {
            ComponentSet<char> componentSet = new();

            componentSet.Add(0, 'A');
            componentSet.Add(1, 'B');
            componentSet.Add(2, 'C');

            ReadOnlySpan<char> all = componentSet.GetAll();

            for (var i = 0; i < componentSet.Count; i++)
            {
                all[i].Should().Be(componentSet[i]);
            }
        }
    }
}