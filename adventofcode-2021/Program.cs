// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var daysToRun = new List<int>();

if (args.Length > 0)
{    
    if(args[0].Equals("all"))
    {
        int today = DateTime.Now.Day;
        daysToRun.AddRange(Enumerable.Range(1, today));
    }
    else if(int.TryParse(args[0], out int day))
    {
        daysToRun.Add(day);
    }
}
else
{
    daysToRun.Add(DateTime.Now.Day);
}


var asm = System.Reflection.Assembly.GetExecutingAssembly().GetName();

foreach (int day in daysToRun)
{
    var problem = (ProblemBase)Activator.CreateInstance(asm.Name, $"adventofcode_2021.Problems.Day{day}").Unwrap();

    var timer = System.Diagnostics.Stopwatch.StartNew();
    try
    {
        var part1 = problem.Part1();
        long elapsed = timer.ElapsedMilliseconds;
        Console.WriteLine($"Solved Day {day} Part 1 in {elapsed}ms. Result: {part1}");
    }
    catch { }
    timer.Restart();
    try
    {
        var part2 = problem.Part2();
        long elapsed = timer.ElapsedMilliseconds;
        Console.WriteLine($"Solved Day {day} Part 2 in {elapsed}ms. Result: {part2}");
    }
    catch { }
}