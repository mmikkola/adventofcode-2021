using adventofcode_2021.Problems;
using Xunit;
using FluentAssertions;

namespace adventofcode_2021.tests
{
    public class Day1Tests
    {
        [Fact]
        public void Part1Test()
        {
            var input = new string[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };

            var day1 = new Day1();
            int result = (int)day1.Part1(input);

            result.Should().Be(7);
        }

        [Fact]
        public void Part2Test()
        {
            var input = new string[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };

            var day1 = new Day1();
            int result = (int)day1.Part2(input);

            result.Should().Be(5);
        }
    }
}