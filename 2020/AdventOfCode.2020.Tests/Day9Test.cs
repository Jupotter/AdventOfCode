using System.Linq;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day9Test
    {
        private string SampleData = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        [Fact]
        public void FindErrorTest()
        {
            var data = SampleData.Split('\n').Select(s => long.Parse(s.Trim())).ToArray();

            var result = Day9.FindError(data, 5);

            Assert.Equal(127, result);
        }

        [Fact]
        public void FindSumTest()
        {
            var data = SampleData.Split('\n').Select(s => long.Parse(s.Trim())).ToArray();

            var result = Day9.FindSum(data, 5);

            Assert.Equal(62, result);
        }
    }
}
