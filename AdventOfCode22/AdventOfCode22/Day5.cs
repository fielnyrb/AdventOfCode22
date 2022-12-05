using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day5
    {
        List<string> originalInput;
        List<Stack<string>> stacksOfCrates;
        public Day5()
        {
            originalInput = File.ReadAllLines(@"input\day5.txt").ToList();
            stacksOfCrates = new List<Stack<string>>();
            Part1Setup();
        }

        void Part1Setup()
        {
            Stack<string> crates1 = new Stack<string>();
            crates1.Push("R");
            crates1.Push("S");
            crates1.Push("L");
            crates1.Push("F");
            crates1.Push("Q");
            stacksOfCrates.Add(crates1);

            Stack<string> crates2 = new Stack<string>();
            crates2.Push("N");
            crates2.Push("Z");
            crates2.Push("Q");
            crates2.Push("G");
            crates2.Push("P");
            crates2.Push("T");
            stacksOfCrates.Add(crates2);

            Stack<string> crates3 = new Stack<string>();
            crates3.Push("S");
            crates3.Push("M");
            crates3.Push("Q");
            crates3.Push("B");
            stacksOfCrates.Add(crates3);

            Stack<string> crates4 = new Stack<string>();
            crates4.Push("T");
            crates4.Push("G");
            crates4.Push("Z");
            crates4.Push("J");
            crates4.Push("H");
            crates4.Push("C");
            crates4.Push("B");
            crates4.Push("Q");
            stacksOfCrates.Add(crates4);

            Stack<string> crates5 = new Stack<string>();
            crates5.Push("P");
            crates5.Push("H");
            crates5.Push("M");
            crates5.Push("B");
            crates5.Push("N");
            crates5.Push("F");
            crates5.Push("S");
            stacksOfCrates.Add(crates5);

            Stack<string> crates6 = new Stack<string>();
            crates6.Push("P");
            crates6.Push("C");
            crates6.Push("Q");
            crates6.Push("N");
            crates6.Push("S");
            crates6.Push("L");
            crates6.Push("V");
            crates6.Push("G");
            stacksOfCrates.Add(crates6);

            Stack<string> crates7 = new Stack<string>();
            crates7.Push("W");
            crates7.Push("C");
            crates7.Push("F");
            stacksOfCrates.Add(crates7);

            Stack<string> crates8 = new Stack<string>();
            crates8.Push("Q");
            crates8.Push("H");
            crates8.Push("G");
            crates8.Push("Z");
            crates8.Push("W");
            crates8.Push("V");
            crates8.Push("P");
            crates8.Push("M");
            stacksOfCrates.Add(crates8);

            Stack<string> crates9 = new Stack<string>();
            crates9.Push("G");
            crates9.Push("Z");
            crates9.Push("D");
            crates9.Push("L");
            crates9.Push("C");
            crates9.Push("N");
            crates9.Push("R");
            stacksOfCrates.Add(crates9);
        }

        public string Part1()
        {
            string finalStackTopArrangement = "";

            for (int i = 10; i < originalInput.Count; i++)
            {
                int amount = Int32.Parse(originalInput[i].Split(' ')[1]);
                int source = Int32.Parse(originalInput[i].Split(' ')[3]);
                int target = Int32.Parse(originalInput[i].Split(' ')[5]);

                while (amount > 0)
                {
                    string stackContent = stacksOfCrates[source - 1].Pop();
                    stacksOfCrates[target - 1].Push(stackContent);

                    amount--;
                }
            }

            for (int i = 0; i < stacksOfCrates.Count; i++)
            {
                finalStackTopArrangement += stacksOfCrates[i].Peek();
            }

            return finalStackTopArrangement;
        }

        public string Part2()
        {
            string finalStackTopArrangement = "";

            for (int i = 10; i < originalInput.Count; i++)
            {
                int amount = Int32.Parse(originalInput[i].Split(' ')[1]);
                int source = Int32.Parse(originalInput[i].Split(' ')[3]);
                int target = Int32.Parse(originalInput[i].Split(' ')[5]);

                List<string> poppedCrates = new List<string>();

                while (amount > 0)
                {
                    string stackContent = stacksOfCrates[source - 1].Pop();
                    poppedCrates.Add(stackContent);

                    amount--;
                }
                poppedCrates.Reverse();

                for (int j = 0; j < poppedCrates.Count; j++)
                {
                    stacksOfCrates[target - 1].Push(poppedCrates[j]);
                }


            }

            for (int i = 0; i < stacksOfCrates.Count; i++)
            {
                finalStackTopArrangement += stacksOfCrates[i].Peek();
            }

            return finalStackTopArrangement;
        }
    }
}
