using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day14 : ProblemBase
    {
        private class Polymerizer
        {
            private IDictionary<string, string> insertionRules;
            private string template;
            private Dictionary<(string, int), IDictionary<char, long>> sequenceCache;

            public Polymerizer(string[] input)
            {
                sequenceCache = new Dictionary<(string, int), IDictionary<char, long>>();

                insertionRules =
                    input.Skip(2)
                    .Select(x => x.Split(" -> "))
                    .ToDictionary(x => x[0], x => x[1]);

                template = input.First();
            }

            public IDictionary<char, long> FindElements(int maxDepth)
            {
                return FindElements(template, 0, maxDepth - 1);
            }

            private IDictionary<char, long> FindElements(string template, int currentDepth, int maxDepth)
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

                    IDictionary<char, long> subOccurances;

                    if(!sequenceCache.TryGetValue((newElement, currentDepth), out subOccurances))
                    {
                        subOccurances = FindElements(newElement, currentDepth + 1, maxDepth);
                        sequenceCache[(newElement, currentDepth)] = subOccurances;
                    }

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
        }


        public override object Part1(string[] input)
        {
            var polymerizer = new Polymerizer(input);

            var occurances = polymerizer.FindElements(10);

            return occurances.Max(kvp => kvp.Value) - occurances.Min(kvp => kvp.Value);
        }

        public override object Part2(string[] input)
        {
            var polymerizer = new Polymerizer(input);

            var occurances = polymerizer.FindElements(40);

            return occurances.Max(kvp => kvp.Value) - occurances.Min(kvp => kvp.Value);
        }
    }
}
