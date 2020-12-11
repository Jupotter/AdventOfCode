using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day9 : BaseDay
    {
        private long[] data;

        public Day9()
        {
            using var sr = new StreamReader(InputFilePath);
            data = sr.ReadToEnd().Split("\n").Select(s => long.Parse(s.Trim())).ToArray();
        }

        public static long FindError(IList<long> numbers, int preamble)
        {
            List<HashSet<long>> sums = new(numbers.Count);

            for (int i = 0; i < numbers.Count; i++)
            {
                var found = false;
                var value = numbers[i];
                sums.Add(new HashSet<long>());
                for (int j = i - 1; j >= i-preamble && j >= 0; j--)
                {
                    if (numbers[j] != value)
                    {
                        sums[i].Add(numbers[j] + value);
                    }
                    
                    if (sums[j].Contains(value))
                    {
                        found = true;
                    }
                }


                if (i > preamble && !found)
                {
                    return value;
                }
            }

            return -1;
        }

        public static long FindSum(IList<long> numbers, int preamble)
        {
            var target = FindError(numbers, preamble);

            List<long> sums = new(numbers.Count);

            for (var i = 0; i < numbers.Count; i++)
            {
                long value = numbers[i];
                for (int j = 0; j < sums.Count; j++)
                {
                    sums[j] += value;
                }

                var start = sums.IndexOf(target);
                if (start > -1)
                {
                    var range = numbers.Take(i).Skip(start).ToList();
                    return range.Min() + range.Max();
                }

                sums.Add(value);
            }

            return -1;
        }

        public override string Solve_1() => FindError(data, 25).ToString();

        public override string Solve_2() => FindSum(data, 25).ToString();
    }
}
