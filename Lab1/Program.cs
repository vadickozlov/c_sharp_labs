﻿using System;
using System.Collections.Generic;

namespace Lab1 {
    class Program {
        static void Main(string[] args) {
            int[,] sudoku = {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9},
            };
            
            int[,] matrix = {
                {1, 0, 1, 0, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 1, 0, 1, 0, 0, 0, 0, 1},
                {0, 1, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1},
                {0, 1, 1, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 1, 1, 1, 0, 1},
                {1, 1, 1, 1, 0, 1, 0, 0, 0},
                {1, 0, 0, 0, 0, 0, 0, 1, 0},
            };
            AlgorythmX algorythm = new AlgorythmX(matrix);
            algorythm.Solve();
            Stack<int> answer = new Stack<int>(algorythm.GetAnswer());
            while (answer.Count > 0) {
                Console.WriteLine(answer.Pop());
            }

            Sudoku s = new Sudoku(sudoku);
            s.Solve();
            s.Print();
            
        }
    }
}
