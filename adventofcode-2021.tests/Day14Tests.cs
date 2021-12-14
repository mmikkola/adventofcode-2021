using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day14Tests
    {
        private readonly string[] input =
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        };

        [Fact]
        public void Part1Test()
        {
            var day = new Day14();
            long result = (long)day.Part1(input);

            result.Should().Be(1588);
        }

        [Fact]
        public void Part2Test()
        {
            var day = new Day14();
            long result = (long)day.Part2(input);

            result.Should().Be(2188189693529);
        }
    }
}