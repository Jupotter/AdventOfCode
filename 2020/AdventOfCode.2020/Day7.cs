using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AoCHelper;

namespace AdventOfCode2020
{
    public sealed class Day7 : BaseDay
    {
        private readonly Dictionary<string, Dictionary<string, int>> bagContent = new();

        public Day7()
        {
            using var sr = new StreamReader(InputFilePath);
            ParseData(sr.ReadToEnd());
        }

        public IReadOnlyDictionary<string, Dictionary<string, int>> BagContent => bagContent;

        public void ParseData(string data)
        {
            bagContent.Clear();

            var regex = new Regex(@"(?<bag>\w+ \w+) bags contain(?:( (?<count>\d+) (?<color>\w+ \w+) bags?(,|.))| no other bags\.)+");

            MatchCollection matches = regex.Matches(data);
            foreach (Match match in matches)
            {
                string bag = match.Groups["bag"].Value;
                bagContent[bag] = new Dictionary<string, int>();
                for (var i = 0; i < match.Groups[1].Captures.Count; i++)
                {
                    string color = match.Groups["color"].Captures[i].Value;
                    string count = match.Groups["count"].Captures[i].Value;

                    bagContent[bag].Add(color, int.Parse(count));
                }
            }
        }

        public int CountParents(string bag)
        {
            Dictionary<string, List<string>> reversed = ReverseBags();

            HashSet<string> seen    = new();
            Queue<string>   toCheck = new();
            toCheck.Enqueue(bag);

            do
            {
                string current = toCheck.Dequeue();
                foreach (string container in reversed[current].Where(c => seen.Add(c)))
                    toCheck.Enqueue(container);
            } while (toCheck.Any());

            return seen.Count;
        }

        public int CountContent(string bag)
        {
            int CountContentRec(string current, int times)
            {
                int count = 1;

                foreach (var content in bagContent[current])
                {
                    count += CountContentRec(content.Key, content.Value);
                }

                return count * times;
            }

            return CountContentRec(bag, 1) - 1;
        }

        private Dictionary<string, List<string>> ReverseBags()
        {
            var reversed = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Dictionary<string, int>> content in bagContent)
            {
                string bag = content.Key;
                if (!reversed.ContainsKey(bag))
                    reversed[bag] = new List<string>();
                foreach (string contained in content.Value.Keys)
                {
                    if (!reversed.ContainsKey(contained))
                        reversed[contained] = new List<string>();
                    reversed[contained].Add(bag);
                }
            }

            return reversed;
        }

        public override string Solve_1() => CountParents("shiny gold").ToString();

        public override string Solve_2() => CountContent("shiny gold").ToString();
    }
}
