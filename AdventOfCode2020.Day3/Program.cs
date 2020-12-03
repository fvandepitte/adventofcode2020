using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Part1();
            await Part2();
        }

        private static async Task Part1()
        {
            var lines = await File.ReadAllLinesAsync("input.txt");
            var lineLength = lines.First().Length;
            var trees = lines.Select((l, i) => Next(i, 3, 1, out var rowIndex) && l[rowIndex % lineLength] == '#' ? 1 : 0).Sum();
            Console.WriteLine(trees);
            Console.ReadLine();
        }

        private static async Task Part2()
        {
            var lines = await File.ReadAllLinesAsync("input.txt");
            var lineLength = lines.First().Length;
            var oddLineLength = lineLength % 2 != 0;
            var i = 0;
            var j = 0;
            var trees = lines.Aggregate((0l, 0l, 0l, 0l, 0l), (tuple, l) =>
            {
                tuple.Item1 += Next(i, 1, 1, out var rowIndex1) && l[rowIndex1 % lineLength] == '#' ? 1 : 0;
                tuple.Item2 += Next(i, 3, 1, out var rowIndex2) && l[rowIndex2 % lineLength] == '#' ? 1 : 0;
                tuple.Item3 += Next(i, 5, 1, out var rowIndex3) && l[rowIndex3 % lineLength] == '#' ? 1 : 0;
                tuple.Item4 += Next(i, 7, 1, out var rowIndex4) && l[rowIndex4 % lineLength] == '#' ? 1 : 0;
                tuple.Item5 += Next(i, 1, 2, out var rowIndex5) && l[rowIndex5 % lineLength] == '#' ? 1 : 0;
                i++;
                
                return tuple;
            });

            Console.WriteLine(trees.Item1 * trees.Item2 * trees.Item3 * trees.Item4 * trees.Item5);
            Console.ReadLine();
        }

        private static bool Next(int index, int right, int down, out int rowIndex)
        {
            if (index % down != 0)
            {
                rowIndex = -1;
                return false;
            }

            rowIndex = (index / down) * right;

            return true;
        }
    }
}
