using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day8Tests
    {
        private readonly string[] input = new string[]
        {
            "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"
        };

        [Fact]
        public void Part1Test()
        {
            var day = new Day7();
            var result = day.Part1(input);

            result.Should().Be(26);
        }

        [Fact]
        public void Part2Test()
        {
            var day = new Day7();
            var result = day.Part2(input);

            result.Should().Be(-1);
        }
    }
}
