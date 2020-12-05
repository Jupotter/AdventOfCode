using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day5Test
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void GetSeatPosition(string pass, int seatId)
        {
            var result = Day5.GetSeatPosition(pass);
            Assert.Equal(seatId, result);
        }
    }
}
