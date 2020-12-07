using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead("input.txt"));

            var bags = new List<Bag>();

            var lineRegex = new Regex(@"(?<bag>.*) bags contains? (no other bags|(?<contents>\d .* bags?))");
            var countRegex = new Regex(@"((?<count>\d) (?<bag>.*) bags?)");

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineParts = lineRegex.Match(line);
                var bagName = lineParts.Groups["bag"].Value;
                var parts = lineParts.Groups["contents"].Value.Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (bags.All(x => x.Name != bagName))
                {
                    bags.Add(new Bag(bagName));
                }

                var bag = bags.Find(x => x.Name == bagName);

                foreach (var part in parts)
                {
                    var internalBag = countRegex.Match(part);
                    var internalBagName = internalBag.Groups["bag"].Value;
                    var internalBagCount = int.Parse(internalBag.Groups["count"].Value);

                    if (bags.All(x => x.Name != internalBagName))
                    {
                        bags.Add(new Bag(internalBagName));
                    }

                    var internalFind = bags.Find(x => x.Name == internalBagName);

                    bag.AddChild(internalFind, internalBagCount);
                }
            }

            var goldBag = bags.Find(x => x.Name == "shiny gold");

            var names = GetNames(goldBag.Parents.Keys).Distinct();

            Console.WriteLine(names.Count());
            Console.ReadLine();

            var total = 0UL;

            foreach (var goldBagChild in goldBag.Children)
            {
                total += GetTotal(goldBagChild.Key, (ulong)goldBagChild.Value);
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }


        private static ulong GetTotal(Bag bag, ulong multiplier)
        {
            var total = 0UL;

            total += multiplier;

            foreach (var bagChild in bag.Children)
            {
                total += GetTotal(bagChild.Key, multiplier * (ulong)bagChild.Value);
            }

            return total;
        }

        private static IEnumerable<string> GetNames(IEnumerable<Bag> bags)
        {
            foreach (var bag in bags)
            {
                foreach (var name in GetNames(bag.Parents.Keys))
                {
                    yield return name;
                }

                yield return bag.Name;
            }
        }
    }

    public class Bag
    {
        public Bag(string name)
        {
            Name = name;
            Parents = new Dictionary<Bag, int>();
            Children = new Dictionary<Bag, int>();
        }
     
        public string Name { get; }

        public void AddChild(Bag childBag, int count)
        {
            childBag.Parents[this] = count;
            Children[childBag] = count;
        }

        public IDictionary<Bag, int> Parents { get; }
        public IDictionary<Bag, int> Children { get; }
    }
}
