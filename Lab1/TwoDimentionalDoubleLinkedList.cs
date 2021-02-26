using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace Lab1 {
    public class TwoDimentionalDoubleLinkedList {
        public Node[] columns;
        private int[] columnsSizes;
        
        public TwoDimentionalDoubleLinkedList(int[,] matrix) {
            int columnsCount = matrix.GetUpperBound(1) + 1;
            int rowsCount = matrix.GetUpperBound(0) + 1;
            
            columns = new Node[columnsCount];
            columnsSizes = new int[columnsCount];

            for (int i = 0; i < columnsCount; i++) {
                columns[i] = new Node();
                columns[i].setColumn(i);
            }

            int[,] nodesID = new int[rowsCount, columnsCount];
            
            List<Node> nodes = new List<Node>();
            int currentID = -1;
            for (int i = 0; i < rowsCount; i++) {
                for (int j = 0; j < columnsCount; j++) {
                    if (matrix[i, j] != 0) {
                        currentID++;
                        nodes.Add(new Node());
                        nodesID[i, j] = currentID;
                    }
                }
            }
            // link vertically
            int last;
            for (int j = 0; j < columnsCount; j++) {
                last = -1;
                for (int i = 0; i < rowsCount; i++) {
                    if (matrix[i, j] != 0) {
                        columnsSizes[j]++;
                        if (last == -1) {
                            // the first in the column, linking with the root
                            columns[j].bottom = nodes[nodesID[i, j]];
                        }
                        else {
                            nodes[nodesID[i, j]].addTop(nodes[nodesID[last, j]]);
                        }
                        last = i;
                    }
                }
            }
            // link horizontally
            
            for (int i = 0; i < rowsCount; i++) {
                last = -1;
                for (int j = 0; j < columnsCount; j++) {
                    if (matrix[i, j] != 0) {
                        if (last != -1) {
                            nodes[nodesID[i, j]].addLeft(nodes[nodesID[i, last]]);
                        }
                        last = j;
                    }
                }
            }
        }

        public int ColumnSize(int column) {
            return columnsSizes[column];
        }

        private void DisableRow(Node rowNode) {
            while (rowNode.left != rowNode) {
                rowNode = rowNode.left;
            }
            for (Node node = rowNode; node.right != node; node = node.right) {
                node.top.bottom = node.bottom;
                node.bottom.top = node.top;
            }
        }

        public void ExtractRow(Node rowNode) {
            while (rowNode.left != rowNode) {
                rowNode = rowNode.left;
            }
            for (Node node = rowNode; node.right != node; node = node.right) {
                for (Node nodeOfRowToDisable = node;
                    nodeOfRowToDisable.top != node;
                    nodeOfRowToDisable = nodeOfRowToDisable.top) {
                    DisableRow(nodeOfRowToDisable);
                }
                for (Node nodeOfRowToDisable = node;
                    nodeOfRowToDisable.bottom != node;
                    nodeOfRowToDisable = nodeOfRowToDisable.bottom) {
                    DisableRow(nodeOfRowToDisable);
                }
            }
            
        }

    }
}