using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day01Test
    {
        [Fact]
        public void GetIncreasesTest()
        {
            var data = new[]
                       {
                           199,
                            200,
                            208,
                            210,
                            200,
                            207,
                            240,
                            269,
                            260,
                            263
                       };

            var result = Day01.GetIncreases(data);

            Assert.Equal(7, result);
        }

        [Fact]
        public void GetWindowsTest()
        {
            var data = new[]
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };

            var expected = new[]
            {
                607,
                618,
                618,
                617,
                647,
                716,
                769,
                792
            };

            var result = Day01.GetWindows(data);

            Assert.Equal(expected, result);
        }
    }
}