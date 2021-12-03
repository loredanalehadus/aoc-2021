using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day03
{
    internal class Program
    {
        private static string OneBitLeading = "1";
        private static string ZeroBitLeading = "0";

        private static void Main(string[] args)
        {
            var sampleResult = Part1(ReadFromFile(@".\Sample.txt"));
            var sample2Result = Part2(ReadFromFile(@".\Sample.txt"));

            var part1Result = Part1(ReadFromFile(@".\InputData.txt"));
            var part2Result = Part2(ReadFromFile(@".\InputData.txt"));

            Console.WriteLine($"Sample part 1: {sampleResult}"); // should be 198
            Console.WriteLine($"Sample part 2: {sample2Result}"); // should be 230

            Console.WriteLine($"Part 1: {part1Result}");
            Console.WriteLine($"Part 2: {part2Result}");
        }

        private static int Part1(string[] input)
        {
            var gamaRateStringBuilder = new StringBuilder();
            var epsilonRateStringBuilder = new StringBuilder();

            for (int i = 0; i < input[0].Length; i++)
            {
                var report = DiagnosticReport(input, i);
                var oneLeadingCounter = report[OneBitLeading].Item1;
                var zeroLeadingCounter = report[ZeroBitLeading].Item1;

                if (zeroLeadingCounter > oneLeadingCounter)
                {
                    gamaRateStringBuilder.Append('0');
                    epsilonRateStringBuilder.Append("1");
                    continue;
                }

                epsilonRateStringBuilder.Append("0");
                gamaRateStringBuilder.Append("1");
            }

            return Convert.ToInt32(gamaRateStringBuilder.ToString(), 2) * Convert.ToInt32(epsilonRateStringBuilder.ToString(), 2);
        }

        private static int Part2(string[] input)
        {
            var oxygenGeneratorRating = 0;
            var co2scrubberRating = 0;

            oxygenGeneratorRating = GetOxygenGeneratorRating(input);
            co2scrubberRating = GetCo2scrubberRating(input);

            return oxygenGeneratorRating * co2scrubberRating;
        }

        private static int GetOxygenGeneratorRating(string[] input, int column = 0)
        {
            var value = 0;
            while (column < input[0].Length)
            {
                var report = DiagnosticReport(input, column);
                column++;

                if (report[OneBitLeading].counter > report[ZeroBitLeading].counter)
                {
                    return GetOxygenGeneratorRating(report[OneBitLeading].Item2.ToArray(), column);
                }

                if (report[ZeroBitLeading].counter > report[OneBitLeading].counter)
                {
                    return GetOxygenGeneratorRating(report[ZeroBitLeading].Item2.ToArray(), column);
                }

                return Convert.ToInt32(report[OneBitLeading].bitList.First(), 2);
            }

            return value;
        }

        private static int GetCo2scrubberRating(string[] input, int column = 0)
        {
            var value = 0;
            while (column < input[0].Length)
            {
                var report = DiagnosticReport(input, column);
                column++;

                if (report[OneBitLeading].counter < report[ZeroBitLeading].counter)
                {
                    return GetCo2scrubberRating(report[OneBitLeading].Item2.ToArray(), column);
                }

                if (report[ZeroBitLeading].counter < report[OneBitLeading].counter)
                {
                    return GetCo2scrubberRating(report[ZeroBitLeading].Item2.ToArray(), column);
                }

                return Convert.ToInt32(report[ZeroBitLeading].bitList.First(), 2);
            }

            return value;
        }

        private static Dictionary<string, (int counter, List<string> bitList)> DiagnosticReport(string[] input, int columnIndex)
        {
            var zeroBitCounter = 0;
            var oneBitCounter = 0;
            var zeroBitList = new List<string>();
            var oneBitList = new List<string>();

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j][columnIndex] == '1')
                {
                    oneBitCounter++;
                    oneBitList.Add(input[j]);
                }

                if (input[j][columnIndex] == '0')
                {
                    zeroBitCounter++;
                    zeroBitList.Add(input[j]);
                }
            }

            return new Dictionary<string, (int, List<string>)>()
            {
                {OneBitLeading, (oneBitCounter, oneBitList)},
                {ZeroBitLeading, (zeroBitCounter, zeroBitList)}
            };
        }

        private static string[] ReadFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}