using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Task1 {
    class Program {
        static bool IsVowel(char character) {
            return character == 'a' || 
                   character == 'e' || 
                   character == 'i' || 
                   character == 'o' || 
                   character == 'u' ||
                   character == 'y';
        }

        static void Main(string[] args) {
            /*
             *  Дана строка, состоящая из строчных английских букв.
             *  Заменить в ней все буквы, стоящие после гласных,
             *  на следующие по алфавиту (z заменяется на a).
             */
            StringBuilder str = new StringBuilder(Console.ReadLine());
            for (int i = 0; i < str.Length; i++) {
                if (!Char.IsLetter(str[i]) || !Char.IsLower(str[i])) {
                    Console.WriteLine("ERROR: Invalid input. Only lowercase english letters.");
                }
            }

            Stack<int> positions = new Stack<int>();
            for (int i = 1; i < str.Length; i++) {
                if (IsVowel(str[i - 1])) {
                    positions.Push(i);
                }
            }

            while (positions.Count > 0) {
                int currentPosition = positions.Pop();
                str[currentPosition] = LowerCaseAlphabet.GetLetter(LowerCaseAlphabet.GetIndex(str[currentPosition]) + 1);
            }
            
            Console.WriteLine(str);

        }
    }
}