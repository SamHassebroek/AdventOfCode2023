// Advent of Code 2023: Day X Puzzle Y
// Solution written by: Sam Hassebroek 12/X/23
// Link to puzzle: https://adventofcode.com/2023/day/X

using System;
using System.IO;

namespace AdventOfCode23
{
    class DayXPuzzleY
    {
        static void Main(string[] args)
        {
            string textFile = @"C:\Users\Sam\Documents\AoC23\AdventOfCode2023\Day4Puzzle1\input.txt";
            try
            {
                string[] lines = File.ReadAllLines(textFile);

                int total = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] splits = line.Split(": ");
                    string[] numbers = splits[1].Split(" | ");
                    int[] winNums = parseNumbers(numbers[0]);
                    int[] scratchNums = parseNumbers(numbers[1]);
                    int cardTotalMatches = 0;
                    foreach (int num in scratchNums)
                    {
                        if (winNums.Contains(num))
                        {
                            cardTotalMatches++;
                        }
                    }
                    switch (cardTotalMatches)
                    {
                        case 0:
                            break;
                        case 1:
                            total += 1;
                            break;
                        default:
                            total += (int)Math.Pow(2, cardTotalMatches - 1);
                            break;
                    }
                    Console.WriteLine("Card " + i + ": " + cardTotalMatches + " numbers match. New total: " + total);
                }
                Console.WriteLine("Total: " + total);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int[] parseNumbers(string numberStr)
        {
            int[] nums = new int[(numberStr.Length / 3) + 1];
            for (int i = 0; i < numberStr.Length; i += 3)
            {
                nums[i / 3] = int.Parse(numberStr.Substring(i, 2).Trim());
            }
            return nums;
        }
    }
}