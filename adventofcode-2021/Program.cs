﻿// See https://aka.ms/new-console-template for more information
using adventofcode_2021.Problems;

var input = File.ReadAllLines("Inputs/day10.txt");
var day = new Day10();
var timer = System.Diagnostics.Stopwatch.StartNew();
try
{
    var part1 = day.Part1(input);
    long elapsed = timer.ElapsedMilliseconds;
    Console.WriteLine($"Solved Part 1 in {elapsed}ms. Result: {part1}");
} catch { }
timer.Restart();
try
{
    var part2 = day.Part2(input);
    long elapsed = timer.ElapsedMilliseconds;
    Console.WriteLine($"Solved Part 2 in {elapsed}ms. Result: {part2}");
}
catch { }