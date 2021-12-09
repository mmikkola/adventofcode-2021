using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day9
    {
        private class HeightMap
        {
            private int[,] heights;

            public HeightMap(IEnumerable<IEnumerable<int>> rows)
            {
                this.heights = new int[rows.First().Count(), rows.Count()];

                int x, y;
                x = y = 0;

                foreach(var row in rows)
                {
                    foreach(var col in row)
                    {
                        heights[x, y] = col;
                        x++;
                    }
                    y++;
                    x = 0;
                }
            }
            private bool IsLowPoint(int x, int y)
            {
                bool top = y == 0 ? true : heights[x, y] < heights[x, y - 1];
                bool bottom = y == heights.GetLength(1) - 1 ? true : heights[x, y] < heights[x, y + 1];
                bool left = x == 0 ? true : heights[x, y] < heights[x - 1, y];
                bool right = x == heights.GetLength(0) - 1 ? true : heights[x, y] < heights[x + 1, y];

                return top && bottom && left && right;
            }

            public int GetSumOfRiskLevels()
            {
                IEnumerable<(int, int)>? lowPoints = GetLowPoints();

                int sum = 0;

                foreach(var point in lowPoints)
                {
                    sum += heights[point.Item1, point.Item2] + 1;
                }

                return sum;
            }

            public IEnumerable<(int, int)> GetLowPoints()
            {
                for (int y = 0; y < heights.GetLength(1); y++)
                {
                    for (int x = 0; x < heights.GetLength(0); x++)
                    {
                        if (IsLowPoint(x, y))
                        {
                            yield return (x, y);
                        }
                    }
                }
            }

            public int FindFlows(HashSet<(int, int)> visited, (int, int) point)
            {
                if (visited.Contains(point))
                    return 0; 
                
                visited.Add(point);

                int size = 0;

                int x = point.Item1; int y = point.Item2;

                if (heights[x, y] == 9)
                    return size;

                if (x > 0)
                    size += FindFlows(visited, (x - 1, y));
                if (y > 0)
                    size += FindFlows(visited, (x, y - 1));
                if (x < heights.GetLength(0) - 1)
                    size += FindFlows(visited, (x + 1, y));
                if (y < heights.GetLength(1) - 1)
                    size += FindFlows(visited, (x, y + 1));

                return ++size;
            }
        }


        public int Part1(string[] input)
        {
            var heightMap = new HeightMap(input.Select(r => r.Select(c => c - '0')));

            return heightMap.GetSumOfRiskLevels();
        }

        public int Part2(string[] input)
        {
            var heightMap = new HeightMap(input.Select(r => r.Select(c => c - '0')));
            var basinSizes = new List<int>();

            IEnumerable<(int, int)> lowPoints = heightMap.GetLowPoints();

            foreach (var lowPoint in lowPoints)
            {
                var visited = new HashSet<(int, int)>();
                int basinSize = 0;

                basinSize += heightMap.FindFlows(visited, lowPoint);

                basinSizes.Add(basinSize);
            }

            return basinSizes.OrderByDescending(i => i).Take(3).Aggregate(1, (acc, val) => acc * val);
        }
    }
}
