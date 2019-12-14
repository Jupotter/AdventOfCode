using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class IntCode : IDisposable
    {
        private readonly int[] program;
        private readonly IEnumerator<int> inputs;
        private readonly List<int> outputs = new List<int>();

        private readonly Dictionary<int, Action> operations;

        private int ip = 1;

        public static IEnumerable<int> Execute(int[] program, IEnumerable<int>? inputs = null)
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
                {4, Output}
            };
        }

        private IEnumerable<int> Execute()
        {
            inputs.Reset();
            outputs.Clear();
            ip = 0;
            while (ip >= 0 && ip < program.Length)
            {
                operations[program[ip]]();
            }

            return outputs;
        }

        private void Halt()
        {
            ip = -1;
        }

        private void ReadInput()
        {
            inputs.MoveNext();
            program[program[ip + 1]] = inputs.Current;
            ip += 2;
        }

        private void Output()
        {
            outputs.Add(program[program[ip + 1]]);
            ip += 2;
        }

        private void Add()
        {
            var op1 = program[program[ip + 1]];
            var op2 = program[program[ip + 2]];
            program[program[ip + 3]] = (op1 + op2);
            ip += 4;
        }

        private void Multiply()
        {
            var op1 = program[program[ip + 1]];
            var op2 = program[program[ip + 2]];
            program[program[ip + 3]] = (op1 * op2);
            ip += 4;
        }

        public void Dispose()
        {
            inputs?.Dispose();
        }
    }
}