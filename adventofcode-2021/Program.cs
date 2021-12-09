// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day9.txt");
var result = (new Day9()).Part1(input);

Console.WriteLine(result);
Console.ReadLine();