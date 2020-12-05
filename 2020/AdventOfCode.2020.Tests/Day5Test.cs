using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day5Test
    {
        [Theory]
        [InlineData(44, 5, 357)]
        [InlineData(70, 7, 567)]
        [InlineData(14, 7, 119)]
        [InlineData(102, 4, 820)]
        public void SeatIdTest(int row, int column, int expected)
        {
            var result = Day5.GetSeatId(row, column);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5)]
        [InlineData("BFFFBBFRRR", 70, 7)]
        [InlineData("FFFBBBFRRR", 14, 7)]
        [InlineData("BBFFBBFRLL", 102, 4)]
        public void GetSeatPosition(string pass, int row, int column)
        {
            var result = Day5.GetSeatPosition(pass);
            Assert.Equal(row, result.row);
            Assert.Equal(column, result.column);
        }
    }
}
