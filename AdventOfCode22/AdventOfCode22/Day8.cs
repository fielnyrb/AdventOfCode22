using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day8
    {
        List<string> originalInput;
        public Day8()
        {
            originalInput = File.ReadAllLines(@"input\day8sample.txt").ToList();
        }

        public int Part1()
        {

            int width = originalInput[0].Length;
            int height = originalInput.Count;

            int outerTreeCount = width * 2 + height * 2;

            int visibleTreeCount = 0;

            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    bool visibleFromRight = true;
                    bool visibleFromLeft = true;
                    bool visibleFromTop = true;
                    bool visibleFromBottom = true;
                    int kRight = j;
                    while (kRight <= width - 1)
                    {
                        if (originalInput[i][kRight] >= originalInput[i][j])
                        {
                            visibleFromRight = false;
                        }
                        kRight++;
                    }

                    int kLeft = j;
                    while (kLeft >= 0)
                    {
                        if (originalInput[i][kLeft] >= originalInput[i][j])
                        {
                            visibleFromLeft = false;
                        }
                        kLeft--;
                    }

                    int kTop = i;
                    while (kTop >= 0)
                    {
                        if (originalInput[kTop][j] >= originalInput[i][j])
                        {
                            visibleFromTop = false;
                        }
                        kTop--;
                    }

                    int kBottom = i;
                    while (kBottom <= height - 1)
                    {
                        if (originalInput[kBottom][j] >= originalInput[i][j])
                        {
                            visibleFromBottom = false;
                        }
                        kBottom++;
                    }

                    if(visibleFromTop || visibleFromLeft || visibleFromBottom || visibleFromRight)
                    {
                        visibleTreeCount += 1;
                    }
                }
            }

            return outerTreeCount + visibleTreeCount;
        }
    }
}
