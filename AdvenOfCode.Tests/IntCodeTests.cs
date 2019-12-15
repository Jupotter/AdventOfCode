using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests
{
    public class IntCodeTests
    {
        [Theory]
        [InlineData(new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50},
            new[] {3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50})]
        [InlineData(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        [InlineData(new[] {2, 3, 0, 3, 99}, new[] {2, 3, 0, 6, 99})]
        [InlineData(new[] {2, 4, 4, 5, 99, 0}, new[] {2, 4, 4, 5, 99, 9801})]
        [InlineData(new[] {1, 1, 1, 4, 99, 5, 6, 0, 99}, new[] {30, 1, 1, 4, 2, 5, 6, 0, 99})]
        public void Day2ProgramsTests(int[] code, int[] expected)
        {
            IntCode.Execute(code);
            code.Should().BeEquivalentTo(expected);
        }

        private static readonly int[] compareTo8 = new[]
        {
            3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125,
            20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99
        };

        public static IEnumerable<object[]> GetCompareTo8Tests()
        {
            yield return new object[] {compareTo8, 7, 999, "input is less than 8"};
            yield return new object[] {compareTo8, 8, 1000, "input is equal to 8"};
            yield return new object[] {compareTo8, 9, 1001, "input is more than 8"};
        }


        [Theory]
        [InlineData(new[] {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8}, 8, 1, "input is equal to 8 using position mode")]
        [InlineData(new[] {3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8}, 7, 0, "input is not equal to 8 using position mode")]
        [InlineData(new[] {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8}, 9, 0, "input is more than 8 using position mode")]
        [InlineData(new[] {3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8}, 7, 1, "input is less than 8 using position mode")]
        [InlineData(new[] {3, 3, 1108, -1, 8, 3, 4, 3, 99}, 8, 1, "input is equal to 8 using immediate mode")]
        [InlineData(new[] {3, 3, 1108, -1, 8, 3, 4, 3, 99}, 7, 0, "input is not equal to 8 using immediate mode")]
        [InlineData(new[] {3, 3, 1107, -1, 8, 3, 4, 3, 99}, 9, 0, "input is more than 8 using immediate mode")]
        [InlineData(new[] {3, 3, 1107, -1, 8, 3, 4, 3, 99}, 7, 1, "input is less than 8 using immediate mode")]
        [InlineData(new[] {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9}, 0, 0,
            "input is 0 using position mode")]
        [InlineData(new[] {3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9}, 2, 1,
            "input is not 0 using position mode")]
        [InlineData(new[] {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1}, 0, 0, "input is 0 using immediate mode")]
        [InlineData(new[] {3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1}, 2, 1,
            "input is not 0 using immediate mode")]
        [MemberData(nameof(GetCompareTo8Tests))]
        public void Day5ProgramsTests(int[] code, int input, int expected, string because = "")
        {
            var outputs = IntCode.Execute(code, input);
            outputs.Should().ContainSingle().Which.Should().Be(expected, because);
        }

        [Fact]
        public void InputOutputTest()
        {
            int[] program = {3, 0, 4, 0, 99};
            var outputs = IntCode.Execute(program, new[] {10});
            outputs.Should().ContainSingle().Which.Should().Be(10);
        }


        [Fact]
        public void ImmediateInstructionTest()
        {
            int[] program = {1101, 100, -1, 4, 0};
            var outputs = IntCode.Execute(program, new[] {10});
            program.Should().BeEquivalentTo(1101, 100, -1, 4, 99);
        }
    }
}