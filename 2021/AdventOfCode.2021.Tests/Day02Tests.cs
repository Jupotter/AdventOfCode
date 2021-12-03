namespace AdventOfCode2021.Tests;

public class Day02Tests
{
    [Fact]
    public void GetTotalDistanceTest()
    {
        string[] data =
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2",
        };

        var tested = new Day02();

        var distance = tested.GetTotalDistance(data);

        Assert.Equal(150, distance);
    }

    [Fact]
    public void GetTotalDistance2Test()
    {
        string[] data =
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2",
        };

        var tested = new Day02();

        var distance = tested.GetTotalDistance2(data);

        Assert.Equal(900, distance);
    }
}
