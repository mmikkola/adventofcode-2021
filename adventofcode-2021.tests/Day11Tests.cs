using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day11Tests
    {
        private readonly string[] input =
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };

        [Fact]
        public void Part1Test()
        {
            var day10 = new Day11();
            int result = (int)day10.Part1(input);

            result.Should().Be(1656);
        }

        [Fact]
        public void Part2Test()
        {
            var day10 = new Day11();
            long result = (int)day10.Part2(input);

            result.Should().Be(195);
        }
    }
}