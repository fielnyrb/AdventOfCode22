using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode22
{
    internal class Day4
    {
        List<string> originalInput;
        public Day4()
        {
            originalInput = File.ReadAllLines(@"input\day4.txt").ToList();
        }

        public int Part1()
        {
            int overlaps = 0;
            for (int i = 0; i < originalInput.Count; i++)
            {

                string[] pair = originalInput[i].Split(',');
                //int pair1Assignment1 = int.Parse(pair[0].Split("-")[0]);
                //int pair1Assignment2 = int.Parse(pair[0].Split("-")[1]);
                //int pair2Assignment1 = int.Parse(pair[1].Split("-")[0]);
                //int pair2Assignment2 = int.Parse(pair[1].Split("-")[1]);

                //if ((pair1Assignment1 <= pair2Assignment1 && pair1Assignment2 >= pair2Assignment2) ||
                //    (pair2Assignment1 <= pair1Assignment1 && pair2Assignment2 >= pair1Assignment2))
                //{
                //    overlaps++;
                //}
            }

            return overlaps;
        }

        public int Part2()
        {
            int overlaps = 0;
            //for (int i = 0; i < originalInput.Count; i++)
            //{
            //    string[] pair = originalInput[i].Split(",");
            //    int pair1Assignment1 = int.Parse(pair[0].Split("-")[0]);
            //    int pair1Assignment2 = int.Parse(pair[0].Split("-")[1]);
            //    int pair2Assignment1 = int.Parse(pair[1].Split("-")[0]);
            //    int pair2Assignment2 = int.Parse(pair[1].Split("-")[1]);

            //    if ((pair1Assignment1 <= pair2Assignment1 && pair1Assignment2 >= pair2Assignment1) ||
            //        (pair2Assignment1 <= pair1Assignment1 && pair2Assignment2 >= pair1Assignment1))
            //    {
            //        overlaps++;
            //    }
            //}

            return overlaps;
        }
    }
}
