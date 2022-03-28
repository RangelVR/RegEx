using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {


            string pattern = @"[>]{2}\b(?<item>[A-Za-z]+)[<]{2}(?<price>\d+(\.\d+)*?)!(?<quantity>\d+)\b";

            List<string> boughtItems = new List<string>();

            decimal totalMoneySpend = 0m;
            while (true)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (input == "Purchase")
                {
                    break;
                }

                if (match.Success)
                {
                    string itemName = match.Groups["item"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    totalMoneySpend += price * quantity;

                    boughtItems.Add(itemName);
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in boughtItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {totalMoneySpend:f2}");

        }

        
    }
}
