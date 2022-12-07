using System;
using System.Collections.Generic;
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
        Stack<string> path;
        public Day7()
        {
            originalInput = File.ReadAllLines(@"input\day7sample.txt").ToList();
            path = new Stack<string>();
            folderSizes = new List<int>();
        }

        public int Part1()
        {
            int tryParseValue = 0;
            int currentDirectoryTotalSize = 0;
            bool listModeIsOn = false;
            for (int i = 0; i < originalInput.Count; i++)
            {
                if (originalInput[i][0] == '$' || i == originalInput.Count-1)
                {
                    listModeIsOn = false;
                    folderSizes.Add(currentDirectoryTotalSize);
                    currentDirectoryTotalSize = 0;
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
                else if (listModeIsOn)
                {
                    if (Int32.TryParse(originalInput[i].Split(' ')[0], out tryParseValue))
                    {
                        currentDirectoryTotalSize += tryParseValue;
                    }
                }
            }
            return 0;
        }

    }
}
