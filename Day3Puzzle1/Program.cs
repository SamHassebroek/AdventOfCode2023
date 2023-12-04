// Advent of Code 2023: Day 3 Puzzle 1
// Solution written by: Sam Hassebroek 12/3/23
// Link to puzzle: https://adventofcode.com/2023/day/3

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day3Puzzle1
    {

        static void Main(string[] args)
        {
            // Prep file input
            string textFile = @"C:\Users\Sam\Documents\AoC23\Day3Puzzle1\input.txt";
            string[] lines = File.ReadAllLines(textFile);

            bool DEBUG = false;
            int total = 0;

            // Go through schematic, adding up the part numbers
            // For each line, add all part numbers to total
            //   Iterate over the string, find anything that is a number (0-9), then read out the potential part number.
            //   Based on the index of the starting number, as well as the length of the number string, determine the area to check for symbols
            //   Check surrounding area for anything that is not a '.' or [0-9], if there is, it's a part number, add it to the total

            int l = 0;
            foreach(string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (c >= '0' && c <= '9')
                    {
                        debugMessage(DEBUG, "Number character found in line " + l + "!");
                        int startIndex = i;
                        int endIndex = i;
                        while (endIndex < line.Length && line[endIndex] >= '0' && line[endIndex] <= '9')
                        {
                            endIndex++;
                        }

                        debugMessage(DEBUG, "Number between indices: [" + startIndex + "," + endIndex + "]");
                        int num = Convert.ToInt32(new string(line.Substring(startIndex, endIndex - startIndex)));
                        debugMessage(DEBUG, "Number parsed: " + num);
                        int minX = startIndex == 0 ? startIndex : startIndex - 1;
                        int maxX = endIndex == lines.Length ? endIndex - 1 : endIndex;
                        int minY = l == 0 ? l : l - 1;
                        int maxY = l == lines.Length - 1 ? l : l + 1;

                        debugMessage(DEBUG, "minY: " + minY + "; maxY: " + maxY);
                        debugMessage(DEBUG, "minX: " + minX + "; endIndex: " + endIndex);
                        bool isPartNumber = false;
                        for (int y = minY; y <= maxY; y++)
                        {
                            debugMessage(DEBUG, "Scanning string: " + lines[y].Substring(minX, endIndex - minX));
                            for (int x = minX; x <= maxX; x++)
                            {
                                if(!(lines[y][x] >= '0' && lines[y][x] <= '9') && lines[y][x] != '.')
                                {
                                    debugMessage(DEBUG, "Symbol located: " + lines[y][x]);
                                    isPartNumber = true;
                                }
                            }
                        }
                        if (isPartNumber)
                        {
                            total += num;
                            Console.WriteLine("(Line " + l + ") Found part number: " + num + "; New Total: " + total);
                        } else
                        {
                            Console.WriteLine("(Line " + l + ") Invalid part number: " + num);
                        }
                        i = endIndex;
                    }
                }
                l++;
            }

            Console.WriteLine("Total: " + total);
        }

        static void debugMessage(bool debug, string message)
        {
            if (debug)
            {
                Console.WriteLine("DEBUG: " + message);
            }
        }
    }
}