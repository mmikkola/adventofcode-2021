// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day1.txt");
var result = (new Day1()).Part2(input);

Console.WriteLine(result);
Console.ReadLine();