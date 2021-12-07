namespace AdventOfCode2021;

public class Day07 : BaseDay
{
    List<int> _input = new List<int>();

    public Day07()
    {
        if (!File.Exists(InputFilePath))
            return;

        _input = File.ReadAllText(InputFilePath).Split(',').Select(int.Parse).ToList();
    }

    public static int FindMedian(IEnumerable<int> input)
    {
        var sorted = input.OrderBy(x => x);
        var count = input.Count();

        var median = sorted.ElementAt(count / 2);
        return median;
    }

    public static double SumTo(double n)
    {
        return (n * (n + 1)) / 2;
    }

    public override ValueTask<string> Solve_1()
    {
        var median = FindMedian(_input);

        var cost = _input.Select(i => Math.Abs(i - median)).Sum();
        return new ValueTask<string>(cost.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var mean = _input.Average();
        var meanF = Math.Floor(mean);
        var meanC = Math.Ceiling(mean);

        var costC = _input.Select(i => SumTo(Math.Abs(i - meanC))).Sum();
        var costF = _input.Select(i => SumTo(Math.Abs(i - meanF))).Sum();

        var minCost = Math.Min(costF, costC);

        return new ValueTask<string>(minCost.ToString());
    }
}