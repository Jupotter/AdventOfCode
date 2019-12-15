using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class IntCode : IDisposable
    {
        private enum Mode
        {
            Position,
            Immediate,
        }

        private struct Parameter
        {
            public readonly Mode Mode;
            public readonly int Value;

            public Parameter(Mode mode, int value)
            {
                Mode = mode;
                Value = value;
            }
        }

        private readonly int[] program;
        private readonly IEnumerator<int> inputs;
        private readonly List<int> outputs = new List<int>();

        private readonly Dictionary<int, Action> operations;

        private readonly Parameter[] parameters = new Parameter[3];
        private int ip = 1;

        public static IEnumerable<int> Execute(int[] program, params int[] inputs)
        {
            using var intCode = new IntCode(program, inputs);
            return intCode.Execute();
        }

        private IntCode(int[] program, IEnumerable<int>? inputs)
        {
            this.program = program;
            this.inputs = inputs?.GetEnumerator() ?? new List<int>().GetEnumerator();

            operations = new Dictionary<int, Action>
            {
                {99, Halt},
                {1, Add},
                {2, Multiply},
                {3, ReadInput},
                {4, Output},
                {5, JumpIfTrue},
                {6, JumpIfFalse },
                {7, LessThan},
                {8, Equals},
            };
        }

        private IEnumerable<int> Execute()
        {
            inputs.Reset();
            outputs.Clear();
            ip = 0;
            while (ip >= 0 && ip < program.Length)
            {
                var op = Decode(program[ip]);
                operations[op]();
            }

            return outputs;
        }

        private int Decode(int opcode)
        {
            int operation = opcode % 100;
            opcode /= 100;
            var parCount = operation switch
            {
                1 => 3,
                2 => 3,
                3 => 1,
                4 => 1,
                5 => 2,
                6 => 2,
                7 => 3,
                8 => 3,
                99 => 0,
                _ => 0
            };
            for (int i = 1; i <= parCount; i++)
            {
                var mode = (Mode)(opcode % 10);
                parameters[i - 1] = new Parameter(mode, program[ip + i]);
                opcode /= 10;
            }

            return operation;
        }

        private int GetValue(Parameter parameter)
        {
            return parameter.Mode switch
            {
                Mode.Position => program[parameter.Value],
                Mode.Immediate => parameter.Value,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void Halt()
        {
            ip = -1;
        }

        private void ReadInput()
        {
            inputs.MoveNext();
            program[parameters[0].Value] = inputs.Current;
            ip += 2;
        }

        private void Output()
        {
            outputs.Add(GetValue(parameters[0]));
            ip += 2;
        }

        private void Add()
        {
            Arithmetic((a, b) => a + b);
        }

        private void Multiply()
        {
            Arithmetic((a, b) => a * b);
        }
        
        private void Arithmetic(Func<int, int, int> operation)
        {
            var op1 = GetValue(parameters[0]);
            var op2 = GetValue(parameters[1]);
            program[parameters[2].Value] = operation(op1, op2);
            ip += 4;
        }

        private void JumpIfTrue()
        {
            var op1 = GetValue(parameters[0]);
            var op2 = GetValue(parameters[1]);
            if (op1 != 0)
            {
                ip = op2;
            }
            else ip += 3;
        }

        private void JumpIfFalse()
        {
            var op1 = GetValue(parameters[0]);
            var op2 = GetValue(parameters[1]);
            if (op1 == 0)
            {
                ip = op2;
            }
            else ip += 3;
        }

        private void LessThan()
        {
            Arithmetic((a, b) => a < b ? 1 : 0);
        }


        private void Equals()
        {
            Arithmetic((a, b) => a == b ? 1 : 0);
        }

        public void Dispose()
        {
            inputs?.Dispose();
        }
    }
}