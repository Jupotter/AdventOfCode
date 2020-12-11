using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day8 : BaseDay
    {
        public enum Operation
        {
            Acc,
            Jmp,
            Nop,
        }

        public record Instruction(Operation Operation, int Argument)
        {
            public static Instruction Parse(string line)
            {
                var elements = line.Split(' ');

                Operation operation = elements[0].ToLower() switch
                {
                    "acc" => Operation.Acc,
                    "jmp" => Operation.Jmp,
                    "nop" => Operation.Nop,
                    _     => throw new ArgumentOutOfRangeException()
                };

                int argument = int.Parse(elements[1]);

                return new(operation, argument);
            }
        }

        public sealed class Machine
        {
            private readonly Instruction[] instructions;

            private int ip;
            private int accumulator;

            public Machine(IEnumerable<Instruction> instructions)
            {
                this.instructions = instructions.ToArray();
                ip = 0;
                accumulator = 0;
            }

            public int Accumulator => accumulator;

            public IList<Instruction> Instructions => instructions;

            public int Step()
            {
                if (ip >= instructions.Length)
                    return -1;
                (Operation operation, int argument) = instructions[ip];
                switch (operation)
                {
                    case Operation.Acc:
                        accumulator += argument;
                        ip += 1;
                        break;
                    case Operation.Jmp:
                        ip += argument;
                        break;
                    case Operation.Nop:
                        ip += 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return ip;
            }

            public void Reset()
            {
                ip = 0;
                accumulator = 0;
            }
        }

        public static Machine ParseInstructions(string data)
        {
            var instructions = data.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(l => Instruction.Parse(l.Trim()));
            return new Machine(instructions);
        }

        public static int FindLoop(Machine machine)
        {
            HashSet<int> seen = new();
            var ip = 0;
            while (ip != -1 && seen.Add(ip))
            {
                ip = machine.Step();
            }

            return ip;
        }

        public static void FixLoop(Machine machine)
        {
            for (int i = machine.Instructions.Count - 1; i >= 0; i--)
            {
                machine.Reset();
                var target = machine.Instructions[i];
                var newInstruction = target.Operation switch
                {
                    Operation.Nop => new Instruction(Operation.Jmp, target.Argument),
                    Operation.Jmp => new Instruction(Operation.Nop, target.Argument),
                    Operation.Acc => target,
                    _             => throw new ArgumentOutOfRangeException()
                };

                machine.Instructions[i] = newInstruction;
                if (FindLoop(machine) == -1)
                {
                    return;
                }

                machine.Instructions[i] = target;
            }
        }

        private readonly Machine machine;

        public Day8()
        {
            using var sr = new StreamReader(InputFilePath);
            machine = ParseInstructions(sr.ReadToEnd());
        }


        public override string Solve_1()
        {
            FindLoop(machine);
            return machine.Accumulator.ToString();
        }

        public override string Solve_2()
        {
            FixLoop(machine);
            return machine.Accumulator.ToString();
        }
    }
}
