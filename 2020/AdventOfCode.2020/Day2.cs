using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode2020
{
    internal record Policy(int Min, int Max, char Letter);

    public sealed class Day2 : BaseDay
    {
        private static readonly Regex LineRegex = new(@"^(?<min>\d+)-(?<max>\d+) (?<letter>\w): (?<password>\w+)$");

        private readonly IEnumerable<string> fileInput;

        public Day2()
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

        public override string Solve_1() => CountCorrectPasswords(fileInput).ToString();

        public override string Solve_2() => CountCorrectPasswords_2(fileInput).ToString();

        public int CountCorrectPasswords(IEnumerable<string> data)
        {
            var count = 0;
            foreach (string s in data)
            {
                ((int min, int max, char letter), var password) = ParseLine(s);
                int matchCount = password.Count(c => c == letter);
                if (min <= matchCount && matchCount <= max)
                {
                    count++;
                }
            }

            return count;
        }

        public int CountCorrectPasswords_2(IEnumerable<string> data)
        {
            var count = 0;
            foreach (string s in data)
            {
                ((int min, int max, char letter), var password) = ParseLine(s);

                if ((password[min - 1] == letter && password[max - 1] != letter) ||
                    (password[min - 1] != letter && password[max - 1] == letter))
                {
                    count++;
                }
            }

            return count;
        }

        private static (Policy, string) ParseLine(string line)
        {
            var match = LineRegex.Match(line);
            if (!match.Success)
            {
                throw new InvalidOperationException();
            }

            var  min    = int.Parse(match.Groups["min"].Value);
            var  max    = int.Parse(match.Groups["max"].Value);
            char letter = match.Groups["letter"].Value[0];

            string password = match.Groups["password"].Value;

            return (new Policy(min, max, letter), password);
        }
    }
}
