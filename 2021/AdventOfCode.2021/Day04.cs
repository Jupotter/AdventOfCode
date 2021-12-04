namespace AdventOfCode2021;

public class Day04 : BaseDay
{
    private List<int> numbers = new();
    private List<BingoBoard> boards = new();

    public Day04()
    {
        if (!File.Exists(InputFilePath))
            return;

        using var sr = new StreamReader(InputFilePath);
        
        var numbersLine = sr.ReadLine();
        System.Diagnostics.Debug.Assert(numbersLine != null);

        numbers = numbersLine.Split(',').Select(int.Parse).ToList();
        boards = ParseBoards(sr.ReadToEnd());
    }

    public override ValueTask<string> Solve_1()
    {
        var winners = GetWinningBoard(numbers, boards);
        int result = GetScore(winners.lastNumber, winners.board);

        return new(result.ToString());
    }

    private static int GetScore(int lastNumber, BingoBoard board)
    {
        var unmarkedSum = board.Tiles.Where(t => !t.Marked).Select(t => t.Number).Sum();
        var result = lastNumber * unmarkedSum;
        return result;
    }

    public override ValueTask<string> Solve_2()
    {
        var winners = GetLastWinningBoard(numbers, boards);
        int result = GetScore(winners.lastNumber, winners.board);

        return new(result.ToString());
    }

    public (int lastNumber, BingoBoard board) GetWinningBoard(IEnumerable<int> numbers, IEnumerable<BingoBoard> boards) 
    {
        foreach (int i in numbers)
        {
            foreach(BingoBoard board in boards)
            {
                board.Mark(i);
                if (board.IsValid())
                {
                    return (i, board);
                }
            }
        }

        throw new InvalidOperationException();
    }

    public (int lastNumber, BingoBoard board) GetLastWinningBoard(IEnumerable<int> numbers, IEnumerable<BingoBoard> boards)
    {
        var remainingBoards = boards.ToList();
        var toRemove = new List<BingoBoard>();

        int lastNumber = 0;
        BingoBoard? lastWin = null;
        foreach (int i in numbers)
        {
            toRemove.Clear();
            foreach (BingoBoard board in remainingBoards)
            {
                board.Mark(i);
                if (board.IsValid())
                {
                    lastNumber = i;
                    lastWin = board;
                    toRemove.Add(board);
                }
            }

            foreach (BingoBoard board in toRemove)
                remainingBoards.Remove(board);

            if (!remainingBoards.Any())
                break;
        }

        System.Diagnostics.Debug.Assert(lastWin != null);
        return (lastNumber, lastWin);
    }

    public class BingoBoard
    {
        public record class Tile(int Number)
        {
            public bool Marked { get; set; } = false;
        }

        public IEnumerable<Tile> Tiles => tiles.Values;

        private readonly Tile[,] board = new Tile[5, 5];

        private readonly Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

        public Tile this[int x, int y]
        {
            get => board[x, y];
            private set
            {
                if (board[x, y] != null)
                    tiles.Remove(board[x, y].Number);
                board[x, y] = value;
                tiles[value.Number] = value;
            }
        }

        public bool IsValid()
        {
            bool[] columns = new bool[5];
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = true;
            }

            for (int i = 0; i < 5; i++)
            {
                bool line = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!this[i, j].Marked)
                    {
                        line = false;
                        columns[j] = false;
                    }
                }
                if (line)
                    return true;
            }
            return columns.Any(b => b);
        }

        public static BingoBoard Parse(string description)
        {
            var board = new BingoBoard();

            var lines = description.Split(Environment.NewLine);
            int i = 0;
            foreach(var line in lines)
            {
                var numbers=  line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length == 0)
                    continue;
                var j = 0;
                foreach (var number in numbers)
                {
                    if (int.TryParse(number, out var parsed))
                    {
                        board[i, j] = new Tile(parsed);
                        j++;
                    }
                }
                i++;
            }

            return board;
        }

        public void Mark(int number)
        {
            if (tiles.ContainsKey(number))
                tiles[number].Marked = true;
        }
    }

    public static List<BingoBoard> ParseBoards(string input)
    {
        var split = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

        return split.Select(x => BingoBoard.Parse(x)).ToList();
    }
}
