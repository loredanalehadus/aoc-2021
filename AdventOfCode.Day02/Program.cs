using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var part1SampleResult = Part1(InputData.SampleInput);
            var part2SampleResult = Part2(InputData.SampleInput);
            var part1Result = Part1(InputData.Part1);
            var part2Result = Part2(InputData.Part1);

            Console.WriteLine($"Part 1 sample: {part1SampleResult}"); // should be 150
            Console.WriteLine($"Part 2 sample: {part2SampleResult}"); // should be 900
            Console.WriteLine($"Part 1: {part1Result}");
            Console.WriteLine($"Part 2: {part2Result}");
        }


        private static int Part1(List<string> inputList)
        {
            var depth = 0;
            var horizontalPosition = 0;

            foreach (var input in inputList)
            {
                if (input.Contains("forward"))
                {
                    horizontalPosition += GetValue(input, "forward");
                }

                if (input.Contains("down"))
                {
                    depth += GetValue(input, "down");
                }

                if (input.Contains("up"))
                {
                    depth -= GetValue(input, "up");
                }

            }

            return depth * horizontalPosition;
        }

        private static int Part2(List<string> inputList)
        {
            var depth = 0;
            var horizontalPosition = 0;
            var aim = 0;

            foreach (var input in inputList)
            {
                if (input.Contains("forward"))
                {
                    horizontalPosition += GetValue(input, "forward");
                    depth += aim * GetValue(input, "forward");
                }

                if (input.Contains("down"))
                {
                    aim += GetValue(input, "down");

                }

                if (input.Contains("up"))
                {
                    aim -= GetValue(input, "up");
                }

            }

            return depth * horizontalPosition;
        }

        private static int GetValue(string inputData, string command)
        {
            var value = inputData.Substring(command.Length + 1, 1);
            return Convert.ToInt32(value);
        }

    }


}

