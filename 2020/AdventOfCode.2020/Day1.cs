using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class Day1
    {
        public const int Number = 1;

        public int GetProductOf2020(IEnumerable<int> input)
        {
            IEnumerable<int> inner = input.ToList();
            IEnumerable<int> results = from i in inner
                                       join j in inner on 1 equals 1
                                       let sum = i + j
                                       where sum == 2020
                                       select i * j;

            return results.First();
        }

        public int GetProductOf2020_2(IEnumerable<int> input)
        {
            IEnumerable<int> inner = input.ToList();
            IEnumerable<int> results = from i in inner
                                       join j in inner on 1 equals 1
                                       join k in inner on 1 equals 1
                                       let sum = i + j + k
                                       where sum == 2020
                                       select i * j * k;

            return results.First();
        }

        public static int Solve()
        {
            return new Day1().GetProductOf2020(Inputs());
        }

        public static int SolvePart2()
        {
            return new Day1().GetProductOf2020_2(Inputs());
        }

        private static IEnumerable<int> Inputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2020.day1-input.txt");
            if (input == null)
            {
                throw new InvalidOperationException();
            }

            using var sr = new StreamReader(input);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null)
                    yield return int.Parse(line);
            }
        }
    }
}
