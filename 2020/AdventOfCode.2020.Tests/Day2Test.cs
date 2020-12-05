using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day2Test
    {
        [Fact]
        public void Solve1TestFromWeb()
        {
            var tested = new Day2();
            var data = new[]
                       {
                           "1-3 a: abcde",
                           "1-3 b: cdefg",
                           "2-9 c: ccccccccc",
                       };

            var result = tested.CountCorrectPasswords(data);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Solve2TestFromWeb()
        {
            var tested = new Day2();
            var data = new[]
                       {
                           "1-3 a: abcde",
                           "1-3 b: cdefg",
                           "2-9 c: ccccccccc",
                       };

            var result = tested.CountCorrectPasswords_2(data);

            Assert.Equal(1, result);
        }
    }
}
