using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day7
    {
        List<string> originalInput;
        List<int> folderSizes;
        Dictionary<string, int> paths;
        Stack<string> path, pathCopy;
        public Day7()
        {
            originalInput = File.ReadAllLines(@"input\day7.txt").ToList();
            path = new Stack<string>();
            pathCopy = new Stack<string>();
            folderSizes = new List<int>();
            paths = new Dictionary<string, int>();
        }

        public int Part1()
        {
            int tryParseValue = 0;
            bool listModeIsOn = false;
            for (int i = 0; i < originalInput.Count; i++)
            {
                if (listModeIsOn && (originalInput[i][0] == '$'))
                {
                    listModeIsOn = false;
                }
                if (originalInput[i].Contains("$ cd"))
                {
                    string currentDirectory = originalInput[i].Split(' ')[2];
                    if (currentDirectory == "..")
                    {
                        path.Pop();
                    }
                    else
                    {
                        path.Push(currentDirectory);
                    }
                }
                if (originalInput[i].Contains("$ ls"))
                {
                    listModeIsOn = true;
                }

                if (listModeIsOn)
                {
                    if (Int32.TryParse(originalInput[i].Split(' ')[0], out tryParseValue))
                    {
                        DeepCopyPath();
                        AccumulatePathSizesInPath(tryParseValue);
                    }
                }
            }

            int sumOfDirectoriesLessThanOneHundredThousand = 0;

            foreach (KeyValuePair<string, int> p in paths)
            {
                if (p.Value <= 100000)
                {
                    sumOfDirectoriesLessThanOneHundredThousand += p.Value;
                }
            }

            return sumOfDirectoriesLessThanOneHundredThousand;
        }

        public int Part2()
        {

            int spacePotential = 70000000 - paths["//"];
            int smallestCandidate = 70000000;
            foreach (KeyValuePair<string, int> p in paths)
            {
                if (spacePotential + p.Value > 30000000)
                {
                    if (p.Value < smallestCandidate)
                    {
                        smallestCandidate = p.Value;
                    }
                }
            }
            return smallestCandidate;
        }

        string GeneratePathName()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in path)
            {
                sb.Append("/");
                sb.Append(item);
            }
            return sb.ToString();
        }

        string GeneratePathCopyName()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in pathCopy)
            {
                sb.Append(item);
                sb.Append("/");
            }
            return sb.ToString();
        }

        void DeepCopyPath()
        {
            pathCopy.Clear();
            string[] tempPath = new string[1];
            pathCopy.CopyTo(tempPath, 0);

            for (int i = path.Count - 1; i >= 0; i--)
            {
                pathCopy.Push(path.ElementAt(i));
            }
        }

        void AccumulatePathSizesInPath(int value)
        {
            while (pathCopy.Count > 0)
            {
                if (!paths.ContainsKey(GeneratePathCopyName()))
                {
                    paths[GeneratePathCopyName()] = value;
                }
                else
                {
                    paths[GeneratePathCopyName()] += value;
                }
                pathCopy.Pop();
            }
        }
    }
}
