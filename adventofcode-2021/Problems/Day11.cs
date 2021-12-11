using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day11 : ProblemBase
    {
        private class OctopusGrid
        {
            private int[,] octopi;
            public int Flashes { get; private set; }            
            public int Size { get => octopi.Length; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (int y = 0; y < octopi.GetLength(1); y++)
                {
                    for (int x = 0; x < octopi.GetLength(0); x++)
                    {
                        int level = octopi[x, y];
                        if (level < 0)
                            sb.Append("N");
                        else if (level < 10)
                            sb.Append(level);
                        else
                            sb.Append('X');
                    }

                    sb.AppendLine();
                }

                return sb.ToString();
            }

            public OctopusGrid(int[,] initialEnergyLEvels)
            {
                octopi = initialEnergyLEvels;
                Flashes = 0;
            }            

            public void RunSingleStep()
            {
                IncreaseEnergyLevels();

                IEnumerable<(int, int)> octopiReadyToFlash = GetOctopiReadyToFlash();
                while (octopiReadyToFlash.Any())
                {
                    FlashOctopi(octopiReadyToFlash);
                    octopiReadyToFlash = GetOctopiReadyToFlash();
                }

                SetFlashedToZero();
            }

            private void SetFlashedToZero()
            {
                for (int y = 0; y < octopi.GetLength(1); y++)
                    for (int x = 0; x < octopi.GetLength(0); x++)
                        if (this.octopi[x, y] < 0)
                            this.octopi[x, y] = 0;
            }

            private IEnumerable<(int, int)> GetOctopiReadyToFlash()
            {
                for (int y = 0; y < octopi.GetLength(1); y++)
                    for (int x = 0; x < octopi.GetLength(0); x++)
                        if(this.octopi[x,y] > 9)
                            yield return (x,y);
            }

            private void FlashOctopi(IEnumerable<(int, int)> octopi)
            {
                foreach(var octopus in octopi)
                {
                    Flashes++;
                    this.octopi[octopus.Item1, octopus.Item2] = -1;

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        int x = octopus.Item1 + dx;
                        if (x >= 0 && x < this.octopi.GetLength(0))
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                int y = octopus.Item2 + dy;
                                if(y >= 0 && y < this.octopi.GetLength(1))
                                {
                                    if(this.octopi[x, y] > 0)
                                        this.octopi[x, y]++;
                                }
                            }
                        }
                    }
                }
            }

            private void IncreaseEnergyLevels()
            {
                for (int y = 0; y < octopi.GetLength(1); y++)
                    for (int x = 0; x < octopi.GetLength(0); x++)
                        octopi[x, y]++;
            }
        }

        public override object Part1(string[] input)
        {            
            int[,] initialReadings = ParseInput(input);

            var grid = new OctopusGrid(initialReadings);

            for (int i = 0; i < 100; i++)
                grid.RunSingleStep();

            return grid.Flashes;
        }

        private static int[,] ParseInput(string[] input)
        {
            int height = input.Length;
            int width = input[0].Length;
            var initialReadings = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    initialReadings[x, y] = input[y][x] - '0';
                }
            }

            return initialReadings;
        }

        public override object Part2(string[] input)
        {
            int[,] initialReadings = ParseInput(input);

            var grid = new OctopusGrid(initialReadings);

            int flashesLastIteration = 0;
            int iterations = 0;
            while(grid.Flashes - flashesLastIteration != grid.Size)
            {
                flashesLastIteration = grid.Flashes;
                grid.RunSingleStep();
                iterations++;
            }

            return iterations;
        }
    }
}
