using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace AdventOfCode2020.Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = File.ReadAllLines("input.txt");
            var commands = program.Select(GetCommand).ToArray();
            
            CalculateAcc(commands, out var acc);

            Console.WriteLine(acc);
            Console.ReadLine();
            int accFixed = 0;

            foreach (var newProgam in RewriteProgram(commands))
            {
                if (CalculateAcc(newProgam, out accFixed))
                {
                    break;
                }
            }
            
            Console.WriteLine(accFixed);
            Console.ReadLine();
        }

        static IEnumerable<(string action, int arg)[]> RewriteProgram((string action, int arg)[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i].action)
                {
                    case "nop":
                        yield return commands.Take(i).Concat(new[] {("jmp", commands[i].arg)}).Concat(commands.Skip(i + 1)).ToArray();
                        break;
                    case "jmp":
                        yield return commands.Take(i).Concat(new[] {("nop", commands[i].arg) }).Concat(commands.Skip(i + 1)).ToArray();
                        break;
                }
            }
        }

        private static bool CalculateAcc((string action, int arg)[] commands, out int acc)
        {
            acc = 0;
            var index = 0;
            var visited = new List<int>();
            while (!visited.Contains(index) && index < commands.Length)
            {
                visited.Add(index);
                _ = (commands[index] switch
                {
                    ("nop", _) => (index += 1, acc += 0),
                    ("acc", var a) => (index += 1, acc += a),
                    ("jmp", var a) => (index += a, acc += 0),
                });
            }

            return index >= commands.Length;
        }

        static (string action, int arg) GetCommand(string line)
        {
            var parts = line.Split(' ');

            return (parts[0], int.Parse(parts[1]));
        }
    }
}
