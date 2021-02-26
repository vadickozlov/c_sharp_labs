using System;
using System.Collections.Generic;

namespace Lab1 {
    class Sudoku {
        private int[,] field = new int[9, 9];
        private int matrixSize = 9, size = 3;
        private Random random = new Random();
        private struct AnswerItem {
            public int row, column, number;
            public AnswerItem(int row, int column, int number) {
                this.row = row;
                this.column = column;
                this.number = number;
            }
        }

        //========== functions for generating ==========
        private void SwapRandomRows() {
            int region = random.Next(0, size);
            int row1 = size * region + random.Next(0, size);
            int row2 = size * region + random.Next(0, size);
            for (int j = 0; j < matrixSize; j++) {
                int template = field[row1, j];
                field[row1, j] = field[row2, j];
                field[row2, j] = template;
            }
        }
        private void SwapRandomColumns() {
            int region = random.Next(0, size);
            int column1 = size * region + random.Next(0, size);
            int column2 = size * region + random.Next(0, size);
            for (int i = 0; i < matrixSize; i++) {
                int template = field[i, column1];
                field[i, column1] = field[i, column2];
                field[i, column2] = template;
            }
        }
        private void SwapRandomHorizontalRegions() {
            int region1 = random.Next(0, size);
            int region2 = random.Next(0, size);
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < matrixSize; j++) {
                    int template = field[size * region1 + i, j];
                    field[size * region1 + i, j] = field[size * region2 + i, j];
                    field[size * region2 + i, j] = template;
                }
            }
        }
        private void SwapRandomVerticalRegions() {
            int region1 = random.Next(0, size);
            int region2 = random.Next(0, size);
            for (int j = 0; j < size; j++) {
                for (int i = 0; i < matrixSize; i++) {
                    int template = field[i, size * region1 + j];
                    field[i, size * region1 + j] = field[i, size * region2 + j];
                    field[i, size * region2 + j] = template;
                }
            }
        }
        private void Transpore() {
            for (int i = 0; i < matrixSize; i++) {
                for (int j = 0; j < i; j++) {
                    int template = field[i, j];
                    field[i, j] = field[j, i];
                    field[j, i] = template;
                }
            }
        }

        //========== functions for solving ==========
        public void Solve() {
            // first 81 columns for rows, next 81 for columns, the next 81 - for squares,
            // the last 81 - for indicating what row and column is filled
            
            // fill all of possible sets
            int[,] sets = new int[729, 324];
            int index = -1;
            Stack<int> rowsWhereNumbersExist = new Stack<int>();
            Dictionary<int, AnswerItem> rowsDecryptions = new Dictionary<int, AnswerItem>();
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    int squareNumber = 3 * (i / 3) + (j / 3);
                    for (int number = 0; number < 9; number++) {
                        index++;
                        if (field[i, j] == number + 1) {
                            rowsWhereNumbersExist.Push(index);
                        }

                        rowsDecryptions[index] = new AnswerItem(i, j, number + 1);
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

            AlgorythmX algorythmX = new AlgorythmX(sets);

            // delete filled numbers
            while (rowsWhereNumbersExist.Count > 0) {
                algorythmX.DeleteRow(rowsWhereNumbersExist.Pop());
            }
            
            algorythmX.Solve();
            
            Stack<int> answer = new Stack<int>(algorythmX.GetAnswer());
            
            if (answer.Count > 0) {
                Console.WriteLine(answer.Count);
                while (answer.Count > 0) {
                    int currentItem = answer.Pop();
                    field[rowsDecryptions[currentItem].row, rowsDecryptions[currentItem].column] =
                        rowsDecryptions[currentItem].number;
                    Console.WriteLine(currentItem);
                }
            }
            else {
                Console.WriteLine("No solution");
            }
        }
        
        public void Generate() {
            // fill
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    int current_number = i + size * j;
                    for (int k = 0; k < matrixSize; k++) {
                        field[size * i + j, k] = current_number + 1;
                        current_number = (current_number + 1) % matrixSize;
                    }
                }
            }
            
            // shake
            const int numberOfOperations = 100;
            for (int i = 0; i < numberOfOperations; i++) {
                int operationType = random.Next(0, 5);
                switch (operationType) {
                    case 0: { Transpore(); break; }
                    case 1: { SwapRandomRows(); break; }
                    case 2: { SwapRandomColumns(); break; }
                    case 3: { SwapRandomHorizontalRegions(); break; }
                    case 4: { SwapRandomVerticalRegions(); break; }
                }
            }
            
            
        }

        public void Print() {
            for (int i = 0; i < matrixSize; i++) {
                for (int j = 0; j < matrixSize; j++) {
                    Console.Write("{0, 3}", field[i, j]);
                    if (j % size == size - 1) { Console.Write("{0, 3}", " "); }
                }
                Console.WriteLine();
                if (i % size == size - 1) {
                    Console.WriteLine();
                }
            }
        }
        
        
        public Sudoku(int[, ] matrix) {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.GetUpperBound(1) + 1;
            if (rows != 9 || columns != 9) {
                return;
            }

            field = matrix;
        }
    }
}