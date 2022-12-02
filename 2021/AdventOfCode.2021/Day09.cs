namespace AdventOfCode2021;

public class Day09 : BaseDay 
{
    private readonly int[,] _input = new int[0, 0];

    public Day09()
    {
        var inputLines = File.ReadAllText(InputFilePath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

       _input =  ReadInput(inputLines);
    }

    public static int[,] ReadInput(string[] inputLines)
    {
        var lines = inputLines.Count();
        var length = inputLines[0].Length;

        var result  = new int[lines, length];

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < length; j++)
            {
                result[i, j] = inputLines[i][j] - '0';
            }
        }
        return result;
    }

    public static List<(int x, int y, int value)> GetLowPoint(int[,] data)
    {
        int[,] expendedData = ExpandArray(data);

        List<(int x, int y, int value)> lowPoints = new();

        for (int i = 1; i < expendedData.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < expendedData.GetLength(1) - 1; j++)
            {
                if (expendedData[i, j] < expendedData[i - 1, j]
                    && expendedData[i, j] < expendedData[i + 1, j]
                    && expendedData[i, j] < expendedData[i, j - 1]
                    && expendedData[i, j] < expendedData[i, j + 1])
                    lowPoints.Add(new (i, j, expendedData[i, j]));
            }
        }

        return lowPoints;
    }

    private static int[,] ExpandArray(int[,] data)
    {
        var expendedData = new int[data.GetLength(0) + 2, data.GetLength(1) + 2];
        for (int i = 0; i < expendedData.GetLength(0); i++)
        {
            for (int j = 0; j < expendedData.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == expendedData.GetUpperBound(0) || j == expendedData.GetUpperBound(1))
                {
                    expendedData[i, j] = 9;
                }
                else
                {
                    expendedData[i, j] = data[i - 1, j - 1];
                }
            }
        }

        return expendedData;
    }

    public override ValueTask<string> Solve_1()
    {
        var sum = GetLowPoint(_input).Select(t => t.value+1).Sum();
        return new ValueTask<string>(sum.ToString());

    }

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }
}
