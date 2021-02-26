using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Lab1 {
    class Program {
        static void Main(string[] args) {
            int[,] matrix = new int[9, 9];
            Console.WriteLine("Enter your sudoku");
            Console.WriteLine("Unknown values enter as 0 (zero)");
            
            // input with validation
            for (int i = 0; i < 9; i++) {
                bool goodInput;
                do {
                    // read until we get valid row
                    goodInput = true;
                    
                    string input = Console.ReadLine();
                    string[] split = input.Split(' ');
                    List<string> numbers = new List<string>();
                    // filter multiple spaces
                    foreach (string s in split) {
                        if (s.Length > 0) {
                            numbers.Add(s);
                        }
                    }
                    
                    if (numbers.Count > 9) {
                        Console.WriteLine("Oh, too many columns, I need only 9 :)");
                        goodInput = false;
                    }

                    if (numbers.Count < 9) {
                        Console.WriteLine("Oh, too few columns, I need 9");
                        goodInput = false;
                    }

                    foreach (string s in numbers) {
                        // checking for a number
                        for (int index = 0; index < s.Length; index++) {
                            if (!Char.IsDigit(s[index])) {
                                Console.WriteLine("Incorrect input. You can enter only 0-9 numbers");
                                goodInput = false;
                            }
                        }

                        // if it's number, it should have only 1 digit
                        if (s.Length > 1) {
                            Console.WriteLine($"You entered too big number ({s})");
                            goodInput = false;
                        }
                    }

                    if (!goodInput) {
                        Console.WriteLine("\nTry to enter row again");
                    } else {
                        for (int j = 0; j < 9; j++) {
                            matrix[i, j] = Convert.ToInt32(numbers[j]);
                        }    
                    }
                } while (!goodInput);
            }
            

            Sudoku sudoku = new Sudoku(matrix);
            bool solved = sudoku.Solve();
            if (solved) {
                Console.WriteLine("Solution found! :)\n");
                sudoku.Print();
            }
        }
    }
}
