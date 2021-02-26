namespace Lab1 {
    public class Node {
        public Node left, right, top, bottom;
        private int column;

        public Node() {
            left = right = top = bottom = this;
        }

        public void setColumn(int column) {
            this.column = column;
        }                                                                                                                           

        public void addLeft(Node node) {
            left = node;
            node.right = this;
        }
        public void addRight(Node node) {
            right = node;
            node.left = this;
        }
        public void addTop(Node node) {
            top = node;
            node.bottom = this;
        }
        public void addBottom(Node node) {
            bottom = node;
            node.top = this;
        }
    }
}