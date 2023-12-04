// Advent of Code 2023: Day 3 Puzzle 2
// Solution written by: Sam Hassebroek 12/3/23
// Link to puzzle: https://adventofcode.com/2023/day/3 (unlocked after part 1)

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day3Puzzle2
    {

        static void Main(string[] args)
        {
            // Prep file input
            string textFile = @"C:\Users\Sam\Documents\AoC23\Day3Puzzle2\input.txt";
            string[] lines = File.ReadAllLines(textFile);

            bool DEBUG = false;
            int total = 0;


            Dictionary<Tuple<int, int>, List<int>> gearDictionary = new Dictionary<Tuple<int, int>, List<int>>();
            int l = 0;
            foreach(string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (c >= '0' && c <= '9')
                    {
                        int startIndex = i;
                        int endIndex = i;
                        while (endIndex < line.Length && line[endIndex] >= '0' && line[endIndex] <= '9')
                        {
                            endIndex++;
                        }

                        int num = Convert.ToInt32(new string(line.Substring(startIndex, endIndex - startIndex)));
                        int minX = startIndex == 0 ? startIndex : startIndex - 1;
                        int maxX = endIndex == lines.Length ? endIndex - 1 : endIndex;
                        int minY = l == 0 ? l : l - 1;
                        int maxY = l == lines.Length - 1 ? l : l + 1;

                        bool isByGear = false;
                        for (int y = minY; y <= maxY; y++)
                        {
                            for (int x = minX; x <= maxX; x++)
                            {

                                if(lines[y][x] == '*')
                                {
                                    isByGear = true;
                                    Tuple<int, int> pos = new Tuple<int, int>(x, y);
                                    if (!gearDictionary.ContainsKey(pos))
                                    {
                                        gearDictionary.Add(pos, new List<int>());
                                    }
                                    gearDictionary[pos].Add(num);
                                }
                            }
                        }
                        i = endIndex;
                    }
                }
                l++;
            }

            foreach(KeyValuePair<Tuple<int, int>, List<int>> entry in gearDictionary)
            {
                if (entry.Value.Count > 1)
                {
                    total += entry.Value.Aggregate(1, (acc, val) => acc * val);
                }
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