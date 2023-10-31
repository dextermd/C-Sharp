using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_ARRAYS_2
{
    internal class Program
    {
        static void PrintArray(int[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    // ширина поля может быть < 0, тогда выравнивание по левому краю
                    Console.Write($"{mas[i, j],10:F2}"); //10 - ширина поля для вывода  F4 - количество знаков после точки
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            //------------------------------------------------------
            //Для самостоятельного рассмотрения
            //------------------------------------------------------

#if true
            //---------------------------------------------------------------------------
            // Объявление двумерного массива
            // int[,]arr - это двумерный массив с фиксированным размером, 
            // и arr.Length возвращает общее количество элементов в массиве.


            //int mas[3, 4]; // Error

            int r = 2, c = 3;

            //float[,] myArr = new float[2, 3];
            // или
            float[,] myArr = new float[r, c];

            // При объявлении и оновременной инициализации размер должен быть передан как const!!!
            //int[,] myArr1 = new int[r, c] { { 1, 2, 3 }, { 3, 4, 6 } }; // ошибка

            int[,] myArr1 = new int[2, 3] { { 1, 2, 3 }, { 3, 4, 6 } }; // неименованные константы работают

            int[,] myArr2 = new int[,] { { 1, 2, 3 }, { 3, 4, 6 } };
            double[,] myArr3 = { { 10.235, 2.36, 3.125 }, { 3.124, 0.00254, 625.25 } };

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    //{0,6:F2}   ширина поля 8, 2 знака после точки F2 
                    Console.Write("{0,8:F2}  ", myArr3[i, j]);
                Console.Write("\n");
            }
            Console.WriteLine();
           
            
            /*
            При работе с многомерными массивами цикл «foreach»
            не совсем удобен, потому что он выведет элементы всех
            измерений в одну строку.
           */
            foreach (double v in myArr3)
            {
                Console.Write(v + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("\nРазмерность массива: {0}", myArr3.Rank);
            Console.WriteLine("\nКоличество элементов двумерного массива:    {0}", myArr3.Length);
            Console.WriteLine("Количество строк двумерного массива:        {0}", myArr3.GetLength(0));
            Console.WriteLine("Количество столбцов двумерного массива:     {0}\n", myArr3.GetLength(1));

            for (int i = 0; i < myArr3.GetLength(0); i++)
            {
                for (int j = 0; j < myArr3.GetLength(1); j++)
                {
                    // Console.Write(myArr3[i,j]+"  "); 
                    //Console.Write($"{myArr3[i,j],10}"); //10 - ширина поля для вывода
                    Console.Write($"{myArr3[i, j],10:F4}"); //10 - ширина поля для вывода  F4 - количество знаков после точки
                }
                Console.WriteLine();
            }

#endif


#if true
            //---------------------------------------------------------------------------
            //-----------------копия массива---------------------------------------------
            const int row = 2, col = 3; // const надо, если сразу инициализировать
            int[,] mas = new int[row, col] { { 110, 22, -312 }, { 300, 4, 60 } };
            int[,] copy = new int[row, col];

            Console.WriteLine("Исходный массив: ");
            PrintArray(mas);
            Console.WriteLine("Массив для копии: ");
            PrintArray(copy);
            Console.WriteLine();

            //copy = myArr;  // ошибка

            // -Нужна глубокая копия-----------------
            // Вариант 1 через определение размера методом GetLength

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    copy[i, j] = mas[i, j];
                }
            }
            Console.WriteLine("\nКопия массива: ");
            foreach (int v in copy)
            {
                Console.Write(v + "  ");
            }
            Console.WriteLine();


            ////Вариант 2 по размерам массива
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        copy[i, j] = mas[i, j];
            //    }
            //}



            //Вариант 3 через Array.Copy

            //int[,]arr - это двумерный массив с фиксированным размером, 
            // и arr.Length возвращает общее количество элементов в массиве.
            int[,] copy2 = new int[row, col];

            Array.Copy(mas, copy2, mas.Length);

            Console.WriteLine("\nКопия массива: ");
            foreach (int v in copy2)
            {
                Console.Write(v + "  ");
            }
            Console.WriteLine();

            mas[0, 2] = 100;// эти изменения не отражаются на копии
            Console.WriteLine("\nКопия массива: ");

            foreach (int v in copy2)
            {
                Console.Write(v + "  ");
            }
            Console.WriteLine();

#endif

            //-------------------------Трехмерный массив---------------------------------

#if true           
            int[,,] array3 = new int[3, 2, 4] {{{1, 2, 3, 25}, {4, 5, 6, 69}},
                                               {{7, 8, 9,-56}, {10, 11, 12,125}},
                                               {{8, 9, 10,-125}, {11, 12, 13,2}},
            };

            // Вывод трехмерного массива 

            Console.WriteLine("\nТрехмерный массив (3x2x4):\n");

            for (int i = 0; i < array3.GetLength(0); i++)
            {
                Console.WriteLine("Матрица: " + (i + 1));
                for (int j = 0; j < array3.GetLength(1); j++)
                {
                    for (int k = 0; k < array3.GetLength(2); k++) 
                    {
                        Console.Write($"{array3[i, j, k],5} "); 
                        //Console.Write(array3[i, j, k] + " "); 
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

#endif
            Console.ReadLine();
        }
    }
}
