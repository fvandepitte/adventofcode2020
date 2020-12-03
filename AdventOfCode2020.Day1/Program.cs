using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Part1();
            await Part2();
        }

        private static async Task Part2()
        {
            using var reader = new StreamReader(File.OpenRead("input.txt"));

            var numbers = new List<int>();
            var combos = new List<(int, int)>();
            var numberFound = false;

            while (!reader.EndOfStream && !numberFound)
            {
                var number = int.Parse(await reader.ReadLineAsync());

                foreach (var combo in combos)
                {
                    if (combo.Item1 + combo.Item2 + number == 2020)
                    {
                        Console.WriteLine(combo.Item1 * combo.Item2 * number);
                        numberFound = true;
                        break;
                    }
                }

                if (!numberFound)
                {
                    foreach (var i in numbers)
                    {
                        if (i + number <= 2020)
                        {
                            combos.Add((i, number));
                        }
                    }

                    numbers.Add(number);
                }
            }

            Console.ReadKey();
        }

        private static async Task Part1()
        {
            using var reader = new StreamReader(File.OpenRead("input.txt"));

            var numbers = new List<int>();
            var numberFound = false;
            while (!reader.EndOfStream && !numberFound)
            {
                var number = int.Parse(await reader.ReadLineAsync());

                foreach (var i in numbers)
                {
                    if (i + number == 2020)
                    {
                        Console.WriteLine(i * number);
                        numberFound = true;
                        break;
                    }
                }

                numbers.Add(number);
            }

            Console.ReadKey();
        }
    }
}
