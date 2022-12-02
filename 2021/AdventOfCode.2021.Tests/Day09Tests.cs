namespace AdventOfCode2021.Tests;

public class Day09Tests
{
    private string testData = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    [Fact]
    public void TestFindLowPoints()
    {
        var data = Day09.ReadInput(testData.Split(Environment.NewLine));

        var lowPoints = Day09.GetLowPoint(data);
        var result = lowPoints.Select(t => t.value+1).Sum();

        Assert.Equal(15, result);
    }
}