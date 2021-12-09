using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day10Tests
    {
        private readonly string[] input =
        {

        };

        [Fact]
        public void Part1Test()
        {
            var day10 = new Day10();
            int result = day10.Part1(input);

            result.Should().Be(0);
        }

        [Fact]
        public void Part2Test()
        {
            var day10 = new Day10();
            int result = day10.Part2(input);

            result.Should().Be(0);
        }
    }
}