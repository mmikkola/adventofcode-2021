// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

int day;
if (args.Length == 0 || !int.TryParse(args[0], out day))
    day = DateTime.Now.Day;

var asm = System.Reflection.Assembly.GetExecutingAssembly().GetName();
var problem = (ProblemBase)Activator.CreateInstance(asm.Name, $"adventofcode_2021.Problems.Day{day}").Unwrap();

Console.WriteLine($"Running for day {day}");

var timer = System.Diagnostics.Stopwatch.StartNew();
try
{
    var part1 = problem.Part1();
    long elapsed = timer.ElapsedMilliseconds;
    Console.WriteLine($"Solved Part 1 in {elapsed}ms. Result: {part1}");
} catch { }
timer.Restart();
try
{
    var part2 = problem.Part2();
    long elapsed = timer.ElapsedMilliseconds;
    Console.WriteLine($"Solved Part 2 in {elapsed}ms. Result: {part2}");
}
catch { }