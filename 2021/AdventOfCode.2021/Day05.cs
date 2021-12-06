namespace AdventOfCode2021;

public class Day05 : BaseDay
{
    public record class VentLine(int X1, int Y1, int X2, int Y2)
    {
        public VentLine ((int x, int y) start, (int x, int y) end) : this(start.x, start.y, end.x, end.y) { }
    };

    private List<VentLine> _input = new List<VentLine>();

    public Day05()
    {
        if (!File.Exists(InputFilePath))
            return;

        _input = ParseLines(File.ReadAllText(InputFilePath));
    }
    public static List<VentLine> ParseLines(string input)
    {
        var result = new List<VentLine>();
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var coordinates = line.Split("->", StringSplitOptions.TrimEntries);
            var startStr = coordinates[0];
            var endStr = coordinates[1];

            result.Add(new VentLine(ParseCoordinate(startStr), ParseCoordinate(endStr)));
        }

        return result;
    }

    private static (int X, int Y) ParseCoordinate(string input)
    {
        var split = input.Split(',');

        return (int.Parse(split[0]), int.Parse(split[1]));

    }

    public static void PlaceStraightLines(int[,] array, IEnumerable<VentLine> lines)
    {
        foreach (var line in lines.Where(l => l.X1 == l.X2))
        {
            var start = line.Y1;
            var end = line.Y2;
            if (line.Y1 > line.Y2)
            {
                start = line.Y2;
                end = line.Y1;
            }

            for (int i = start; i <= end; i++)
            {
                array[line.X1, i] += 1;
            }
        }

        foreach (var line in lines.Where(l => l.Y1 == l.Y2))
        {
            var start = line.X1;
            var end = line.X2;
            if (line.X1 > line.X2)
            {
                start = line.X2;
                end = line.X1;
            }

            for (int i = start; i <= end; i++)
            {
                array[i, line.Y1] += 1;
            }
        }
    }

    public static void PlaceDiagonals(int[,] array, IEnumerable<VentLine> lines)
    {
        foreach (var line in lines.Where(l => l.X1 != l.X2 && l.Y1 != l.Y2))
        {
            if (line.X1 < line.X2 && line.Y1 < line.Y2
                || line.X1 > line.X2 && line.Y1 > line.Y2)
            {
                var startX = Math.Min(line.X1, line.X2);
                var startY = Math.Min(line.Y1, line.Y2);
                var length = Math.Abs(line.X1 - line.X2);
                for (int i = 0; i <= length; i++)
                {
                    array[startX + i, startY + i]++;
                }
            } 
            else
            {

                var startX = Math.Min(line.X1, line.X2);
                var startY = Math.Max(line.Y1, line.Y2);
                var length = Math.Abs(line.X1 - line.X2);
                for (int i = 0; i <= length; i++)
                {
                    array[startX + i, startY - i]++;
                }
            }
        }
    }

    public static int CountMultiples(int[,] array)
    {
        int total = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > 1)
                {
                    total++;
                }
            }
        }
        return total;
    }

    public override ValueTask<string> Solve_1()
    {
        var array = new int[1000, 1000];
        PlaceStraightLines(array, _input);
        var total = CountMultiples(array);
        return new ValueTask<string>(total.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var array = new int[1000, 1000];
        PlaceStraightLines(array, _input);
        PlaceDiagonals(array, _input);
        var total = CountMultiples(array);
        return new ValueTask<string>(total.ToString());
    }
}
