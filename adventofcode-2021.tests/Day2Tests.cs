using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day2Tests
    {
        [Fact]
        public void Part1Test()
        {
            var input = new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

            var day2 = new Day2();

            int result = (int)day2.Part1(input);

            result.Should().Be(150);
        }

        [Fact]
        public void Part2Test()
        {
            var input = new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

            var day2 = new Day2();

            int result = (int)day2.Part2(input);

            result.Should().Be(900);
        }
    }
}