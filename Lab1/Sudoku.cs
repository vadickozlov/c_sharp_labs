using System;
using System.Collections.Generic;

namespace Lab1 {
    class Sudoku {
        private int[,] _field = new int[9, 9];
        private int _matrixSize = 9, _size = 3;
        private Random _random = new Random();
        private struct AnswerItem {
            public int Row, Column, Number;
            public AnswerItem(int row, int column, int number) {
                this.Row = row;
                this.Column = column;
                this.Number = number;
            }
        }
        
        public Sudoku(int[, ] matrix) {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.GetUpperBound(1) + 1;
            if (rows != 9 || columns != 9) {
                Console.WriteLine("ERROR: input matrix has invalid size.");
            }

            _field = matrix;
        }

        public bool Solve() {
            // first 81 columns for rows, next 81 for columns, the next 81 - for squares,
            // the last 81 - for indicating what row and column is filled
            
            // fill all of possible sets
            int[,] sets = new int[729, 324];
            int index = -1;
            Stack<int> rowsWhereNumbersExist = new Stack<int>();
            Dictionary<int, AnswerItem> answerItems = new Dictionary<int, AnswerItem>();
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    int squareNumber = 3 * (i / 3) + (j / 3);
                    for (int number = 0; number < 9; number++) {
                        index++;
                        if (_field[i, j] == number + 1) {
                            rowsWhereNumbersExist.Push(index);
                        }

                        answerItems[index] = new AnswerItem(i, j, number + 1);
                        int rowCode = i * 9 + number;
                        int columnCode = 81 + j * 9 + number;
                        int squareCode = 162 + squareNumber * 9 + number;
                        int cellCode = 243 + i * 9 + j;
                        sets[index, rowCode]++;
                        sets[index, columnCode]++;
                        sets[index, squareCode]++;
                        sets[index, cellCode]++;
                    }
                }
            }

            AlgorythmX algorithmX = new AlgorythmX(sets);

            // delete filled numbers
            while (rowsWhereNumbersExist.Count > 0) {
                bool resultOfDeleting = algorithmX.DeleteRow(rowsWhereNumbersExist.Pop());
                if (!resultOfDeleting) {
                    // we covered some column twice
                    // input sudoku was invalid
                    Console.WriteLine("Input sudoku is invalid");
                    return false;
                }
            }
            
            algorithmX.Solve();
            
            if (algorithmX.SolutionFound()) {
                Stack<int> answer = new Stack<int>(algorithmX.GetAnswer());
                while (answer.Count > 0) {
                    int currentItem = answer.Pop();
                    _field[answerItems[currentItem].Row, answerItems[currentItem].Column] =
                        answerItems[currentItem].Number;
                }
            }
            else {
                Console.WriteLine("This sudoku hasn't solution");
            }

            return algorithmX.SolutionFound();
        }
        
        public void Print() {
            for (int i = 0; i < _matrixSize; i++) {
                for (int j = 0; j < _matrixSize; j++) {
                    Console.Write("{0, 3}", _field[i, j]);
                    if (j % _size == _size - 1) { Console.Write("{0, 3}", " "); }
                }
                Console.WriteLine();
                if (i % _size == _size - 1) {
                    Console.WriteLine();
                }
            }
        }
    }
}