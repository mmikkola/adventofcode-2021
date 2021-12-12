using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Problems
{
    public class Day12 : ProblemBase
    {
        private abstract class Cave
        {
            private List<Cave> neighbours;

            public string Name { get; private set; }

            public Cave(string name)
            {
                this.Name = name;
                this.neighbours = new List<Cave>();
            }

            public void AddNeighbour(Cave cave)
            {
                neighbours.Add(cave);
            }

            public List<Queue<Cave>> FindAllPathsTo(Cave cave, HashSet<Cave> visited)
            {
                if(visited.Contains(this))
                    return new List<Queue<Cave>>();
                if (this is SmallCave)
                    visited.Add(this);

                if(this == cave)
                {
                    var q = new Queue<Cave>();
                    q.Enqueue(this);
                    return new List<Queue<Cave>>() { q };
                }

                var paths = new List<Queue<Cave>>();

                foreach(var n in neighbours)
                {
                    foreach (var p in n.FindAllPathsTo(cave, new HashSet<Cave>(visited)))
                    {
                        p.Enqueue(this);
                        paths.Add(p);
                    }
                }

                return paths;
            }
        }

        private class SmallCave : Cave
        {
            public SmallCave(string name) : base(name)
            {
            }
        }

        private class LargeCave : Cave
        {
            public LargeCave(string name) : base(name)
            {
            }
        }

        public override object Part1(string[] input)
        {
            Dictionary<string, Cave> vertices = ParseInput(input);

            Cave start = vertices["start"];

            List<Queue<Cave>> paths = start.FindAllPathsTo(vertices["end"], new HashSet<Cave>());

            return paths.Count();
        }

        public override object Part2(string[] input)
        {
            Dictionary<string, Cave> vertices = ParseInput(input);

            Cave start = vertices["start"];


            return -1;
        }

        private static Dictionary<string, Cave> ParseInput(string[] input)
        {
            var vertices = new Dictionary<string, Cave>();
            foreach (string edge in input)
            {
                string vertex1 = edge.Split('-')[0];
                string vertex2 = edge.Split('-')[1];

                if (!vertices.ContainsKey(vertex1))
                    vertices.Add(vertex1, char.IsLower(vertex1[0]) ? new SmallCave(vertex1) : new LargeCave(vertex1));
                if (!vertices.ContainsKey(vertex2))
                    vertices.Add(vertex2, char.IsLower(vertex2[0]) ? new SmallCave(vertex2) : new LargeCave(vertex2));

                vertices[vertex1].AddNeighbour(vertices[vertex2]);
                vertices[vertex2].AddNeighbour(vertices[vertex1]);
            }

            return vertices;
        }
    }
}
