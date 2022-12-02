using FluentAssertions;

namespace AdventOfCode2022.Tests;

[TestFixture]
public class Day01Should
{
    private const string SampleData = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [Test]
    public async Task SolveSampleData()
    {
        var tested = new Day01(SampleData);
        var result = await tested.Solve_1();

        result.Should().Be("24000");
    }

    [Test]
    public async Task SolveSampleData2()
    {
        var tested = new Day01(SampleData);
        var result = await tested.Solve_2();

        result.Should().Be("45000");
    }
}