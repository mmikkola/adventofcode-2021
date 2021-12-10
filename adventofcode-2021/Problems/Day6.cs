using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day6 : ProblemBase
    {
        private class LanternFishColony
        {
            private long[] fishWithDaysLeftUntilSpawn;

            public LanternFishColony(IEnumerable<int> initialFish)
            {
                fishWithDaysLeftUntilSpawn = new long[9];
                foreach(var fish in initialFish)
                {
                    fishWithDaysLeftUntilSpawn[fish]++;
                }
            }

            public long GetTotalFish()
            {
                return fishWithDaysLeftUntilSpawn.Sum();
            }

            public void SimulateDays(int days)
            {
                for(int i = 0; i < days; i++)
                {
                    SimulateDay();
                }
            }

            public void SimulateDay()
            {
                long spawningFish = fishWithDaysLeftUntilSpawn[0];
                for (int i = 0; i < 8; i++)
                {
                    fishWithDaysLeftUntilSpawn[i] = fishWithDaysLeftUntilSpawn[i + 1];
                }

                fishWithDaysLeftUntilSpawn[6] += spawningFish;
                fishWithDaysLeftUntilSpawn[8] = spawningFish;
            }
        }

        public override object Part1(string[] args)
        {
            var initialFish = args[0].Split(',').Select(int.Parse);
            
            var colony = new LanternFishColony(initialFish);
            colony.SimulateDays(80);
            return colony.GetTotalFish();
        }

        public override object Part2(string[] args)
        {
            var initialFish = args[0].Split(',').Select(int.Parse);
            var colony = new LanternFishColony(initialFish);
            colony.SimulateDays(256);
            return colony.GetTotalFish();
        }
    }
}
