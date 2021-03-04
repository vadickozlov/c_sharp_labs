using System;

namespace Task3 {
    class Program {
        static void Main(string[] args) {
            /*•	Реализовать эффективное перемешивание символов строки. */
            Random rnd = new Random();
            string str = Console.ReadLine();
            int[] permutation = new int[str.Length];
            for (int i = 0; i < str.Length; i++) {
                permutation[i] = i;
            }

            for (int i = 0; i < str.Length - 1; i++) {
                int pos = rnd.Next(i + 1, str.Length - 1);
                (permutation[i], permutation[pos]) = (permutation[pos], permutation[i]);
            }

            for (int i = 0; i < str.Length; i++) {
                Console.Write(str[permutation[i]]);
            }
        }
    }
}