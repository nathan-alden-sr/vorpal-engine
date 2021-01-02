using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenGettingItemByIndex
    {
        [Fact]
        public void MustGetCorrectItem()
        {
            ListEx<char> listEx = new();

            listEx.AddRange(new[] { 'A', 'B', 'C' });

            listEx[1].Should().Be('B');
            listEx[^1].Should().Be('C');
        }
    }
}