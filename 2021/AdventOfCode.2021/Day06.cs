namespace AdventOfCode2021;

public class Day06 : BaseDay
{

    List<int> _input = new List<int>();

    public Day06()
    {
        if (!File.Exists(InputFilePath))
            return;

        _input = File.ReadAllText(InputFilePath).Split(',').Select(int.Parse).ToList();
    }
    public static IEnumerable<int> Grow(IEnumerable<int> fishes)
    {
        return fishes.SelectMany(f =>
        {
            if (f == 0)
            {
                return new int[] { 6, 8 };
            }
            else
            {
                return new int[] { f - 1 };
            }
        });
    }

    public static long GrowFast(List<int> initial, int iterations)
    {
        long[] fishCount = new long[9];
        for (int i = 0; i <= 8; i++)
        {
            fishCount[i] = initial.Count(f => f == i);
        }

        foreach (var _ in Enumerable.Range(0, iterations))
        {
            var zero = fishCount[0];
            for (int i = 1; i <= 8; i++)
            {
                fishCount[i-1] = fishCount[i];
            }

            fishCount[6] += zero;
            fishCount[8] = zero;
        }

        return fishCount.Sum();
    }


    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(GrowFast(_input, 80).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        return new ValueTask<string>(GrowFast(_input, 256).ToString());
    }
}
