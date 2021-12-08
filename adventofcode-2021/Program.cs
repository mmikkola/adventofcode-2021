// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day8.txt");
var result = (new Day8()).Part1(input);

Console.WriteLine(result);
Console.ReadLine();