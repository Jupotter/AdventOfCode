namespace AdventOfCode2021;

public class Day02 : BaseDay
{
    private readonly List<string> _input = new();

    private int position, depth, aim;

    public Day02()
    {
        if (!File.Exists(InputFilePath))
            return;
        var content = File.ReadAllLines(InputFilePath);
        _input = new (content);
    }

    public int GetTotalDistance(IEnumerable<string> instructions)
    {
        position = 0;
        depth = 0;

        foreach (var instruction in instructions)
        {
            var splitted = instruction.Split(' ');

            var value = int.Parse(splitted[1]);
            switch (splitted[0])
            {
                case "forward":
                    position += value; break;
                case "down":
                    depth += value; break;
                case "up":
                    depth -= value; break;

                default:
                    throw new InvalidOperationException();
            }
        }

        return position * depth;
    }

    public int GetTotalDistance2(IEnumerable<string> instructions)
    {
        position = 0;
        depth = 0;
        aim = 0;

        foreach (var instruction in instructions)
        {
            var splitted = instruction.Split(' ');

            var value = int.Parse(splitted[1]);
            switch (splitted[0])
            {
                case "forward":
                    position += value;
                    depth += aim * value;
                    break;
                case "down":
                    aim += value; break;
                case "up":
                    aim -= value; break;

                default:
                    throw new InvalidOperationException();
            }
        }

        return position * depth;
    }


    public override ValueTask<string> Solve_1()
    {
        return new(GetTotalDistance(_input).ToString());
    }


    public override ValueTask<string> Solve_2()
    {
        return new(GetTotalDistance2(_input).ToString());
    }
}
