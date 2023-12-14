using System;
using System.Collections.Generic;
using System.Data;
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
        public void Show()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write($"{arr[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        private bool IsSquareMatrix() => arr.GetLength(0) == arr.GetLength(1);
        public int this[string diagonal]
        {
            get
            {
                int maxValue = 0;

                if (!IsSquareMatrix())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new FormatException($"\x1b[31mМатрица не является квадратной.\x1b[0m");
                }

                switch (diagonal.ToLower())
                {
                    case "first":
                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            if (arr[i, i] > maxValue)
                                maxValue = arr[i, i];
                        }
                        break;

                    case "second":
                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            if (arr[i, arr.GetLength(0) - 1 - i] > maxValue)
                                maxValue = arr[i, arr.GetLength(0) - 1 - i];
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new FormatException($"\x1b[31mНеверное имя диагонали.\x1b[0m");
                }

                return maxValue;
            }
        }
    }
}
