using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day6
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("COM)A", 1)]
        [InlineData("COM)A,A)B", 3)]
        [InlineData("COM)A,A)B,A)C", 5)]
        [InlineData("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L", 42)]
        public void OrbitCountTest(string inputs, int expected)
        {
            AdventOfCode.Day6.CountOrbits(inputs.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Should().Be(expected);
        }
    }
}
