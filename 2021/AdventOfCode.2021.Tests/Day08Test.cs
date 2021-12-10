using System;

namespace AdventOfCode2021.Tests;

public class Day08Test { 

    [Fact]
    public void TestParseInputLine()
    {
        var expected = new Day08.DisplayInfo(new List<string> { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" },
            new List<string> { "cdfeb", "fcadb", "cdfeb", "cdbaf" });
        var line = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
        var result = Day08.ParseInputLine(line);

        Assert.Equal(expected.Input, result.Input);
        Assert.Equal(expected.Output, result.Output);
    }

    [Theory]
    [InlineData("|fdgacbe cefdb cefbgd gcbe", 2)]
    [InlineData("|fcgedb cgb dgebacf gc", 3)]
    [InlineData("|ed bcgafe cdgba cbgef", 1)]
    [InlineData("|edfga bcgafe cdgba cbgef", 0)]
    public void TestCountEasyOutput(string input, int expected)
    {
        var line = Day08.ParseInputLine(input);

        int result = Day08.CountEasyInput(line);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestDecodeDisplay()
    {
        var tested = new Day08.SegmentDisplay();
        var input = Day08.ParseInputLine("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");

        foreach (var data in input.Input.Concat(input.Output))
        {
            tested.AddInput(data);
        }

        Assert.True(tested.IsDecoded);
        Assert.Equal(5, tested.GetValue("cdfbe"));
    }

    [Theory]
    [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 5353)]
    [InlineData("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", 8394)]
    [InlineData("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 9781)]
    public void TestDecodeInput(string data, int expected)
    {
        var input = Day08.ParseInputLine(data);

        var result = Day08.Decode(input);
        Assert.Equal(expected, result);
    }
}