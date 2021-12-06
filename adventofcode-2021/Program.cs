// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day6.txt");
var result = (new Day6()).Part2(input);

Console.WriteLine(result);
Console.ReadLine();