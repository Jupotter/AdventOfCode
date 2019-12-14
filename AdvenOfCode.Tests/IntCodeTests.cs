using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IntCodeTests
    {
        [Theory]
        [InlineData(new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50}, new[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 })]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void Day2ProgramsTests(int[] code, int[] expected)
        {
            IntCode.Execute(code);
            code.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void InputOutputTest()
        {
            int[] program = {3, 0, 4, 0, 99};
            var outputs = IntCode.Execute(program, new[] {10});
            outputs.Should().ContainSingle().Which.Should().Be(10);
        }
    }
}