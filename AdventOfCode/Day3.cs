using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
            return new Point(first.X + second.X, first.Y+second.Y);
        }
    }

    public class Day3
    {
        public static IEnumerable<Point> FindIntersections(IEnumerable<IEnumerable<string>> instructions)
        {
            var intersections = new List<Point>();
            var lines = new HashSet<Point>();
            bool first = true;
            foreach (var line in instructions)
            {
                Point current = new Point();
                foreach (string instruction in line)
                {
                    var direction = instruction[0];
                    var size = int.Parse(instruction.Substring(1));
                    var iteration = direction switch
                    {
                        'U' => new Point(0, 1),
                        'D' => new Point(0, -1),
                        'L' => new Point(-1, 0),
                        'R' => new Point(1, 0),
                        _   => throw new InvalidOperationException()
                    };

                    for (int i = 0; i < size; i++)
                    {
                        current += iteration;
                        if (lines.Contains(current) && !first)
                        {
                            intersections.Add(current);
                        }
                        else
                        {
                            lines.Add(current);
                        }
                    }
                }

                first = false;
            }
            return intersections;
        }

        public static Point FindClosestCrossing(IEnumerable<IEnumerable<string>> instructions)
        {
            var intersections = FindIntersections(instructions);
            return intersections.OrderBy(p => p.X + p.Y).First();
        }

        public static Point FindClosestCrossing(string instructions)
        {
            var instructionList = instructions.Split('\n').Select(s => s.Split(','));
            return FindClosestCrossing(instructionList);
        }

        public static int FindClosestCrossingDistance(string instructions)
        {
            var crossing = FindClosestCrossing(instructions);
            return crossing.X + crossing.Y;
        }
    }
}