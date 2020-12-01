using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day1 : BaseDay
    {

        private readonly IEnumerable<int> fileInput;

        public Day1()
        {
            var       data = new List<int>();
            using var sr   = new StreamReader(InputFilePath);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null)
                    data.Add(int.Parse(line));
            }

            fileInput = data;
        }

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

        public override string Solve_1()
        {
            return GetProductOf2020(fileInput).ToString();
        }

        public override string Solve_2()
        {
            return GetProductOf2020_2(fileInput).ToString();
        }
    }
}
