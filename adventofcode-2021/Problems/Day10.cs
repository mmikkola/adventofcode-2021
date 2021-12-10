using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day10
    {
        public int Part1(string[] input)
        {
            var openStack = new Stack<char>();

            int score = 0;

            foreach(string line in input)
            {
                foreach(char symbol in line)
                {
                    if("([{<".Contains(symbol))
                    {
                        openStack.Push(symbol);
                    }
                    else
                    {
                        char lastOpen = openStack.Pop();
                        switch(symbol)
                        {
                            case ')':
                                if (lastOpen != '(')
                                    score += 3;
                                break;
                            case ']':
                                if (lastOpen != '[')
                                    score += 57;
                                break;
                            case '}':
                                if (lastOpen != '{')
                                    score += 1197;
                                break;
                            case '>':
                                if (lastOpen != '<')
                                    score += 25137;
                                break;
                        }
                    }
                }
            }

            return score;
        }

        public long Part2(string[] input)
        {
            var scores = ScoreIncompleteLines(input);

            var orderedScores = scores.OrderBy(s => s);

            return orderedScores.ElementAt(scores.Count() / 2);
        }

        private static IEnumerable<long> ScoreIncompleteLines(string[] input)
        {
            foreach (string line in input)
            {
                var openStack = new Stack<char>();
                bool incomplete = true;

                foreach (char symbol in line)
                {
                    if ("([{<".Contains(symbol))
                    {
                        openStack.Push(symbol);
                    }
                    else
                    {
                        char lastOpen = openStack.Pop();
                        switch (symbol)
                        {
                            case ')':
                                if (lastOpen != '(')
                                    incomplete = false;
                                break;
                            case ']':
                                if (lastOpen != '[')
                                    incomplete = false;
                                break;
                            case '}':
                                if (lastOpen != '{')
                                    incomplete = false;
                                break;
                            case '>':
                                if (lastOpen != '<')
                                    incomplete = false;
                                break;
                        }
                    }
                }

                if (incomplete)
                {
                    long score = 0;
                    char closingBracket;
                    while(openStack.TryPop(out closingBracket))
                    {
                        switch(closingBracket)
                        {
                            case '(':
                                score = (score * 5) + 1;
                                break;
                            case '[':
                                score = (score * 5) + 2;
                                break;
                            case '{':
                                score = (score * 5) + 3;
                                break;
                            case '<':
                                score = (score * 5) + 4;
                                break;
                        }
                    }
                    
                    yield return score;
                }

            }
        }
    }
}
