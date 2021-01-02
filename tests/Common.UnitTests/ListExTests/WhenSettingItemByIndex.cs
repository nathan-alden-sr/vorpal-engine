using FluentAssertions;
using Xunit;

namespace NathanAldenSr.VorpalEngine.Common.UnitTests.ListExTests
{
    public class WhenSettingItemByIndex
    {
        [Fact]
        public void MustSetCorrectItem()
        {
            ListEx<char> listEx = new();

            listEx.AddRange(3);

            listEx[1] = 'B';
            listEx[2] = 'C';

            listEx[1].Should().Be('B');
            listEx[2].Should().Be('C');
        }
    }
}