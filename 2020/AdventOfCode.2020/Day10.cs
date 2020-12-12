using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day10 : BaseDay
    {
        private int[] data;

        public Day10()
        {
            using var sr = new StreamReader(InputFilePath);
            data = sr.ReadToEnd().Split("\n").Select(s => int.Parse(s.Trim())).ToArray();
        }

        public static (int one, int three) FindDifferences(IList<int> adapters)
        {
            var max         = adapters.Max();
            var sorted      = adapters.Concat(new[] {0, max + 3}).OrderBy(i => i).ToList();
            var differences = sorted.Zip(sorted.Skip(1), (i, j) => j - i).ToList();

            return (differences.Count(i => i == 1), differences.Count(i => i == 3));
        }

        public static long CountArrangements(IList<int> adapters)
        {
            var max    = adapters.Max();
            var sorted = adapters.Concat(new[] {0, max + 3}).OrderBy(i => i).ToList();

            var differences1 = sorted.Zip(sorted.Skip(1), (i, j) => j - i).ToList();
            var differences2 = sorted.Zip(sorted.Skip(2), (i, j) => j - i);
            var differences3 = sorted.Zip(sorted.Skip(3), (i, j) => j - i);

            var nbOk = differences2.Zip(differences3, (a, b) => (a: a, b: b))
                                   .Select(tuple =>
                                    {
                                        var count = 0;
                                        if (tuple.b <= 3)
                                            count++;
                                        if (tuple.a <= 3)
                                            count++;
                                        return count+1;
                                    }).ToList();


            int x =0, y =0, z = 0;

            var runLength = 0;
            for (int i = 0; i < differences1.Count(); i++)
            {
                if (differences1[i] == 1)
                {
                    runLength++;
                }
                else
                {
                    switch (runLength)
                    {
                        case 2:
                            x++;
                            break;
                        case 3:
                            y++;
                            break;
                        case 4:
                            z++;
                            break;
                    }

                    runLength = 0;
                }
            }
            
            return (long)(Math.Pow(2, x) * Math.Pow(4, y) * Math.Pow(7, z));
        }

        public override string Solve_1()
        {
            (int one, int three) = FindDifferences(data);
            return (one * three).ToString();
        }

        public override string Solve_2() => CountArrangements(data).ToString();
    }
}
