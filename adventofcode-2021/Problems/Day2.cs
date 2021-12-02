using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day2
    {
        public int Part1(string[] input)
        {
            int position = 0;
            int depth = 0;

            foreach(var item in input)
            {

                string[] values = item.Split(' ');
                string direction = values[0];
                int units = int.Parse(values[1]);

                switch(direction)
                {
                    case "forward":
                        position += units;
                        break;
                    case "down":
                        depth += units;
                        break;
                    case "up":
                        depth -= units;
                        break;
                    default:
                        break;
                }                
            }

            return position * depth;
        }

        public int Part2(string[] input)
        {
            int position = 0;
            int depth = 0;
            int aim = 0;

            foreach (var item in input)
            {

                string[] values = item.Split(' ');
                string direction = values[0];
                int units = int.Parse(values[1]);

                switch (direction)
                {
                    case "forward":
                        position += units;
                        depth += (units * aim);
                        break;
                    case "down":
                        aim += units;
                        break;
                    case "up":
                        aim -= units;
                        break;
                    default:
                        break;
                }
            }

            return position * depth;
        }
    }
}
