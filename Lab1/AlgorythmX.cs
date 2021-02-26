using System;
using System.Collections.Generic;

namespace Lab1 {
    public class AlgorythmX {
        private Dictionary<int, HashSet<int>> _columns;
        private List<List<int>> _rows;
        private Stack<int> _answer;
        private Stack<HashSet<int>> _deletedColumns;
        private bool _solved;

        public AlgorythmX(int[,] matrix) {
            _rows = new List<List<int>>();
            _columns = new Dictionary<int, HashSet<int>>();
            _answer = new Stack<int>();
            _deletedColumns = new Stack<HashSet<int>>();
            _solved = false;

            int colsCount = matrix.GetUpperBound(1) + 1;
            int rowsCount = matrix.GetUpperBound(0) + 1;
            for (int i = 0; i < rowsCount; i++) {
                bool isEmpty = true;
                for (int j = 0; j < colsCount; j++) {
                    if (matrix[i, j] != 0) {
                        if (isEmpty) {
                            _rows.Add(new List<int>());
                            isEmpty = false;
                        }
                        _rows[i].Add(j);
                    }
                }
            }

            for (int j = 0; j < colsCount; j++) {
                for (int i = 0; i < rowsCount; i++) {
                    if (matrix[i, j] != 0) {
                        if (!_columns.ContainsKey(j)) {
                            _columns[j] = new HashSet<int>();
                        }
                        _columns[j].Add(i);
                    }
                }
            }
        }

        private void ExtractRow(int row) {
            foreach (var column in _rows[row]) {
                var columnElements = new HashSet<int>(_columns[column]);
                _deletedColumns.Push(columnElements);
                foreach (var deletingRow in columnElements) {
                    foreach (var columnContainsDeletingRow in _rows[deletingRow]) {
                        _columns[columnContainsDeletingRow].Remove(deletingRow);
                    }
                }
                _columns.Remove(column);
            }
        }

        public bool DeleteRow(int row) {
            // deleting row and all intersections with it
            // returns true if deleted successfully, false if 
            // at least one column was covered earlier
            foreach (var column in _rows[row]) {
                if (!_columns.ContainsKey(column)) {
                    return false;
                }
            }
            ExtractRow(row);
            _deletedColumns.Clear();
            return true;
        }

        private void InsertRow(int row) {
            _rows[row].Reverse();
            foreach (var column in _rows[row]) {
                _columns[column] = new HashSet<int>(_deletedColumns.Pop());
            }

            foreach (var column in _rows[row]) {
                var columnElements = new HashSet<int>(_columns[column]);
                foreach (var insertingRow in columnElements) {
                    foreach (var columnToInsertRow in _rows[insertingRow]) {
                        _columns[columnToInsertRow].Add(insertingRow);
                    }
                }
            }
            _rows[row].Reverse();
        }

        public void Solve() {
            if (_columns.Count == 0) {
                // input set is empty, we filled it
                _solved = true;
                return;
            }
            
            // searching for column with minimal count of items
            int minSize = 10000, minColumnNumber = -1;
            foreach (var column in _columns.Keys) {
                if (_columns[column].Count < minSize && _columns[column].Count > 0) {
                    minSize = _columns[column].Count;
                    minColumnNumber = column;
                }
            }
            
            // if we have columns, but all of them are empty, then 
            // we haven't subsets, but set wasn't filled, that's dead end
            if (minColumnNumber == -1) {
                return;
            }
            
            HashSet<int> minColumnRows = new HashSet<int>(_columns[minColumnNumber]);
            foreach (int row in minColumnRows) {
                // try to take every row if this column to the answer,
                // cover set with it, delete all intersecting rows and search answer
                // recursively 
                _answer.Push(row);
                ExtractRow(row);
                Solve();
                if (_solved) {
                    return;
                }
                // if we didn't find the answer with this row, return it 
                // and all intersecting rows
                InsertRow(row);
                _answer.Pop();
            }
        }

        public Stack<int> GetAnswer() {
            return _answer;
        }

        public bool SolutionFound() {
            return _solved;
        }
    }
}