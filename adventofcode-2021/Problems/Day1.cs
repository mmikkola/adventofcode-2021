using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day1 : ProblemBase
    {
        public override object Part1(string[] input)
        {
            int[] numbers = input.Select(x => int.Parse(x)).ToArray();

            int cnt = 0;

            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                    cnt++;
            }

            return cnt;
        }

        public override object Part2(string[] input)
        {
            int[] numbers = input.Select(x => int.Parse(x)).ToArray();

            int cnt = 0;
            int prevSum = int.MaxValue;

            for(int i = 2; i < numbers.Length; i++)
            {
                int sum = numbers[i] + numbers[i - 1] + numbers[i - 2];
                if (sum > prevSum)
                    cnt++;
                prevSum = sum;
            }

            return cnt;
        }
    }
}
