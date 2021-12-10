using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day5 : ProblemBase
    {
        private struct Point
        {
            public int X;
            public int Y;
        }

        private Point Sub(Point a, Point b)
        {
            return new Point() { X = a.X - b.X, Y = a.Y - b.Y };
        }

        private IEnumerable<Point> Parse(string input, bool onlyStraightVents)
        {
            var points = new List<Point>();
            var coords = input.Split(" -> ").Select(p => new Point() { X = int.Parse(p.Split(',')[0]), Y = int.Parse(p.Split(',')[1]) });

            Point pointA = coords.First();
            Point pointB = coords.Last();


            if (onlyStraightVents && (pointA.X != pointB.X && pointA.Y != pointB.Y))
                return points;

            int startX = Math.Min(pointA.X, pointB.X);

            Point travel = Sub(pointA, pointB);

            points.Add(pointB);

            Point location = new Point() { X = pointB.X, Y = pointB.Y };

            while(travel.X != 0 || travel.Y != 0)
            {
                if(travel.X > 0)
                {
                    location.X++;
                    travel.X--;
                }
                if(travel.Y > 0)
                {
                    location.Y++;
                    travel.Y--;
                }
                if(travel.X < 0)
                {
                    location.X--;
                    travel.X++;
                }
                if(travel.Y < 0)
                {
                    location.Y--;
                    travel.Y++;
                }

                points.Add(new Point() { X = location.X, Y = location.Y });
            }

            return points;
        }
        private int FindOverlaps(string[] input, bool onlyStraightVents)
        {
            var overlaps = new Dictionary<Point, int>();

            foreach (string vent in input)
            {
                var points = Parse(vent, onlyStraightVents);
                foreach (var point in points)
                {
                    if (overlaps.ContainsKey(point))
                    {
                        overlaps[point]++;
                    }
                    else
                    {
                        overlaps[point] = 1;
                    }
                }
            }

            return overlaps.Count(kvp => kvp.Value > 1);
        }

        public override object Part1(string[] input)
        {
            return FindOverlaps(input, true);
        }


        public override object Part2(string[] input)
        {
            return FindOverlaps(input, false);
        }
    }
}
