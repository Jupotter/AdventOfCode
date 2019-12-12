﻿using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day2
    {
        [Theory]
        [InlineData(new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50}, new[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 })]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void SimpleProgramTest(int[] code, int[] expected)
        {
            AdventOfCode.Day2.Execute(code).Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SolveForInput1202()
        {
            AdventOfCode.Day2.SolveForInputs(12, 2).Should().Be(4138658);
            AdventOfCode.Day2.SolveForInputs(12, 2).Should().Be(4138658);
        }
    }
}