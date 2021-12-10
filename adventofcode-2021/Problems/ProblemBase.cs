namespace adventofcode_2021.Problems
{
    public abstract class ProblemBase
    {
        protected string[] GetInput()
        {
            string inputFile = $"Inputs/{this.GetType().Name.ToLower()}.txt";
            return System.IO.File.ReadAllLines(inputFile);
        }

        public object Part1()
            => Part1(GetInput());        

        public object Part2()
            => Part2(GetInput());

        public abstract object Part1(string[] input);
        public abstract object Part2(string[] input);
    }
}