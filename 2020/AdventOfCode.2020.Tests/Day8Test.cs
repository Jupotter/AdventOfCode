using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day8Test
    {
        private const string SampleData = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        [Fact]
        public void ParseInstructionsTest()
        {
            var expected = new Day8.Instruction[]
                           {
                               new(Day8.Operation.Nop, 0),
                               new(Day8.Operation.Acc, 1),
                               new(Day8.Operation.Jmp, 4),
                               new(Day8.Operation.Acc, 3),
                               new(Day8.Operation.Jmp, -3),
                               new(Day8.Operation.Acc, -99),
                               new(Day8.Operation.Acc, 1),
                               new(Day8.Operation.Jmp, -4),
                               new(Day8.Operation.Acc, 6),
                           };

            var result = Day8.ParseInstructions(SampleData);

            Assert.NotNull(result);
            Assert.Equal(expected, result.Instructions);
        }

        [Fact]
        public void FindLoopTest()
        {
            var tested = Day8.ParseInstructions(SampleData);

            var result = Day8.FindLoop(tested);

            Assert.Equal(1, result);
            Assert.Equal(5, tested.Accumulator);
        }
    }
}
