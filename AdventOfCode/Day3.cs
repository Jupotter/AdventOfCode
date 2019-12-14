using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static Point operator +(Point first, Point second)
        {
            return new Point(first.X + second.X, first.Y + second.Y);
        }

        public int Distance(Point other)
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }

        public int Distance()
        {
            return Distance(Zero);
        }

        public static readonly Point Zero = default;
    }

    public class Day3
    {
        public static IEnumerable<Point> FindIntersections(IEnumerable<IEnumerable<string>> instructions)
        {
            var intersections = new List<Point>();
            var lines = new HashSet<Point>();
            var first = true;
            foreach (var line in instructions)
            {
                var current = new Point();
                foreach (var instruction in line)
                {
                    var direction = instruction[0];
                    var size = int.Parse(instruction.Substring(1));
                    var iteration = direction switch
                    {
                        'U' => new Point(0, 1),
                        'D' => new Point(0, -1),
                        'L' => new Point(-1, 0),
                        'R' => new Point(1, 0),
                        _ => throw new InvalidOperationException()
                    };

                    for (var i = 0; i < size; i++)
                    {
                        current += iteration;
                        if (lines.Contains(current) && !first)
                            intersections.Add(current);
                        else
                            lines.Add(current);
                    }
                }

                first = false;
            }

            return intersections;
        }

        public static Point FindClosestCrossing(IEnumerable<IEnumerable<string>> instructions)
        {
            var intersections = FindIntersections(instructions);
            return intersections.OrderBy(p => p.Distance()).First();
        }

        public static Point FindClosestCrossing(IEnumerable<string> instructions)
        {
            var instructionList = instructions.Select(s => s.Split(','));
            return FindClosestCrossing(instructionList);
        }

        public static int FindClosestCrossingDistance(IEnumerable<string> instructions)
        {
            var crossing = FindClosestCrossing(instructions);
            return crossing.Distance();
        }

        public static int Solve()
        {
            var inputs = ReadInputs();
            return FindClosestCrossingDistance(inputs);
        }

        private static IEnumerable<string> ReadInputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode.day3-input.txt");
            if (input == null) throw new InvalidOperationException();

            using var sr = new StreamReader(input);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                if (line != null) yield return line;
            }
        }
    }
}