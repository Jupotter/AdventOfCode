using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day3Test
    {
        private const string SampleData = @"
..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#
";

        [Fact]
        public void Solve1TestFromWeb()
        {
            var data   = Day3.LoadTrees(SampleData);
            var result = Day3.FindCollisions((3, 1), data);

            Assert.Equal(7, result);
        }

        [Fact]
        public void LoadTrees()
        {
            var expected = new[,]
                           {
                               {false, false, true, true, false, false, false, false, false, false, false},
                               {true, false, false, false, true, false, false, false, true, false, false},
                               {false, true, false, false, false, false, true, false, false, true, false},
                           };
            var result = Day3.LoadTrees(SampleData);

            Assert.Equal(11, result.GetLength(0));
            Assert.Equal(11, result.GetLength(1));

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.Equal(expected[i, j], result[i, j]);
                }
            }
        }
    }
}
