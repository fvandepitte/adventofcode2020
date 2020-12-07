using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day6
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
            var total = 0;

            foreach (var entry in entries)
            {
                var ex = entry.Replace(Environment.NewLine, string.Empty);
                total += ex.Distinct().Count();
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }

        private static void Part2(string[] entries)
        {
            var total = 0;

            foreach (var entry in entries)
            {
                var lines = entry.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Distinct());

                foreach (var c in lines.FirstOrDefault())
                {
                    if (lines.All(l => l.Contains(c)))
                    {
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}
