using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day4
    {
        [Fact]
        public void TestDoubleMatch()
        {
            var input = 122345;
            AdventOfCode.Day4.CheckValid(input).Should().BeTrue("the 22 is a repeat");
            input = 112233;
            AdventOfCode.Day4.CheckValid(input).Should().BeTrue("the digits never decrease and all repeated digits are exactly two digits long");
            input = 111122;
            AdventOfCode.Day4.CheckValid(input).Should().BeTrue("even though 1 is repeated more than twice, it still contains a double 22");
            input = 123456;
            AdventOfCode.Day4.CheckValid(input).Should().BeFalse("there is no repeat");
            input = 123444;
            AdventOfCode.Day4.CheckValid(input).Should().BeFalse("the repeated 44 is part of a larger group of 444");
        }

        [Fact]
        public void TestIncrease()
        {
            var input = 122345;
            AdventOfCode.Day4.CheckValid(input).Should().BeTrue();
            input = 1223450;
            AdventOfCode.Day4.CheckValid(input).Should().BeFalse();
        }
    }
}
