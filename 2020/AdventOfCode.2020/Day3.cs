using System;
using System.IO;
using System.Linq;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day3 : BaseDay
    {
        private readonly bool[,] data;

        public Day3()
        {
            using var sr   = new StreamReader(InputFilePath);
            data = LoadTrees(sr.ReadToEnd());
        }

        public override string Solve_1() => FindCollisions((3, 1), data).ToString();

        public override string Solve_2()
        {
            var slopes = new[]
                         {
                             (x: 1, y: 1),
                             (x: 3, y: 1),
                             (x: 5, y: 1),
                             (x: 7, y: 1),
                             (x: 1, y: 2),
                         };

            return slopes.Select(s => FindCollisions(s, data)).Aggregate((x, y) => x * y).ToString();
        }

        public static bool[,] LoadTrees(string source)
        {
            source = source.Trim();
            string split = "\n";
            if (source.Contains('\r'))
                split = "\r\n";
            var lines  = source.Split(split);
            var length = lines[0].Length;
            var result = new bool[lines.Length, length];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = (lines[i][j] == '#');
                }
            }

            return result;
        }

        public static int FindCollisions((int x, int y) slope, bool[,] trees)
        {
            var width  = trees.GetLength(1);
            var height = trees.GetLength(0);
            var count  = 0;
            var pos    = (x: 0, y: 0);
            while (pos.y < height)
            {
                if (trees[pos.y, pos.x])
                {
                    count++;
                }

                pos.x += slope.x;
                pos.y += slope.y;
                if (pos.x >= width)
                {
                    pos.x -= width;
                }
            }

            return count;
        }
    }
}
