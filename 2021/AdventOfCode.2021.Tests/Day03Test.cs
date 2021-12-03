namespace AdventOfCode2021.Tests;

public class Day03Test {

    private readonly uint[] exampleData = new [] {
            0b00100U,
            0b11110U,
            0b10110U,
            0b10111U,
            0b10101U,
            0b01111U,
            0b00111U,
            0b11100U,
            0b10000U,
            0b11001U,
            0b00010U,
            0b01010U,
        };

    [Fact]
    public void MostCommonBitTest()
    {
        var expected = 0b10110U;

        var result = Day03.GetMostCommonBitByColumn(exampleData, 5);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0b10110U, 5, 0b01001U)]
    [InlineData(0b11111U, 5, 0b00000U)]
    [InlineData(0b00000U, 5, 0b11111U)]
    public void ReverseTest(uint input, int columnCount, uint expected)
    {
        var result = Day03.Reverse(input, columnCount);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetO2GeneratorRating()
    {
        var expected = 0b10111U;
        var result = Day03.GetO2GeneratorRating(exampleData, 5);
        Assert.Equal(expected, result);
    }
    [Fact]
    public void GetCO2ScrubberRating()
    {
        var expected = 0b01010U;
        var result = Day03.GetCO2ScrubberRating(exampleData, 5);
        Assert.Equal(expected, result);
    }
}
