using System;
using System.Windows;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Day 1: {Day1.Solve()}");
            Console.WriteLine($"Day 2: {Day2.Solve()}");
            Console.WriteLine($"Day 3: {Day3.Solve()}");
            Console.WriteLine($"Day 4: {Day4.Solve()}");
            Console.WriteLine($"Day 5: {string.Join(", ", Day5.Solve())}");
        }
    }
}
