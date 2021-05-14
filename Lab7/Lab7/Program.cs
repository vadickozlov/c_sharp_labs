using System;

namespace Lab7 {
    class Program {
        static void Main(string[] args) {
            Fraction fr1 = new Fraction(1, 5);
            Console.WriteLine("fr1 in different formats: ");
            Console.WriteLine(fr1.ToString());
            Console.WriteLine(fr1.ToString("D"));
            Console.WriteLine(fr1.ToString("M"));
            Console.WriteLine(fr1.ToString("I"));
            
            Fraction fr2 = new Fraction(50, 15);
            Console.WriteLine("fr2 in different formats: ");
            Console.WriteLine(fr2.ToString());
            Console.WriteLine(fr2.ToString("D"));
            Console.WriteLine(fr2.ToString("M"));
            Console.WriteLine(fr2.ToString("I"));
            
            Fraction fr3 = fr1 + fr2;
            Console.WriteLine($"fr1 + fr2 " + fr3.ToString("M"));
            fr3 = fr1 - fr2;
            Console.WriteLine($"fr1 - fr2 " + fr3.ToString("M"));
            fr3 = fr1 * fr2;
            Console.WriteLine($"fr1 * fr2 " + fr3.ToString("M"));
            fr3 = fr1 / fr2;
            Console.WriteLine($"fr1 / fr2 " + fr3.ToString("M"));
            Fraction fr4;
            if (Fraction.TryParse("-3(2/15)", out fr4)) {
                Console.WriteLine($"Result of parsing -3(2/15): {fr4.ToString()}");
            }

            double number = fr4;
            int intNumber = (int) fr4;
            Console.WriteLine($"Cast of fr4 to double: {number}");
            Console.WriteLine($"Cast of fr4 to int: {intNumber}");
        }
    }
}