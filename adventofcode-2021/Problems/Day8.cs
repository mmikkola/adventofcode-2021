using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day8
    {
        public int Part1(string[] input)
        {
            int ones, fours, sevens, eights;

            ones = fours = sevens = eights = 0;

            foreach(var line in input)
            {
                string output = line.Split('|').Last();
                IEnumerable<string> outputSignals = output.Split(' ');
                ones += outputSignals.Count(sig => sig.Length == 2);
                sevens += outputSignals.Count(sig => sig.Length == 3);
                eights += outputSignals.Count(sig => sig.Length == 7);
                fours += outputSignals.Count(sig => sig.Length == 4);
            }

            return ones + sevens + eights + fours;
        }

        public int Part2(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
