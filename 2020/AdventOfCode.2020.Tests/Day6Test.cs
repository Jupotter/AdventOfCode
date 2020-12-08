using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day6Test
    {
        private const string SampleData = @"abc

a
b
c

ab
ac

a
a
a
a

b";

        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a\r\nb\r\nc", 0)]
        [InlineData("ab\r\nac", 1)]
        [InlineData("a\r\na\r\na\r\na", 1)]
        [InlineData("b", 1)]
        public void CountAllTest(string data, int expected)
        {
            var result = Day6.CountAll(data);
            Assert.Equal(expected, result);
        }
    }
}
