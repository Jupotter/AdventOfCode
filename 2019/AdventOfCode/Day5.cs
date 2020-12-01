using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode
{
    class Day5
    {
        public static IEnumerable<int> Solve()
        {
            var results = IntCode.Execute(ReadInputs().ToArray(), 5);
            return results;
        }

        private static IEnumerable<int> ReadInputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode.day5-input.txt");
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
