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
