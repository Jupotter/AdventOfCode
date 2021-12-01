using System.Collections.Generic;

namespace AdventOfCode2021;
using System.Linq;

public class Day01 : BaseDay
{
    private readonly List<int> _input;

    public Day01()
    {
        var data = new List<int>();
        using var sr = new StreamReader(InputFilePath);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();

            if (line != null)
                data.Add(int.Parse(line));
        }
        _input = data;
    }

    public static int GetIncreases(IEnumerable<int> inputs)
    {
        return inputs.Aggregate((acc: 0, prev: inputs.First()),
            (t, cur) => (t.prev < cur ? t.acc + 1 : t.acc, cur),
            t => t.acc);
    }

    public static List<int> GetWindows(IEnumerable<int> inputs)
    {
        return inputs.Zip(inputs.Skip(1).Zip(inputs.Skip(2))).Select(t => t.First + t.Second.First + t.Second.Second).ToList();
    }

    public override ValueTask<string> Solve_1() => new(GetIncreases(_input).ToString());
    public override ValueTask<string> Solve_2() => new(GetIncreases(GetWindows(_input)).ToString());
}