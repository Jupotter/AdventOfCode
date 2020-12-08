using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day6 : BaseDay
    {
        private readonly string data;

        public Day6()
        {
            using var sr = new StreamReader(InputFilePath);
            data = sr.ReadToEnd();
        }

        public override string Solve_1()
        {
            return SplitData(data).Select(CountUnique).Sum().ToString();
        }

        public override string Solve_2()
        {
            return SplitData(data).Select(CountAll).Sum().ToString();
        }

        public static int CountUnique(string data)
        {
            HashSet<char> unique = new HashSet<char>(data);
            unique.Remove('\r');
            unique.Remove('\n');
            return unique.Count;
        }

        public static int CountAll(string data)
        {
            var   split = data.Split(Environment.NewLine);
            int[] count = new int[26];
            foreach (var line in split)
            {
                foreach (var c in line)
                {
                    count[c - 'a']++;
                }
            }

            return count.Count(c => c == split.Length);
        }

        public static IEnumerable<string> SplitData(string source)
        {
            return source.Trim().Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
