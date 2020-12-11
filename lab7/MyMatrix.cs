using System;

namespace lab7 {
    public class MyMatrix {
        private int _colums;
        private int _rows;
        private int[][] _matrix;
        public MyMatrix(int colums, int rows) {
            if (colums < 0 || rows < 0) {
                throw new Exception("Невірно задані параметри");
            }
            
            _colums = colums;
            _rows = rows;
            generateMatrix();
        }

        public MyMatrix() {
        }

        public int Colums {
            get => _colums;
            set {
                if (value > _colums) {
                    _colums = value;
                    generateMatrix();
                }
                else {
                    _colums = value;
                }
            }
        }

        public int Rows {
            get => _rows;
            set {
                if (value > _rows) {
                    _rows = value;
                    generateMatrix();
                }
                else {
                    _rows = value;
                }
            }
        }

        private void generateMatrix() {
            Random random = new Random();
            _matrix = new int[_rows][];
            for (int i = 0; i < _rows; i++) {
                _matrix[i] = new int[_colums];
            }
            for (int i = 0; i < _rows; i++) {
                for (int j = 0; j < _colums; j++) {
                    _matrix[i][j] = random.Next(-50, 50);
                }
            }
        }

        public string getMatrix() {
            string result = "";
            for (int i = 0; i < _rows; i++) {
                for (int j = 0; j < _colums; j++) {
                    result += _matrix[i][j] + "\t";
                }

                result += Environment.NewLine;
            }
            
            
            return result;
        }
    }
}