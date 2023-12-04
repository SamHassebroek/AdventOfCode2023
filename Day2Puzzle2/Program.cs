// Advent of Code 2023: Day 2 Puzzle 2
// Solution written by: Sam Hassebroek 12/2/23
// Link to puzzle: https://adventofcode.com/2023/day/2#part2 (unlocks after part 1 is completed)

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day2Puzzle2
    {
        static void Main(string[] args)
        {
            int total = 0;
            try
            {
                // Prep file input
                string textFile = @"C:\Users\Sam\Documents\AoC23\Day2Puzzle2\input.txt";
                string[] lines = File.ReadAllLines(textFile);

                foreach (string line in lines)
                {
                    // For each line, find the minimum of cubes needed to make the game possible (local maximum)
                    int minRed = -1;
                    int minGreen = -1;
                    int minBlue = -1;
                    string gameString = line.Split(": ")[0];
                    int game = int.Parse(gameString.Substring(5));
                    string[] hintStrings = line.Split(": ")[1].Split("; ");
                    foreach (string hint in hintStrings)
                    {
                        int hintRed = -1;
                        int hintGreen = -1;
                        int hintBlue = -1;
                        string[] colors = hint.Split(", ");
                        foreach (string color in colors)
                        {
                            string number = color.Split(" ")[0];
                            string c = color.Split(" ")[1];
                            if ("red".Equals(c))
                            {
                                hintRed = Convert.ToInt32(number);
                            }
                            else if ("blue".Equals(c))
                            {
                                hintBlue = Convert.ToInt32(number);
                            }
                            else if ("green".Equals(c))
                            {
                                hintGreen = Convert.ToInt32(number);
                            }
                        }
                        if (hintRed > minRed)
                        {
                            minRed = hintRed;
                        }
                        if (hintGreen > minGreen)
                        {
                            minGreen = hintGreen;
                        }
                        if (hintBlue > minBlue)
                        {
                            minBlue = hintBlue;
                        }
                    }
                    // Calculate the power and add to total
                    int power = Math.Abs(minRed * minBlue * minGreen);
                    Console.WriteLine("Game " + game + " Power: " + power + " (Red: " + minRed + "; Green: " + minGreen + "; Blue: " + minBlue + ")");
                    total += power;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Display total
            Console.WriteLine("Total: " + total);
        }
    }
}