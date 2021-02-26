using System;
using System.Collections.Generic;

namespace Lab1 {
    public class AlgorythmX {
        private Dictionary<int, HashSet<int>> columns;
        private List<List<int>> rows;
        private Stack<int> answer;
        private Stack<HashSet<int>> deletedColumns;
        private bool solved;
        

        public AlgorythmX(int[,] matrix) {
            rows = new List<List<int>>();
            columns = new Dictionary<int, HashSet<int>>();
            answer = new Stack<int>();
            deletedColumns = new Stack<HashSet<int>>();
            solved = false;
            
            int colsCount = matrix.GetUpperBound(1) + 1;
            int rowsCount = matrix.GetUpperBound(0) + 1;
            for (int i = 0; i < rowsCount; i++) {
                bool isEmpty = true;
                for (int j = 0; j < colsCount; j++) {
                    if (matrix[i, j] != 0) {
                        if (isEmpty) {
                            rows.Add(new List<int>());
                            isEmpty = false;
                        }
                        rows[i].Add(j);
                    }
                }
            }

            for (int j = 0; j < colsCount; j++) {
                for (int i = 0; i < rowsCount; i++) {
                    if (matrix[i, j] != 0) {
                        if (!columns.ContainsKey(j)) {
                            columns[j] = new HashSet<int>();
                        }
                        columns[j].Add(i);
                    }
                }
            }
        }

        private void ExtractRow(int row) {
            foreach (var column in rows[row]) {
                var columnElements = new HashSet<int>(columns[column]);
                deletedColumns.Push(columnElements);
                foreach (var deletingRow in columnElements) {
                    foreach (var columnContainsDeletingRow in rows[deletingRow]) {
                        columns[columnContainsDeletingRow].Remove(deletingRow);
                    }
                }
                columns.Remove(column);
            }
        }

        public void DeleteRow(int row) {
            ExtractRow(row);
            deletedColumns.Clear();
        }

        private void InsertRow(int row) {
            rows[row].Reverse();
            foreach (var column in rows[row]) {
                columns[column] = new HashSet<int>(deletedColumns.Pop());
            }

            foreach (var column in rows[row]) {
                var columnElements = new HashSet<int>(columns[column]);
                foreach (var insertingRow in columnElements) {
                    foreach (var columnToInsertRow in rows[insertingRow]) {
                        columns[columnToInsertRow].Add(insertingRow);
                    }
                }
            }
            rows[row].Reverse();
        }

        public void Solve() {
            if (columns.Count == 0) {
                solved = true;
                return;
            }

            int minSize = 10000, minColumnNumber = -1;
            foreach (var column in columns.Keys) {
                if (columns[column].Count < minSize && columns[column].Count > 0) {
                    minSize = columns[column].Count;
                    minColumnNumber = column;
                }
            }

            if (minColumnNumber == -1) {
                return;
            }

            HashSet<int> minColumnRows = new HashSet<int>(columns[minColumnNumber]);
            foreach (int row in minColumnRows) {
                answer.Push(row);
                ExtractRow(row);
                Solve();
                if (solved) {
                    return;
                }
                InsertRow(row);
                answer.Pop();
            }
        }

        public Stack<int> GetAnswer() {
            Console.WriteLine(solved);
            return answer;
        }
    }
}