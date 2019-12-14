using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace AdventOfCode
{
    public class Day2
    {
        // ReSharper disable PossibleMultipleEnumeration
        public static int Solve()
        {
            var inputRange = Enumerable.Range(0, 99).AsParallel();
            var results = from a in inputRange
                from b in inputRange
                where SolveForInputs(a, b) == 19690720
                select 100 * a + b;

            return results.First();
        }

        public static int SolveForInputs(int first, int second)
        {
            int[] inputs = (int[])Inputs.Clone();
            inputs[1] = first;
            inputs[2] = second;
            var results = IntCode.Execute(inputs);
            return inputs[0];
        }

        private static int[] Inputs => LazyInputs.Value;
        
        private static readonly Lazy<int[]> LazyInputs = new Lazy<int[]>(() => ReadInputs().ToArray(), LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<int> ReadInputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode.day2-input");
            if (input == null)
            {
                throw new InvalidOperationException();
            }

            using var sr = new StreamReader(input);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null)
                {
                    var numbers = line.Split(',');
                    foreach (string number in numbers)
                    {
                        yield return int.Parse(number);
                    } 
                }
            }
        }
    }
}
