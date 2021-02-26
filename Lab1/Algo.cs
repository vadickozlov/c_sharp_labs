using System;
using System.Collections.Generic;
using System.Data;

namespace Lab1 {
    public class Algo {
        private struct AnswerItem {
            public int row, column, number;

            public AnswerItem(int row, int column, int number) {
                this.row = row;
                this.column = column;
                this.number = number;
            }
        }

        public int[,] arr =
        {
            {1, 0, 1, 0, 0, 0},
            {0, 1, 0, 0, 1, 1},
            {0, 0, 0, 1, 0, 0},
            {0, 0, 1, 1, 1, 0},
            {1, 0, 1, 0, 0, 1},
            {1, 0, 1, 0, 0, 1},
        };

        private Stack<AnswerItem> solution;
        
        public TwoDimentionalDoubleLinkedList sets;

        public Algo() {
            sets = new TwoDimentionalDoubleLinkedList(arr);
            for (int i = 0; i < 6; i++) {
                Console.WriteLine(sets.ColumnSize(i));
            }
        }

        public void Solve() {
            int minColumn = -1, minSize = 10000;
            for (int i = 0; i < 6; i++) {
                if (sets.ColumnSize(i) < minSize) {
                    minSize = sets.ColumnSize(i);
                    minColumn = i;
                }
            }

            if (minColumn == -1) {
                // can't add
                return;
            }

            for (Node node = sets.columns[minColumn].bottom; node.bottom != node; node = node.bottom) {
                
            }

        }
    }
}