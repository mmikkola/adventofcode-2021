using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day7
    {
        public int Part1(string[] args)
        {
            int[] crabs = args[0].Split(',').Select(int.Parse).ToArray();

            int[] distanceCosts = new int[crabs.Max()];

            for(int i = 0; i < crabs.Max(); i++)
            {
                foreach(int crab in crabs)
                {
                    distanceCosts[i] += Math.Abs(crab - i); 
                }
            }

            return distanceCosts.Min();
        }

        public int Part2(string[] args)
        {
            int[] crabs = args[0].Split(',').Select(int.Parse).ToArray();

            int[] distanceCosts = new int[crabs.Max()];

            for (int i = 0; i < crabs.Max(); i++)
            {
                foreach (int crab in crabs)
                {
                    distanceCosts[i] += CalculateFuelCost(crab, i);
                }
            }

            return distanceCosts.Min();
        }

        private int CalculateFuelCost(int from, int to)
        {
            int distance = Math.Abs(from - to);

            int cost = 0;

            for(int i = 1; i <= distance; i++)
            {
                cost += i;
            }

            return cost;
        }
    }
}
