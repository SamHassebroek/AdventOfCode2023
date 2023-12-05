// Advent of Code 2023: Day 4 Puzzle 2
// Solution written by: Sam Hassebroek 12/4/23
// Link to puzzle: https://adventofcode.com/2023/day/4

using System;
using System.IO;

namespace AdventOfCode23
{
    class Day4Puzzle2
    {
        static void Main(string[] args)
        {
            string textFile = @"C:\Users\Sam\Documents\AoC23\AdventOfCode2023\Day4Puzzle2\input.txt";
            
            try
            {
                string[] lines = File.ReadAllLines(textFile);

                CardSet scratchCards = new CardSet(lines);
                int total = scratchCards.solve();
                Console.WriteLine("Total: " + total);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class CardSet
    {
        private List<int> _cards;
        private List<string> _lines;

        public CardSet(string[] lines)
        {
            _cards = new List<int>();
            _lines = new List<string>(lines);
            for (int i = 0; i < _lines.Count; i++)
            {
                _cards.Add(1);
            }
        }

        public int solve()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                string line = _lines[i];
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
                for (int j = i + 1; j <= i + cardTotalMatches; j++)
                {
                    _cards[j] += _cards[i];
                }
                Console.WriteLine(_cards[i] + " copies of card " + i + ": " + cardTotalMatches + " numbers match. " + _cards[i] * cardTotalMatches + " cards created.");
            }
            return _cards.Sum();
        }

        private int[] parseNumbers(string numberStr)
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