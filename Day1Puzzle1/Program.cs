// Advent of Code 2023: Day 1 Puzzle 1
// Solution written by: Sam Hassebroek 12/2/23
// Link to puzzle: https://adventofcode.com/2023/day/1

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day1Puzzle1
    {
        static void Main(string[] args)
        {
            try
            {
                // Parse file and instantiate variables for counting
                string textFile = "C:\\Users\\Sam\\Documents\\AoC23\\Day1Puzzle1\\input.txt";
                string[] lines = File.ReadAllLines(textFile);
                int it = 0;
                int total = 0;
                foreach(string line in lines)
                {
                    // Instantiate first and second digit variables
                    char f = '\0';
                    char l = '\0';
                    // Iterate over list, find first digit, starting from beginning
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (f == '\0' && line[i] >= '0' && line[i] <= '9')
                        {
                            f = line[i];
                        }
                    }
                    // Iterate over list, find last digit, starting from end
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        if (l == '\0' && line[i] >= '0' && line[i] <= '9')
                        {
                            l = line[i];
                        }
                    }
                    // If we found two digits (can be the same digit), combine them, parse them, and add them to the total
                    if (f != '\0' && l != '\0')
                    {
                        char[] chars = { f, l };
                        string calVal = new string(chars);
                        int val = Convert.ToInt32(calVal);
                        Console.WriteLine(line + ": " + val);
                        total += val;
                    }
                    else
                    {
                        Console.WriteLine("No digits were found in line: " + line);
                    }
                    it++;
                }
                // Log the total
                Console.WriteLine("Total: " + total);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}