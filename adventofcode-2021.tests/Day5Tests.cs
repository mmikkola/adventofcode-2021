using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day5Tests
    {
        private readonly string[] input = new string[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Fact]
        public void Part1Test()
        {
            var day5 = new Day5();
            var result = day5.Part1(input);

            result.Should().Be(5);
        }

        [Fact]
        public void Part2Test()
        {
            var day5 = new Day5();
            var result = day5.Part2(input);

            result.Should().Be(12);
        }
    }
}
