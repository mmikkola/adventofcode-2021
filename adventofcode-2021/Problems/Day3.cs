using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day3
    {
        public int Part1(string[] input)
        {
            int inputLength = input[0].Length;
            int[] ones = new int[inputLength];
            int[] zeroes = new int[inputLength];

            foreach(var line in input)
            {
                for(int i = 0; i < inputLength; i++)
                {
                    switch(line[i])
                    {
                        case '0':
                            zeroes[i]++;
                            break;
                        case '1':
                            ones[i]++;
                            break;
                        default:
                            break;
                    }
                }
            }

            StringBuilder gammaRateRaw = new StringBuilder();
            StringBuilder epsilonRateRaw = new StringBuilder();

            for(int i = 0; i < inputLength; i++)
            {
                if(ones[i] > zeroes[i])
                {
                    gammaRateRaw.Append("1");
                    epsilonRateRaw.Append("0");
                }
                else
                {
                    gammaRateRaw.Append("0");
                    epsilonRateRaw.Append("1");
                }
            }

            int gammaRate = Convert.ToInt32(gammaRateRaw.ToString(), 2);
            int epsilonRate = Convert.ToInt32(epsilonRateRaw.ToString(), 2);

            return gammaRate * epsilonRate;
        }

        public int Part2(string[] input)
        {
            string oxygenRatingRaw = FindNextNumbers(input, 0, true).First();
            string co2ScrubberRatingRaw = FindNextNumbers(input, 0, false).First();

            int oxygenRating = Convert.ToInt32(oxygenRatingRaw.ToString(), 2);
            int co2ScrubberRating = Convert.ToInt32(co2ScrubberRatingRaw.ToString(), 2);

            return oxygenRating * co2ScrubberRating;
        }

        private string[] FindNextNumbers(IEnumerable<string> input, int position, bool mostCommon)
        {
            if (input.Count() == 1)
                return input.ToArray();

            int ones = input.Count(x => x[position] == '1');
            int zeroes = input.Count(x => x[position] == '0');

            char compare = ones >= zeroes ? '1' : '0';

            if(mostCommon)
                return FindNextNumbers(input.Where(x => x[position] == compare), position + 1, mostCommon);
            else
                return FindNextNumbers(input.Where(x => x[position] != compare), position + 1, mostCommon);
        }
    }
}
