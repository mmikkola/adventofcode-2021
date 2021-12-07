// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day7.txt");
var result = (new Day7()).Part2(input);

Console.WriteLine(result);
Console.ReadLine();