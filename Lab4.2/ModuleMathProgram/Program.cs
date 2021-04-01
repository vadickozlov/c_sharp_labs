using System;
using System.Runtime.InteropServices;

namespace MathModuleApp {
    class Program {
        [DllImport("ModuleMath.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern Int64 C(Int64 n, Int64 k, Int64 mod);

        [DllImport("ModuleMath.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern Int64 Factorial(Int64 n, Int64 mod);

        [DllImport("ModuleMath.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern Int64 BinPow(Int64 number, Int64 degree, Int64 mod);
        static void Main(string[] args) {
            Console.WriteLine(C(5, 4, 1000000007));
            Console.WriteLine(Factorial(100, 1000000007));
            Console.WriteLine(BinPow(-3, 5, 1000000007));
            Console.ReadLine();
        }
    }
}