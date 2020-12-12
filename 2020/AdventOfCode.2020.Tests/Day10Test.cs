using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day10Test
    {
        private string SampleData = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";

        private string SampleDataSmall = @"16
10
15
5
1
11
7
19
6
12
4";

        [Fact]
        public void FindDifferencesTest()
        {
            var data = SampleData.Split('\n').Select(s => int.Parse(s.Trim())).ToArray();

            (int one, int three) = Day10.FindDifferences(data);

            Assert.Equal(22, one);
            Assert.Equal(10, three);
        }

        [Fact]
        public void FindDifferencesTestSmall()
        {
            var data = SampleDataSmall.Split('\n').Select(s => int.Parse(s.Trim())).ToArray();

            (int one, int three) = Day10.FindDifferences(data);

            Assert.Equal(7, one);
            Assert.Equal(5, three);
        }

        [Fact]
        public void FindArrangementsTestSmall()
        {
            var data = SampleDataSmall.Split('\n').Select(s => int.Parse(s.Trim())).ToArray();

            var result = Day10.CountArrangements(data);

            Assert.Equal(8, result);
        }

        [Fact]
        public void FindArrangementsTest()
        {
            var data = SampleData.Split('\n').Select(s => int.Parse(s.Trim())).ToArray();

            var result = Day10.CountArrangements(data);

            Assert.Equal(19208, result);
        }
    }
}
