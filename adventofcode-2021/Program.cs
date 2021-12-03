// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day3.txt");
var result = (new Day3()).Part2(input);

Console.WriteLine(result);
Console.ReadLine();