using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day5 : BaseDay
    {
        private readonly IEnumerable<string> fileInput;

        public Day5()
        {
            var       data = new List<string>();
            using var sr   = new StreamReader(InputFilePath);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null)
                    data.Add(line);
            }

            fileInput = data;
        }

        public override string Solve_1()
        {
            return fileInput.Select(GetSeatPosition)
                            .Max()
                            .ToString();
        }

        public override string Solve_2()
        {
            HashSet<int> seats = new HashSet<int>(fileInput.Select(GetSeatPosition));
            int i = 0;
            for (; i < 963; i++)
            {
                if (seats.Contains(i))
                {
                    break;
                }
            }

            i++;

            for (; i < 963; i++)
            {
                if (!seats.Contains(i))
                {
                    break;
                }
            }

            return i.ToString();
        }

        public static int GetSeatPosition(string pass)
        {
            pass = pass.ToUpperInvariant();
            int value = 0;
            foreach (var t in pass)
            {
                switch (t)
                {
                    case 'B':
                    case 'R':
                        value = value * 2 + 1;
                        break;
                    case 'F':
                    case 'L':
                        value = value * 2;
                        break;
                    default:
                        Debug.Assert(false);
                        throw new InvalidOperationException();
                }
            }

            return value;
        }
    }
}
