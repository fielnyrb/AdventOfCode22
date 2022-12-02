using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode22
{
    class Day1
    {
        public int execute() {
            List<string> originalInput = File.ReadAllLines(@"input\day1.txt").ToList();
            List<int> counts = new List<int>();

            counts.Add(0);

            for (int i = 0; i < originalInput.Count(); i++)
            {
                if (originalInput[i] == "")
                {
                    counts.Add(0);
                }
                else
                {
                    int countsIndex = counts.Count() == 0 ? 0 : counts.Count() - 1;
                    counts[countsIndex] += int.Parse(originalInput[i]);
                }
            }
            counts.Sort();
            int top1 = counts[counts.Count() - 1];
            int top2 = counts[counts.Count() - 2];
            int top3 = counts[counts.Count() - 3];
            return top1 + top2 + top3;
        }
    }
}
