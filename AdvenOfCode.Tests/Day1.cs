using System;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace AdventOfCode.Tests
{
    public class Day1
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void SingleMassFuel(int mass, int expected)
        {
            AdventOfCode.Day1.FuelFor(mass).Should().Be(expected);
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void SingleMassFuelRecursive(int mass, int expected)
        {
            AdventOfCode.Day1.FuelForRecursive(mass).Should().Be(expected);
        }

        [Fact]
        public void FuelForList()
        {
            int[] mass = {12, 14, 1969, 100756};
            int expected = 2 + 2 + 654 + 33583;
            AdventOfCode.Day1.FuelFor(mass).Should().Be(expected);
        }


        [Fact]
        public void FuelForListRecursive()
        {
            int[] mass     = { 12, 14, 1969, 100756 };
            int   expected = 2 + 2 + 966 + 50346;
            AdventOfCode.Day1.FuelForRecursive(mass).Should().Be(expected);
        }
    }
}
