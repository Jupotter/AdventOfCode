namespace AdventOfCode2021.Tests;

public class Day04Test
{
    private const string TestData = @"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19
";


    [Fact]
    public void TestParseBingoBoard()
    {
        var expected = new[,] {
            {22, 13, 17, 11, 0},
            {8, 2, 23, 4, 24 },
            {21, 9, 14, 16, 7},
            {6, 10, 3, 18, 5},
            {1, 12, 20, 15, 19}
        };
        var tested = Day04.BingoBoard.Parse(TestData);

        Assert.False(tested.IsValid());
        CompareBoardToExpected(expected, tested);
    }

    [Fact]
    public void CheckBoardValid1()
    {
        var tested = Day04.BingoBoard.Parse(TestData);
        tested[3, 0].Marked = true;
        tested[3, 1].Marked = true;
        tested[3, 2].Marked = true;
        tested[3, 3].Marked = true;
        tested[3, 4].Marked = true;

        Assert.True(tested.IsValid());
    }

    [Fact]
    public void CheckBoardValid2()
    {
        var tested = Day04.BingoBoard.Parse(TestData);
        tested[0, 3].Marked = true;
        tested[1, 3].Marked = true;
        tested[2, 3].Marked = true;
        tested[3, 3].Marked = true;
        tested[4, 3].Marked = true;

        Assert.True(tested.IsValid());
    }

    [Fact]
    public void TestMarkNumber()
    {
        var tested = Day04.BingoBoard.Parse(TestData);

        tested.Mark(14);

        Assert.True(tested[2, 2].Marked);
    }

    [Fact]
    public void TestValidateWithMarkNumber()
    {
        var tested = Day04.BingoBoard.Parse(TestData);

        tested.Mark(14);
        tested.Mark(23);
        tested.Mark(2);
        tested.Mark(17);
        tested.Mark(3);
        tested.Mark(20);

        Assert.True(tested.IsValid());
    }

    [Fact]
    public void TestParseMultipleBoards()
    {
        var text =
            @"
22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

        var tested = Day04.ParseBoards(text);

        Assert.Equal(3, tested.Count);
    }

    private static void CompareBoardToExpected(int[,] expected, Day04.BingoBoard tested)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Assert.Equal(expected[i, j], tested[i, j].Number);
                Assert.False(tested[i, j].Marked);
            }
        }
    }
}