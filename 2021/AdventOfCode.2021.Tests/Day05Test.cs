namespace AdventOfCode2021.Tests;

public class Day05Test
{
    [Fact]
    public void TestParseLines()
    {
        var data = @"0,9 -> 5,9
                     8,0 -> 0,8
                     9,4 -> 3,4
                     2,2 -> 2,1
                     7,0 -> 7,4
                     6,4 -> 2,0
                     0,9 -> 2,9
                     3,4 -> 1,4
                     0,0 -> 8,8
                     5,5 -> 8,2";

        var expected = new List<Day05.VentLine>()
        {
            new Day05.VentLine(0, 9, 5, 9),
            new Day05.VentLine(8,0,0,8),
            new Day05.VentLine(9,4,3,4),
            new Day05.VentLine(2,2,2,1),
            new Day05.VentLine(7,0,7,4),
            new Day05.VentLine(6,4,2,0),
            new Day05.VentLine(0,9,2,9),
            new Day05.VentLine(3,4,1,4),
            new Day05.VentLine(0,0,8,8),
            new Day05.VentLine(5,5,8,2),
        };

        var tested = Day05.ParseLines(data);
        Assert.Equal(expected, tested);
    }
}
