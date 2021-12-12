using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day12Tests
    {
        private readonly string[] input =
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };

        [Fact]
        public void Part1Test()
        {
            var day = new Day12();
            int result = (int)day.Part1(input);

            result.Should().Be(10);
        }

        [Fact]
        public void Part2Test()
        {
            var day = new Day12();
            long result = (int)day.Part2(input);

            result.Should().Be(36);
        }
    }
}