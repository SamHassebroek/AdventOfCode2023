// Advent of Code 2023: Day 2 Puzzle 1
// Solution written by: Sam Hassebroek 12/2/23
// Link to puzzle: https://adventofcode.com/2023/day/2

using System;
using System.IO;

namespace AdventOfCode23
{
    class DayXPuzzleY
    {
        static void Main(string[] args)
        {
            int total = 0;
            try
            {
                string textFile = @"C:\Users\Sam\Documents\AoC23\Day2Puzzle1\input.txt";
                string[] lines = File.ReadAllLines(textFile);
                int actualRed = 12;
                int actualGreen = 13;
                int actualBlue = 14;

                foreach (string line in lines)
                {
                    string gameString = line.Split(": ")[0];
                    int game = int.Parse(gameString.Substring(5));
                    string[] hintStrings = line.Split(": ")[1].Split("; ");
                    bool possible = true;
                    foreach (string hint in hintStrings)
                    {
                        int hintRed = 0;
                        int hintGreen = 0;
                        int hintBlue = 0;
                        string[] colors = hint.Split(", ");
                        foreach (string color in colors)
                        {
                            string number = color.Split(" ")[0];
                            string c = color.Split(" ")[1];
                            if ("red".Equals(c))
                            {
                                hintRed = Convert.ToInt32(number);
                            } else if ("blue".Equals(c))
                            {
                                hintBlue = Convert.ToInt32(number);
                            } else if ("green".Equals(c))
                            {
                                hintGreen = Convert.ToInt32(number);
                            }
                        }
                        if (hintRed > actualRed || hintGreen > actualGreen || hintBlue > actualBlue)
                        {
                            possible = false;
                            break;
                        }
                    }
                    if (possible)
                    {
                        Console.WriteLine("Game " + game + ": " + "Possible");
                        total += game;
                    } else
                    {
                        Console.WriteLine("Game " + game + ": " + "Impossible");
                    }
                }
            } catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Total: " + total);
        }
    }
}