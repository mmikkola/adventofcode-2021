using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day6Tests
    {
        private readonly string[] input = new string[]
        {
            "3,4,3,1,2"
        };

        [Fact]
        public void Part1Test()
        {
            var day6 = new Day6();
            var result = day6.Part1(input);

            result.Should().Be(5934);
        }

        [Fact]
        public void Part2Test()
        {
            var day6 = new Day6();
            var result = day6.Part2(input);

            result.Should().Be(26984457539);
        }
    }
}
