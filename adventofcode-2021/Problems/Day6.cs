using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day6
    {

        private class LanternFish
        {
            private int daysUntilSpawn;
            public int DaysUntilSpawn => daysUntilSpawn;
           
            public LanternFish(int initialDaysUntilSpawn)
            {
                daysUntilSpawn = initialDaysUntilSpawn;
            }

            public LanternFish() : this(8) { }

            public LanternFish SpendDay()
            {
                if(daysUntilSpawn == 0)
                {
                    daysUntilSpawn = 6;
                    return new LanternFish();
                }
                else
                {
                    daysUntilSpawn--;
                    return null;
                }
            }
        }

        private class LanternFishColony
        {
            private Dictionary<int, long> fishWithDaysLeftUntilSpawn;

            public LanternFishColony(IEnumerable<LanternFish> initialFish)
            {
                fishWithDaysLeftUntilSpawn = new Dictionary<int, long>();
                foreach(var fish in initialFish)
                {
                    AddFish(fish.DaysUntilSpawn);
                }
            }

            public long GetTotalFish()
            {
                return fishWithDaysLeftUntilSpawn.Values.Sum();
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
                long spawningFish = fishWithDaysLeftUntilSpawn.ContainsKey(0) ? fishWithDaysLeftUntilSpawn[0] : 0;
                for (int i = 0; i < 8; i++)
                {
                    fishWithDaysLeftUntilSpawn[i] = fishWithDaysLeftUntilSpawn.ContainsKey(i + 1) ? fishWithDaysLeftUntilSpawn[i + 1] : 0;
                }

                fishWithDaysLeftUntilSpawn[6] += spawningFish;
                fishWithDaysLeftUntilSpawn[8] = spawningFish;
            }                        

            private void AddFish(int daysUntilSpawn)
            {
                if(fishWithDaysLeftUntilSpawn.ContainsKey(daysUntilSpawn))
                    fishWithDaysLeftUntilSpawn[daysUntilSpawn]++;
                else
                    fishWithDaysLeftUntilSpawn[daysUntilSpawn] = 1;
            }
        }

        private IEnumerable<LanternFish> SimulateDays(IEnumerable<LanternFish> initialPopulation, int days)
        {

            var allFish = new List<LanternFish>(initialPopulation);

            for(int i = 0; i < days; i++)
            {
                var newFish = new List<LanternFish>();
                foreach(var fish in allFish)
                {
                    var spawn = fish.SpendDay();
                    if(spawn != null)
                        newFish.Add(spawn);
                }

                allFish.AddRange(newFish);
            }

            return allFish;
        }

        public long Part1(string[] args)
        {
            var initialFish = args[0].Split(',').Select(d => new LanternFish(int.Parse(d)));
            
            var colony = new LanternFishColony(initialFish);
            colony.SimulateDays(80);
            return colony.GetTotalFish();
        }

        public long Part2(string[] args)
        {
            var initialFish = args[0].Split(',').Select(d => new LanternFish(int.Parse(d)));
            var colony = new LanternFishColony(initialFish);
            colony.SimulateDays(256);
            return colony.GetTotalFish();
        }
    }
}
