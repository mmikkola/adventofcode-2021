using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day13 : ProblemBase
    {
        public override object Part1(string[] input)
        {
            var dots = new HashSet<(int, int)>(input.
                            TakeWhile(s => !string.IsNullOrWhiteSpace(s)).
                            Select(s => s.Split(',')).
                            Select(n => (int.Parse(n[0]), int.Parse(n[1]))));
            IEnumerable<(char, int)> folds = input
                .Skip(dots.Count() + 1)
                .Select(s => s.Substring(11))
                .Select(s => s.Split('='))
                .Select(n => (n[0][0], int.Parse(n[1])))
                .Take(1);

            return DotsAfterFolds(dots, folds).Count();
        }

        private HashSet<(int, int)> DotsAfterFolds(HashSet<(int, int)> dots, IEnumerable<(char, int)> folds)
        {            
            foreach (var fold in folds)
            {
                dots = ProcessFold(fold.Item1, fold.Item2, dots);
            }

            return dots;
        }

        private HashSet<(int, int)> ProcessFold(char axis, int point, HashSet<(int, int)> dots)
        {
            var newDots = new HashSet<(int, int)>();

            foreach(var dot in dots)
            {
                switch(axis)
                {
                    case 'x':
                        if (dot.Item1 > point)
                            newDots.Add(((2 * point) - dot.Item1, dot.Item2));
                        else
                            newDots.Add(dot);
                        break;
                    case 'y':
                        if (dot.Item2 > point)
                            newDots.Add((dot.Item1, (2 * point) - dot.Item2));
                        else
                            newDots.Add(dot);
                        break;
                }
            }

            return newDots;
        }

        public override object Part2(string[] input)
        {
            var dots = new HashSet<(int, int)>(input.
                 TakeWhile(s => !string.IsNullOrWhiteSpace(s)).
                 Select(s => s.Split(',')).
                 Select(n => (int.Parse(n[0]), int.Parse(n[1]))));
            IEnumerable<(char, int)> folds = input
                .Skip(dots.Count() + 1)
                .Select(s => s.Substring(11))
                .Select(s => s.Split('='))
                .Select(n => (n[0][0], int.Parse(n[1])));
            dots = DotsAfterFolds(dots, folds);

            return RenderDots(dots);
        }

        private static string RenderDots(HashSet<(int, int)> dots)
        {
            int width = dots.Max(d => d.Item1);
            int height = dots.Max(d => d.Item2);

            var sb = new StringBuilder();

            for(int y = 0; y <= height; y++)
            {
                sb.AppendLine();
                for(int x = 0; x <= width; x++)
                {
                    if (dots.Contains((x, y)))
                        sb.Append('█');
                    else
                        sb.Append(' ');
                }
            }    
            
            return sb.ToString();
        }
    }
}
