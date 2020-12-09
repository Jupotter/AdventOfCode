using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day7Test
    {
        [Fact]
        public void ParseLine()
        {
            const string line = "light red bags contain 1 bright white bag, 2 muted yellow bags.";

            var tested = new Day7();

            tested.ParseData(line);

            var content = tested.BagContent["light red"];

            Assert.Equal(2, content.Count);
            Assert.Equal(1, content["bright white"]);
            Assert.Equal(2, content["muted yellow"]);
        }

        [Fact]
        public void ParseLineNoOther()
        {
            const string line = "dotted black bags contain no other bags.";

            var tested = new Day7();

            tested.ParseData(line);

            var content = tested.BagContent["dotted black"];

            Assert.Empty(content);
        }

        [Fact]
        public void FindParentsInSample()
        {
            const string data = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            var tested = new Day7();
            tested.ParseData(data);

            var result = tested.CountParents("shiny gold");

            Assert.Equal(4, result);

        }

        [Fact]
        public void FindContentsInSample()
        {
            const string data = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            var tested = new Day7();
            tested.ParseData(data);

            var result = tested.CountContent("shiny gold");

            Assert.Equal(32, result);

        }

        [Fact]
        public void FindContentsInSample2()
        {
            const string data = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

            var tested = new Day7();
            tested.ParseData(data);

            var result = tested.CountContent("shiny gold");

            Assert.Equal(126, result);

        }
    }
}
