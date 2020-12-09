using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day4 : BaseDay
    {
        private readonly string data;

        private static readonly string[] RequiredFields =
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            //"cid"
        };

        public Day4()
        {
            using var sr = new StreamReader(InputFilePath);
            data = sr.ReadToEnd();
        }

        public override string Solve_1() => ValidPassports(ParsePassports(data)).ToString();

        public override string Solve_2() => ValidPassportsStrict(ParsePassports(data)).ToString();

        public static int ValidPassports(IEnumerable<IDictionary<string, string>> passports) => passports.Count(p => RequiredFields.All(p.ContainsKey));

        public static int ValidPassportsStrict(IEnumerable<IDictionary<string, string>> passports)
        {
            return passports.Count(ValidPassport);
        }

        public static bool ValidPassport(IDictionary<string, string> passports)
        {
            List<string> errors = new();
            try
            {
                if (!RequiredFields.All(passports.ContainsKey))
                    return false;
                foreach (var (key, value) in passports)
                {
                    switch (key)
                    {
                        case "byr":
                            var year = int.Parse(value);
                            if (!(1920 <= year && year <= 2002))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }

                            break;
                        case "iyr":
                            year = int.Parse(value);
                            if (!(2010 <= year && year <= 2020))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }
                            break;
                        case "eyr":
                            year = int.Parse(value);
                            if (!(2020 <= year && year <= 2030))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }
                            break;
                        case "hgt":
                            var regex  = new Regex(@"(\d+)(cm|in)");
                            var match  = regex.Match(value);
                            var height = int.Parse(match.Groups[1].Value);
                            switch (match.Groups[2].Value)
                            {
                                case "cm":
                                    if (!(150 <= height && height <= 193))
                                    {
                                        errors.Add($"Invalid {key} {value}");
                                        return false;
                                    }
                                    break;
                                case "in":
                                    if (!(59 <= height && height <= 76))
                                    {
                                        errors.Add($"Invalid {key} {value}");
                                        return false;
                                    }
                                    break;
                                default:
                                {
                                    errors.Add($"Invalid {key} {value}");
                                    return false;
                                }
                            }

                            break;
                        case "hcl":
                            regex = new Regex(@"#[0-9a-f]{6}");
                            if (!regex.IsMatch(value))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }
                            break;
                        case "ecl":
                            regex = new Regex(@"(amb|blu|brn|gry|grn|hzl|oth)");
                            if (!regex.IsMatch(value))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }
                            break;
                        case "pid":
                            regex = new Regex(@"^\d{9}$");
                            if (!regex.IsMatch(value))
                            {
                                errors.Add($"Invalid {key} {value}");
                                return false;
                            }
                            break;
                        case "cid":
                            break;
                        default:
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static IEnumerable<IDictionary<string, string>> ParsePassports(string source)
        {

            string split = "\n\n";
            if (source.Contains('\r'))
                split = "\r\n\r\n";
            var passports = source.Split(split, StringSplitOptions.RemoveEmptyEntries);

            var regex = new Regex(@"(\w{3}):((?:#|\w)+)");
            var result = passports.Select(passport =>
                                              regex.Matches(passport).ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value)
            );

            return result;
        }
    }
}
