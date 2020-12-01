using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day2
    {
        [Fact]
        public void SolveForInput1202()
        {
            AdventOfCode.Day2.SolveForInputs(12, 2).Should().Be(4138658);
            AdventOfCode.Day2.SolveForInputs(12, 2).Should().Be(4138658);
        }
    }
}
