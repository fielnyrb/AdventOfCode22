using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day6
    {
        string dataStream;
        public Day6()
        {
            //dataStream = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
            dataStream = File.ReadAllText(@"input\day6.txt");
        }

        // Part1 method
        public int Part1()
        {
            char[] fourBits = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            for (int i = 0; i < dataStream.Length; i++)
            {
                fourBits[i % 14] = dataStream[i];
                bool duplicateExists = false;
                for (int j = 0; j < fourBits.Length; j++)
                {
                    if (!fourBits.Contains('_'))
                    {
                        if (fourBits.Count(x => x == fourBits[j]) > 1)
                        {
                            duplicateExists = true;
                            break;
                        }
                        else
                        {
                            duplicateExists = false;
                        }
                    }
                }
                if (!fourBits.Contains('_'))
                {
                    if (duplicateExists)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("found at" + (i + 1));
                        break;
                    }
                }
            }
            return 0;
        }

        // Part2 method
        public void Part2()
        {
            Console.WriteLine("Part2 method called");
        }
    }
}
