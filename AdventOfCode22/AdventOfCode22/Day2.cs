using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode22
{
    class Day2
    {
        public int part1()
        {
            List<string> originalInput = File.ReadAllLines(@"input\day2.txt").ToList();

            int totalScore = 0;

            for (int i = 0; i < originalInput.Count(); i++)
            {
                string opponentMove = originalInput[i].Split(' ')[0];
                string myMove = originalInput[i].Split(' ')[1];

                int selectedShapePoint = mapShape(myMove);

                totalScore += (selectedShapePoint + RockPaperScissor(myMove, opponentMove));
            }

            return totalScore;
        }

        public int part2()
        {
            List<string> originalInput = File.ReadAllLines(@"input\day2.txt").ToList();

            int totalScore = 0;

            for (int i = 0; i < originalInput.Count(); i++)
            {
                string opponentMove = originalInput[i].Split(' ')[0];
                string myMove = GetMove(originalInput[i].Split(' ')[1], opponentMove);

                int selectedShapePoint = mapShape(myMove);

                totalScore += (selectedShapePoint + RockPaperScissor(myMove, opponentMove));
            }

            return totalScore;
        }

        int mapShape(string shape) {
            if (shape == "X") return 1;
            if (shape == "Y") return 2;
            if (shape == "Z") return 3;
            return 0;
        }

        int RockPaperScissor(string myMove, string opponentMove) {
            if (myMove == "X" && opponentMove == "A") return 3;
            if (myMove == "Y" && opponentMove == "B") return 3;
            if (myMove == "Z" && opponentMove == "C") return 3;

            if ((myMove == "X" && opponentMove == "C") ||
                (myMove == "Y" && opponentMove == "A") ||
                (myMove == "Z" && opponentMove == "B")) return 6; 
            return 0;
        }

        string GetMove(string outcome, string opponentMove)
        {
            if(outcome == "X")
            {
                if (opponentMove == "A") return "Z";
                if (opponentMove == "B") return "X";
                if (opponentMove == "C") return "Y";
            }
            if (outcome == "Y")
            {
                if (opponentMove == "A") return "X";
                if (opponentMove == "B") return "Y";
                if (opponentMove == "C") return "Z";
            }
            if (outcome == "Z")
            {
                if (opponentMove == "A") return "Y";
                if (opponentMove == "B") return "Z";
                if (opponentMove == "C") return "X";
            }
            return "";
        }
    }
}
