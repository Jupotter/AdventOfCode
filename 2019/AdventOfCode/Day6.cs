using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode
{
    public class Day6
    {
        private class Planet
        {
            public string Name { get; }
            public List<Planet> Satellites { get; }

            public Planet(string name)
            {
                Name = name;
                Satellites = new List<Planet>();
            }

            public int GetOrbitCount(int parent)
            {
                return Satellites.Select(s => s.GetOrbitCount(parent + 1)).Sum() + parent;
            }
        }

        public static int CountOrbits(IEnumerable<string> inputs)
        {
            var orbits = new Day6(inputs);
            return orbits.GetTotalOrbitCount();
        }

        private readonly Dictionary<string, Planet> planets = new Dictionary<string, Planet>();

        private Day6(IEnumerable<string> inputs)
        {
            planets.Add("COM", new Planet("COM"));
            foreach (var p in inputs)
            {
                var split = p.Split(')');
                var planet = GetPlanet(split[0]);
                var satellite = GetPlanet(split[1]);

                planet.Satellites.Add(satellite);
            }
        }

        private Planet GetPlanet(string name)
        {
            Planet planet;
            if (planets.ContainsKey(name))
                planet = planets[name];
            else
            {
                planet = new Planet(name);
                planets[planet.Name] = planet;
            }

            return planet;
        }

        public int GetTotalOrbitCount()
        {
            return planets["COM"].GetOrbitCount(0);
        }

        public static int Solve()
        {
            return CountOrbits(Inputs());
        }

        private static IEnumerable<string> Inputs()
        {
            using var input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode.day6-input.txt");
            if (input == null)
            {
                throw new InvalidOperationException();
            }

            using var sr = new StreamReader(input);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();

                if (line != null) yield return line;
            }
        }
    }
}
