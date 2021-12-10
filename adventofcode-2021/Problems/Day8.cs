using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day8 : ProblemBase
    {
        public override object Part1(string[] input)
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

        public override object Part2(string[] input)
        {
            var patternToValue = new Dictionary<string, int>()
            {
                { "abcefg", 0 },
                { "cf", 1 },
                { "acdeg", 2 },
                { "acdfg", 3 },                
                { "bcdf", 4 },
                { "abdfg", 5},
                { "abdefg", 6 },
                { "acf", 7 },
                { "abcdefg", 8 },
                { "abcdfg", 9 }
            };

            int outputSum = 0;

            foreach(var line in input)
            {
                var signalToSegment = new Dictionary<char, char>();
                IEnumerable<string> inputs = line.Split('|').First().Split(' ');
                char aSignal = GetASignal(inputs);
                signalToSegment[aSignal] = 'a';
                char eSignal = GetESignal(inputs);
                signalToSegment[eSignal] = 'e';
                char gSignal = GetGSignal(inputs, eSignal, aSignal);
                signalToSegment[gSignal] = 'g';
                char bSignal = GetBSignal(inputs, aSignal, eSignal, gSignal);
                signalToSegment[bSignal] = 'b';
                char fSignal = GetFSignal(inputs, signalToSegment.Keys);
                signalToSegment[fSignal] = 'f';
                char dSignal = GetDSignal(inputs, signalToSegment.Keys);
                signalToSegment[dSignal] = 'd';
                char cSignal = GetCSignal(inputs, signalToSegment.Keys);
                signalToSegment[cSignal] = 'c';

                int outputValue = 0;
                IEnumerable<string> outputs = line.Split('|').Last().Split(' ').Where(s => !string.IsNullOrEmpty(s));

                outputValue += 1000 * patternToValue[FixSignals(outputs.ElementAt(0), signalToSegment)];
                outputValue += 100 * patternToValue[FixSignals(outputs.ElementAt(1), signalToSegment)];
                outputValue += 10 * patternToValue[FixSignals(outputs.ElementAt(2), signalToSegment)];
                outputValue += patternToValue[FixSignals(outputs.ElementAt(3), signalToSegment)];

                outputSum += outputValue;
            }


            return outputSum;
        }

        private static string FixSignals(string signals, Dictionary<char, char> signalToSegment)
        {
            return string.Concat(signals.Select(c => signalToSegment[c]).OrderBy(c => c));
        }

        private static char GetASignal(IEnumerable<string> inputs)
        {            
            IEnumerable<char> oneSignals = inputs.First(i => i.Length == 2);
            IEnumerable<char> sevenSignals = inputs.First(i => i.Length == 3);

           return sevenSignals
                .Except(oneSignals)
                .Single();
        }

        private static char GetESignal(IEnumerable<string> inputs)
        {
            IEnumerable<char> oneSignals = inputs.First(i => i.Length == 2);
            IEnumerable<char> fourSignal = inputs.First(i => i.Length == 4);

            IEnumerable<char> bAndG = fourSignal.Except(oneSignals);

            IEnumerable<char> twoThreeFive = string.Concat(inputs.Where(i => i.Length == 5));

            char eSignal = twoThreeFive
                .Where(c => !bAndG.Contains(c))
                .GroupBy(c => c)
                .Single(x => x.Count() == 1)
                .Key;

            return eSignal;
        }

        private static char GetGSignal(IEnumerable<string> inputs, char eSignal, char aSignal)
        {
            IEnumerable<char> oneSignals = inputs.First(i => i.Length == 2);
            IEnumerable<char> fourSignal = inputs.First(i => i.Length == 4);
            IEnumerable<char> eightSignals = inputs.First(i => i.Length == 7);

            return eightSignals
                .Where(c => !fourSignal.Contains(c))
                .Where(c => !oneSignals.Contains(c))
                .GroupBy(c => c)
                .Where(c => c.Count() == 1)
                .Single(c => c.Key != eSignal && c.Key != aSignal)
                .Key;
        }

        private static char GetBSignal(IEnumerable<string> inputs, char aSignal, char eSignal, char gSignal)
        {
            IEnumerable<char> twoThreeFive = string.Concat(inputs.Where(i => i.Length == 5));

            var except = new HashSet<char>() { aSignal, gSignal, eSignal };

            return twoThreeFive
                .Where(c => !except.Contains(c))
                .GroupBy(c => c)
                .Single(x => x.Count() == 1)
                .Key;
        }

        private static char GetFSignal(IEnumerable<string> inputs, IEnumerable<char> solvedInputs)
        {
            IEnumerable<char> zeroSixNine = string.Concat(inputs.Where(i => i.Length == 6));

            return zeroSixNine
                .Where(c => !solvedInputs.Contains(c))
                .GroupBy(c => c)
                .Single(x => x.Count() == 3)
                .Key;
        }

        private static char GetDSignal(IEnumerable<string> inputs, IEnumerable<char> solvedInputs)
        {
            IEnumerable<char> twoThreeFive = string.Concat(inputs.Where(i => i.Length == 5));

            return twoThreeFive
                .Where(c => !solvedInputs.Contains(c))
                .GroupBy(c => c)
                .Single(x => x.Count() == 3)
                .Key;
        }

        private static char GetCSignal(IEnumerable<string> inputs, IEnumerable<char> solvedInputs)
        {
            string eight = inputs.Single(c => c.Length == 7);

            return eight
                .Single(c => !solvedInputs.Contains(c));
        }
    }
}
