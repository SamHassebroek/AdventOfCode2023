// Advent of Code 2023: Day 1 Puzzle 2
// Solution written by: Sam Hassebroek 12/2/23
// Link to puzzle: https://adventofcode.com/2023/day/1#part2 (Unlocked after part 1 is completed)

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day1Puzzle2
    {
        static void Main(string[] args)
        {
            try
            {
                // Parse file and instantiate variables for counting
                string textFile = "C:\\Users\\Sam\\Documents\\AoC23\\Day1Puzzle2\\input.txt";
                string text = File.ReadAllText(textFile);
                string[] lines = File.ReadAllLines(textFile);
                int it = 0;
                int total = 0;
                foreach (string line in lines)
                {
                    // Instatiate first and last digit variables
                    char f = '\0';
                    char l = '\0';
                    // Search for first digit, starting from the beginning of the string
                    for (int i = 0; f == -1 && i < line.Length; i++)
                    {
                        f = parseStringFromIndex(line, i);
                    }
                    // Search for last digit, starting from the end of the string
                    for (int i = line.Length - 1; l == -1 && i >= 0; i--)
                    {
                        l = parseStringFromIndex(line, i);
                    }
                    // If two digits were found (can be the same digit), combine, parse, and add to total
                    if (f != -1 && l != -1)
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
                // Output total
                Console.WriteLine("Total: " + total);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static char parseStringFromIndex(string line, int index)
        {
            switch (line[index])
            {
                // Parsing digit numbers is straightforward, just return the number

                case '0':
                    return '0';
                case '1':
                    return '1';
                case '2':
                    return '2';
                case '3':
                    return '3';
                case '4':
                    return '4';
                case '5':
                    return '5';
                case '6':
                    return '6';
                case '7':
                    return '7';
                case '8':
                    return '8';
                case '9':
                    return '9';

                // Parsing String-form Numbers
                // Methodology:
                // For any given potential number (given the starting character):
                //  1. Check if there is space for the word
                //  2. Check if the substring that would be occupied by the word equals the word we're checking for
                //  3. If it matches the word, return the corresponding number

                // potential one
                case 'o':
                    if (line.Length > index + 2 && "one".Equals(line.Substring(index, 3)))
                    {
                        return '1';
                    }
                    return '\0';
                // potential two or three
                case 't':
                    if (line.Length > index + 2 && "two".Equals(line.Substring(index, 3)))
                    {
                        return '2';
                    } else if (line.Length > index + 4 && "three".Equals(line.Substring(index, 5)))
                    {
                        return '3';
                    }
                    return '\0';
                // potential four or five
                case 'f':
                    if (line.Length > index + 3 && "four".Equals(line.Substring(index, 4)))
                    {
                        return '4';
                    }
                    else if (line.Length > index + 3 && "five".Equals(line.Substring(index, 4)))
                    {
                        return '5';
                    }
                    return '\0';
                // potential six or seven
                case 's':
                    if (line.Length > index + 2 && "six".Equals(line.Substring(index, 3)))
                    {
                        return '6';
                    }
                    else if (line.Length > index + 4 && "seven".Equals(line.Substring(index, 5)))
                    {
                        return '7';
                    }
                    return '\0';
                // potential eight
                case 'e':
                    if (line.Length > index + 4 && "eight".Equals(line.Substring(index, 5)))
                    {
                        return '8';
                    }
                    return '\0';
                // potential nine
                case 'n':
                    if (line.Length > index + 3 && "nine".Equals(line.Substring(index, 4)))
                    {
                        return '9';
                    }
                    return '\0';
                default:
                    return '\0';
            }
        }
    }
}