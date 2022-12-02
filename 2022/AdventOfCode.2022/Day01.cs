namespace AdventOfCode2022;

public sealed class Day01 : BaseDay
{
    private readonly List<int> carried = new();

    public Day01()
    {
        using var reader = new StreamReader(InputFilePath);
        LoadText(reader);
    }
    public Day01(string content)
    {
        using var reader = new StringReader(content);
        LoadText(reader);
    }

    private void LoadText(TextReader reader)
    {
        var line = reader.ReadLine();
        int i    = 0;
        do
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                i++;
            }
            else
            {
                var value = int.Parse(line);
                if (carried.Count <= i)
                {
                    carried.Add(0);
                }

                carried[i] += value;
            }

            line = reader.ReadLine();
        } while (line != null);
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(carried.Max().ToString());
    }

    public override ValueTask<string> Solve_2() => new(carried.OrderDescending().Take(3).Sum().ToString());
}