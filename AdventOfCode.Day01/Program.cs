using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var part1SampleDepths = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var resultSamplePart1 = Part1(part1SampleDepths); //should be 7
            var resultSamplePart2 = Part2(part1SampleDepths, 3); //should be 5

            var resultPart1 = Part1(Samples.Part1);
            var resultPart2 = Part2(Samples.Part1, 3);

            Console.WriteLine($"Sample part 1: {resultSamplePart1}");
            Console.WriteLine($"Sample part 2: {resultSamplePart2}");
            Console.WriteLine($"Part 1: {resultPart1}");
            Console.WriteLine($"Part 2: {resultPart2}");
        }


        private static int Part1(List<int> depths)
        {
            var increasedDepthCounter = 0;

            for (int i = 0; i < depths.Count; i++)
            {
                var isLastElement = i + 1 == depths.Count;

                if (!isLastElement && depths.ElementAt(i + 1) > depths.ElementAt(i))
                {
                    increasedDepthCounter++;
                }
            }

            return increasedDepthCounter;
        }

        private static int Part2(List<int> depths, int numberOfMeasurements)
        {
            var measurementSumsList = new List<int>();

            for (int i = 0; i < depths.Count; i++)
            {
                var isLastToBeCountedElement = i + numberOfMeasurements > depths.Count;

                if (isLastToBeCountedElement)
                {
                    break;
                }

                var measurement = depths.GetRange(i, numberOfMeasurements).Sum();
                measurementSumsList.Add(measurement);
            }

            return Part1(measurementSumsList);
        }
    }
}
