using System.Linq;

namespace AdventOfCode2021;

public class Day08 : BaseDay
{
    public record struct DisplayInfo(List<string> Input, List<string> Output);

    public class SegmentDisplay
    {
        // Store wires possible for each segment
        //  00
        // 1  2
        // 1  2
        //  33
        // 4  5
        // 4  5
        //  66
        private List<char>[] wires = Enumerable.Range(0, 7).Select(_ => new List<char>("abcdefg")).ToArray();

        public bool IsDecoded => wires.All(x => x.Count == 1);

        public void AddInput(string input)
        {
            if (IsDecoded)
                return;
            var except = "abcdefg".Except(input).ToHashSet();
            switch (input.Length)
            {
                case 2: // number is 1
                    wires[2].RemoveAll(x => except.Contains(x));
                    wires[5].RemoveAll(x => except.Contains(x));
                    break;
                case 3: // number is 7
                    wires[0].RemoveAll(x => except.Contains(x));
                    wires[2].RemoveAll(x => except.Contains(x));
                    wires[5].RemoveAll(x => except.Contains(x));
                    break;
                case 4: // number is 4
                    wires[1].RemoveAll(x => except.Contains(x));
                    wires[3].RemoveAll(x => except.Contains(x));
                    wires[2].RemoveAll(x => except.Contains(x));
                    wires[5].RemoveAll(x => except.Contains(x));
                    break;
                case 5: // number is 2, 3 or 5
                    wires[0].RemoveAll(x => except.Contains(x));
                    wires[3].RemoveAll(x => except.Contains(x));
                    wires[6].RemoveAll(x => except.Contains(x));
                    break;
                case 6: // number is 0, 6 or 9
                    wires[0].RemoveAll(x => except.Contains(x));
                    wires[1].RemoveAll(x => except.Contains(x));
                    wires[5].RemoveAll(x => except.Contains(x));
                    wires[6].RemoveAll(x => except.Contains(x));
                    break;
                case 7: // number is 8
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(input), input);
            }

            System.Diagnostics.Debug.Assert(!wires.Any(w => w.Count == 0), "No segment should be empty");
            if (IsDecoded)
                return;

            for (int i = 0; i < 7; i++)
            {
                if (wires[i].Count == 1)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (i != j)
                        {
                            wires[j].Remove(wires[i][0]);

                            System.Diagnostics.Debug.Assert(!wires.Any(w => w.Count == 0), "No segment should be empty");
                        }
                    }
                }
            }

        }

        public int GetValue(string input)
        {
            switch (input.Length)
            {
                case 2:
                    return 1;
                case 3:
                    return 7;
                case 4:
                    return 4;
                case 7:
                    return 8;
                case 5: // number is 2, 3 or 5
                    if (input.Contains(wires[4][0]))
                        return 2;
                    else if (input.Contains(wires[1][0]))
                        return 5;
                    else return 3;

                case 6: // number is 0, 6 or 9
                    if (!input.Contains(wires[3][0]))
                        return 0;
                    else if (input.Contains(wires[2][0]))
                        return 9;
                    else return 6;

                default:
                    throw new ArgumentOutOfRangeException(nameof(input), input);
            }
        }
    }

    private readonly List<DisplayInfo> _input;

    public Day08()
    {

        _input = File.ReadAllText(InputFilePath).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(ParseInputLine).ToList();
    }
    public static DisplayInfo ParseInputLine(string line)
    {
        var parts = line.Split('|');
        var inputs = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var output = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new DisplayInfo(inputs.ToList(), output.ToList());
    }

    public static int CountEasyInput(DisplayInfo line)
    {
        return line.Output.Count(l => l.Length == 2 || l.Length == 4 || l.Length == 7 || l.Length == 3);
    }

    public static int Decode(DisplayInfo input)
    {
        var display = new SegmentDisplay();
        foreach (var data in input.Input.Concat(input.Output))
        {
            display.AddInput(data);
        }

        return input.Output.Aggregate(0, (acc, val) => acc * 10 + display.GetValue(val));
    }

    public override ValueTask<string> Solve_1()
    {
        return new ValueTask<string>(_input.Sum(CountEasyInput).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var result = _input.Select(x => Decode(x)).Sum();
        return new ValueTask<string>(result.ToString());
    }

}