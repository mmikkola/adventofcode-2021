using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day3Tests
    {
        [Fact]
        public void Part1Test()
        {
            var input = new string[] { 
                "00100", 
                "11110", 
                "10110", 
                "10111", 
                "10101", 
                "01111",
                "00111",
                "11100", 
                "10000", 
                "11001",
                "00010",
                "01010"
            };

            var day3 = new Day3();
            var result = (int)day3.Part1(input);

            result.Should().Be(198);
        }

        [Fact]
        public void Part2Test()
        {
            var input = new string[] {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            var day3 = new Day3();
            var result = (int)day3.Part2(input);

            result.Should().Be(230);
        }
    }
}
