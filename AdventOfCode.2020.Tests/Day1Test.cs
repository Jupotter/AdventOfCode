using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day1Test
    {
        [Fact]
        public void SampleTest()
        {
            var tested = new Day1();
            var data = new[]
                       {
                           1721,
                           979,
                           366,
                           299,
                           675,
                           1456
                       };

            var result = tested.GetProductOf2020(data);
            var result2 = tested.GetProductOf2020_2(data);

            Assert.Equal(514579,    result);
            Assert.Equal(241861950, result2);
        }
    }
}
