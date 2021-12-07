using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day7Tests
    {
        private readonly string[] input = new string[]
        {
            "16,1,2,0,4,2,7,1,2,14"
        };

        [Fact]
        public void Part1Test()
        {
            var day = new Day7();
            var result = day.Part1(input);

            result.Should().Be(37);
        }

        [Fact]
        public void Part2Test()
        {
            var day = new Day7();
            var result = day.Part2(input);

            result.Should().Be(168);
        }
    }
}
