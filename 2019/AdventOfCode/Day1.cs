using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public class Day1
    {
        public static int FuelForRecursive(int mass)
        {
            var fuel = FuelFor(mass);
            return fuel <= 0 ? 0 : fuel + FuelForRecursive(fuel);
        }


        public static int FuelForRecursive(IEnumerable<int> masses)
        {
            return masses.Select(FuelForRecursive).Sum();
        }

        public static int FuelFor(int mass)
        {
            return mass / 3 - 2;
        }

        public static int FuelFor(IEnumerable<int> masses)
        {
            return masses.Select(FuelFor).Sum();
        }

        public static int Solve()
        {
            return FuelForRecursive(Inputs());
        }

        private static IEnumerable<int> Inputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode.day1-input");
            if (input == null)
            {
                throw new InvalidOperationException();
            }

            using var sr = new StreamReader(input);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null) yield return int.Parse(line);
            }
        }
    }
}