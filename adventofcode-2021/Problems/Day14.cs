using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day14 : ProblemBase
    {                
        public override object Part1(string[] input)
        {
            return Polymerize(input, 10);
        }

        private long Polymerize(string[] input, int steps)
        {
            string template = input.First();

            IDictionary<string, string> insertionRules =
                input.Skip(2)
                .Select(x => x.Split(" -> "))
                .ToDictionary(x => x[0], x => x[1]);

            IDictionary<char, long> occurances = FindElements(template, insertionRules, 0, steps - 1);

            return occurances.Max(kvp => kvp.Value) - occurances.Min(kvp => kvp.Value);
        }

        private IDictionary<char, long> FindElements(string template, IDictionary<string, string> insertionRules, int currentDepth, int maxDepth)
        {           
            var occurances = new Dictionary<char, long>();

            if (currentDepth > maxDepth)
            {
                foreach(char c in template)
                {
                    if(occurances.ContainsKey(c))
                        occurances[c]++;
                    else
                        occurances[c] = 1;
                }

                return occurances;
            }

            for (int i = 1; i < template.Length; i++)
            {
                string element = template.Substring(i - 1, 2);

                string toInsert = insertionRules[element];

                string newElement = $"{element[0]}{toInsert}{element[1]}";

                var subOccurances = FindElements(newElement, insertionRules, currentDepth + 1, maxDepth);

                foreach (var kvp in subOccurances)
                {
                    if (occurances.ContainsKey(kvp.Key))
                        occurances[kvp.Key] += kvp.Value;
                    else
                        occurances[kvp.Key] = kvp.Value;
                }

                if (i < template.Length - 1)
                    occurances[element[1]]--;
            }

            return occurances;
        }

        public override object Part2(string[] input)
        {
            return Polymerize(input, 40);
        }
    }
}
