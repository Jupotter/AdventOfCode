namespace AdventOfCode2021;

public class Day03 : BaseDay
{
    private List<uint> _input = new List<uint>();
    private int _columnCount = 0;

    public Day03()
    {
        if (!File.Exists(InputFilePath))
            return;

        var content = File.ReadAllLines(InputFilePath);
        _columnCount = content[0].Trim().Length;

        _input = content.Select(l => Convert.ToUInt32(l.Trim(), 2)).ToList();

    }

    public static uint GetMostCommonBitByColumn(IEnumerable<uint> array, int columnCount)
    {
        int[] count = new int[columnCount];
        foreach (uint value in array)
        {
            for (int i = 0; i < columnCount; i++)
            {
                uint bit = 1U << i;

                if ((value & bit) == 0)
                {
                    count[i]++;
                } 
                else
                {
                    count[i]--;
                }
            }
        }

        uint result = 0;
        for (int i = 0; i < columnCount; i++)
        {
            result |= (count[i] > 0 ? 0U : 1U) << i;
        }

        return result;
    }

    public static uint GetMostCommonBitByColumn(IEnumerable<uint> array, int column,  int columnCount)
    {
        int count = 0;
        foreach (uint value in array)
        {
                uint bit = 1U << column;

                if ((value & bit) == 0)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            
        }

        return count > 0 ? 0U : 1U;
    }

    public static uint GetO2GeneratorRating(IEnumerable<uint> array, int columnCount)
    {
        List<uint> remaining = array.ToList();

        int c = columnCount-1;
        while (remaining.Count > 1)
        {
            var mask = 1U << c;
            var mostCommon = GetMostCommonBitByColumn(remaining, c, columnCount);

            for (int i = remaining.Count() - 1; i >= 0; i--)
            {
                if (((remaining[i] ^ (mostCommon << c)) & mask) != 0)
                    remaining.RemoveAt(i);
            }

            c--;
        }

        return remaining[0];
    }

    public static uint GetCO2ScrubberRating(IEnumerable<uint> array, int columnCount)
    {
        List<uint> remaining = array.ToList();

        int c = columnCount - 1;
        while (remaining.Count > 1)
        {
            var mask = 1U << c;
            var mostCommon = GetMostCommonBitByColumn(remaining, c, columnCount);

            for (int i = remaining.Count() - 1; i >= 0; i--)
            {
                if (((remaining[i] ^ (mostCommon << c)) & mask) == 0)
                    remaining.RemoveAt(i);
            }

            c--;
        }

        return remaining[0];
    }

    public static uint Reverse (uint input, int columnCount) => (uint)(~input & ((1 << columnCount) - 1));

    public override ValueTask<string> Solve_1()
    {
        var result = GetMostCommonBitByColumn(_input, _columnCount);
        var reverse = Reverse(result, _columnCount);
        return new((result * reverse).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var CO2 = GetCO2ScrubberRating(_input, _columnCount);
        var O2 = GetO2GeneratorRating(_input, _columnCount);
        return new((CO2 * O2).ToString());
    }
}
