namespace AdventOfCode2021.Tests;

public class Day06Test {

    [Theory]
    [InlineData(new[] { 0 }, new[] { 6, 8 })]
    [InlineData(new[] { 3 }, new[] { 2 })]
    [InlineData(new[] { 3, 0 }, new[] { 2, 6, 8 })]
    public void TestGrow(int[] input, int[] expected)
    {
        var result = Day06.Grow(input);
        Assert.All(result, r => Assert.Contains(r, expected));
    }

    [Fact]
    public void TestGrowFast()
    {
        var data = new List<int> { 3, 4, 3, 1, 2 };
        var result = Day06.GrowFast(data, 18);
        Assert.Equal(26, result);
        result = Day06.GrowFast(data, 80);
        Assert.Equal(5934, result);
    }
}
