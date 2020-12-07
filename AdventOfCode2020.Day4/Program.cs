using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var text = await File.ReadAllTextAsync("input.txt");
            
            var entries = text.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
            Part1(entries);
            Part2(entries);
        }

        private static void Part1(string[] entries)
        {
            var regex = new Regex(@"(ecl:(\S+))|(pid:(\S+))|(eyr:(\S+))|(hcl:(\S+))|(byr:(\S+))|(iyr:(\S+))|(hgt:(\S+))");
            var valid = 0;
            foreach (var entry in entries)
            {
                var matches = regex.Matches(entry);

                if (matches.Count == 7)
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }

        private static void Part2(string[] entries)
        {
            var regex = new Regex(@"(byr:(19[2-9]\d|200[0-2])|iyr:(20(1\d|20))|eyr:(20(2\d|30))|hgt:((1([5-8]\d|9[0-3]))cm|(59|6[0-9]|7[0-6])in)|hcl:#([0-9a-f]{6})|ecl:(amb|blu|brn|gry|grn|hzl|oth)|pid:([0-9]{9}))(\s|$)");
            var valid = 0;
            foreach (var entry in entries)
            {
                var matches = regex.Matches(entry);

                if (matches.Count == 7)
                {
                    valid++;
                }
            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }
    }
}
