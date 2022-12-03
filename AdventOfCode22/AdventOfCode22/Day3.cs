using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day3
    {
        public int Part1()
        {
            List<string> originalInput = File.ReadAllLines(@"input\day3.txt").ToList();

            string priorities = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int sum = 0;

            for (int i = 0; i < originalInput.Count(); i++)
            {
                string input = originalInput[i];

                string firstHalf = input.Substring(0, input.Length / 2);
                string secondHalf = input.Substring(input.Length / 2);

                char sharedItem = findSharedItems(firstHalf, secondHalf)[0];
                sum += priorities.IndexOf(sharedItem);
            }

            return sum;
        }

        public int Part2()
        {
            List<string> originalInput = File.ReadAllLines(@"input\day3.txt").ToList();

            string priorities = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int sum = 0;

            for (int i = 0; i < originalInput.Count(); i += 3)
            {
                string sharedItem = findSharedItem(originalInput[i], originalInput[i+1], originalInput[i+2]);
                sum += priorities.IndexOf(sharedItem);
            }

            return sum;
        }

        string findSharedItems(string p1, string p2)
        {
            string sharedItems = "";
            for (int i = 0; i < p1.Length; i++)
            {
                if (p2.Contains(p1[i]))
                {
                    sharedItems += p1[i];
                }
            }
            return sharedItems;
        }

        string findSharedItem(string p1, string p2, string p3)
        {
            string sharedItem = "";

            for (int i = 0; i < p1.Length; i++)
            {
                if(p2.Contains(p1[i]) && p3.Contains(p1[i])) {
                    sharedItem = p1[i].ToString();
                }
            }

            return sharedItem;
        }
    }
}
