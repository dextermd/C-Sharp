using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_10
{
    internal class Matrix
    {
        //Пример двумерного индексатора
        int[,] arr;
        public int rows, cols; // Размерность двухмерного массива
        public int Length;
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            arr = new int[this.rows, this.cols];
            Length = rows * cols;
        }
        public int this[int index1, int index2] // Индексатор
        {
            get
            {
                return arr[index1, index2];
            }
            set
            {
                arr[index1, index2] = value;
            }
        }
    }
}
