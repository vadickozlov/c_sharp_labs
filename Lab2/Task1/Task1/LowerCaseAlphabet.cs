using System.Text;

namespace Task1 {
    class LowerCaseAlphabet {
        private static StringBuilder alphabet = new StringBuilder("abcdefghijklmnopqrstuvwxyz");

        public static char GetLetter(int index) {
            return alphabet[index % 26];
        }

        public static int GetIndex(char letter) {
            for (int i = 0; i < 26; i++) {
                if (alphabet[i] == letter) {
                    return i;
                }
            }

            return -1;
        }
    }
}