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
                int riskSum = 0;

                for(int y = 0; y < heights.GetLength(1); y++)
                {
                    for(int x = 0; x < heights.GetLength(0); x++)
                    {
                        if(IsLowPoint(x, y))
                        {
                            riskSum += 1 + heights[x, y];
                        }
                    }
                }

                return riskSum;
            }
        }


        public int Part1(string[] input)
        {
            var heightMap = new HeightMap(input.Select(r => r.Select(c => c - '0')));

            return heightMap.GetSumOfRiskLevels();
        }

        public int Part2(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
