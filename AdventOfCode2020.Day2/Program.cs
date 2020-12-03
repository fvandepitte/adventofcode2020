using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day2
{
    class Program
    {
        static Regex passwordParser = new Regex(@"(\d+)-(\d+) (\w): (\w+)");

        static async Task Main(string[] args)
        {
            await Part1();
            await Part2();
        }

        private static async Task Part2()
        {
            using var reader = new StreamReader(File.OpenRead("input.txt"));
            var valid = 0;

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var parserResult = passwordParser.Match(line);

                var pos1 = int.Parse(parserResult.Groups[1].Value) - 1;
                var pos2 = int.Parse(parserResult.Groups[2].Value) - 1;
                var character = parserResult.Groups[3].Value[0];
                var password = parserResult.Groups[4].Value;

                if ((password[pos1] == character || password[pos2] == character) && password[pos1] != password[pos2])
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }

        private static async Task Part1()
        {
            using var reader = new StreamReader(File.OpenRead("input.txt"));
            var valid = 0;

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var parserResult = passwordParser.Match(line);

                var min = int.Parse(parserResult.Groups[1].Value);
                var max = int.Parse(parserResult.Groups[2].Value);
                var character = parserResult.Groups[3].Value[0];
                var password = parserResult.Groups[4].Value;

                var count = password.Count(c => c == character);
                if (min <= count && count <= max)
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }
    }
}
