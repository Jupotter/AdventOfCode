using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3
    {
        [Fact]
        public void TestNoCrossing()
        {
            var instructions = new[] {new[] {"U3"}, new[] {"L3"}};
            var results = AdventOfCode.Day3.FindIntersections(instructions);
            results.Should().BeEmpty();
        }

        [Fact]
        public void TestOneCrossing()
        {
            var instructions = new[] {new[] {"U2", "L3"}, new[] {"L2", "U3"}};
            var results = AdventOfCode.Day3.FindIntersections(instructions);
            results.Should().HaveCount(1).And.Contain(new Point(-2, 2));
        }

        [Fact]
        public void TestTwoCrossings()
        {
            var instructions = new[] {new[] {"R8", "U5", "L5", "D3"}, new[] {"U7", "R6", "D4", "L4"}};
            var results = AdventOfCode.Day3.FindIntersections(instructions);
            results.Should().HaveCount(2).And.Contain(new[] {new Point(3, 3), new Point(6, 5)});
        }

        [Fact]
        public void TestNoOwnCrossings()
        {
            var instructions = new[] {new[] {"R8", "U5", "L5", "D10"}};
            var results = AdventOfCode.Day3.FindIntersections(instructions);
            results.Should().BeEmpty();
        }

        [Fact]
        public void TestClosestInOneCrossing()
        {
            var instructions = new[] {new[] {"U2", "L3"}, new[] {"L2", "U3"}};
            var results = AdventOfCode.Day3.FindClosestCrossing(instructions);
            results.Should().Be(new Point(-2, 2));
        }

        [Fact]
        public void TestClosestInTwoCrossing()
        {
            var instructions = new[] {new[] {"R8", "U5", "L5", "D3"}, new[] {"U7", "R6", "D4", "L4"}};
            var results = AdventOfCode.Day3.FindClosestCrossing(instructions);
            results.Should().Be(new Point(3, 3));
        }

        [Theory]
        [InlineData(new[] {"R8,U5,L5,D3", "U7,R6,D4,L4"}, 6)]
        [InlineData(new[] {"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83"}, 159)]
        [InlineData(new[] {"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"}, 135)]
        public void FindClosestCrossing(IEnumerable<string> instruction, int distance)
        {
            AdventOfCode.Day3.FindClosestCrossingDistance(instruction).Should().Be(distance);
        }
    }
}