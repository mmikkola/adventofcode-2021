using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day9Tests
    {
        private readonly string[] input = new string[]
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        [Fact]
        public void Part1Test()
        {
            var day = new Day9();
            var result = day.Part1(input);

            result.Should().Be(15);
        }

        [Fact]
        public void Part2Test()
        {
            var day = new Day9();
            var result = day.Part2(input);

            result.Should().Be(61229);
        }
    }
}
