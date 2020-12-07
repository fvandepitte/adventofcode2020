using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var seatnumbers = lines.Select(x => Parse(x.AsSpan()));
            Part1(seatnumbers);
            Part2(seatnumbers);
        }

        private static void Part1(IEnumerable<int> seatnumbers) 
        {
            var result = seatnumbers.Max();

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static void Part2(IEnumerable<int> seatnumbers)
        {
            var result = Enumerable.Range(0, 1024).Except(seatnumbers).ToList();

            foreach (var seat in result)
            {
                if (!(result.Contains(seat - 1) || result.Contains(seat + 1)))
                {
                    Console.WriteLine(seat);
                    break;
                }
            }

            Console.ReadKey();
        }


        static int Parse(ReadOnlySpan<char> row)
        {
            var result = 0;
            var muliplier = (int)Math.Pow(2, row.Length - 1);
            foreach (var c in row)
            {
                if (c == 'B' || c == 'R')
                {
                    result += muliplier;
                }

                muliplier /= 2;
            }

            return result;
        }
    }
}
