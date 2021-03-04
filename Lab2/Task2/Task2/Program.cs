using System;

namespace Task2 {
    class Program {
        static void Main(string[] args) {
            /*
             *  Получить текущее время и дату в двух разных форматах
             *  и вывести на экран количество нулей, единиц, …, девяток в их записи.
             */
            
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime.ToLongDateString());
            Console.WriteLine(dateTime.ToLongTimeString());
            Console.WriteLine(dateTime.ToShortDateString());
            Console.WriteLine(dateTime.ToUniversalTime());

            string strDateTime = dateTime.ToUniversalTime().ToString();
            int[] countOfDigit = new int[10];
            foreach (var character in strDateTime) {
                if (Char.IsDigit(character)) {
                    countOfDigit[character - '0']++;
                }
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"Count of '{i}' is {countOfDigit[i]}");
            }
        }
    }
}