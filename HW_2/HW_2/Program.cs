using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HW_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //Задача 1: Написать программу, которая инициализирует одномерный массив целых значениями
            //с клавиатуры.

            int size;
            int[] arr;

            Console.Write("Введите размер массива: ");
            size = int.Parse(Console.ReadLine());
            arr = new int[size];

            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write($"Введите значение №{ i + 1 }: ");
                arr[i] = int.Parse(Console.ReadLine()); ;
            }

            Console.Write("\nВведенный массив: ");
            foreach (var item in arr)
                Console.Write($"{item}  ");

#endif

#if false
            //Задание 2: Напишите приложение, отображающее количество значений в одномерном массиве
            //целого типа меньше заданного пользователем значения(вводится с клавиатуры).Размер массива
            //также запрашивается у пользователя, элементы массива инициализируются случайными
            //значениями в диапазоне, который вводит пользователь.

            int[] arr;
            int size, min = 0, max = 0, input_num = 0;
            Random rn = new Random();

            Console.Write("Введите размер массива: ");
            size = int.Parse(Console.ReadLine());
            arr = new int[size];

            do
            {
                Console.Clear();
                Console.Write("Введите дипозон от: ");
                min = int.Parse(Console.ReadLine());
                Console.Write("Введите дипозон до: ");
                max = int.Parse(Console.ReadLine());
            } while (min >= max);


            for (int i = 0; i < arr.Length; i++)
            {
                int num = rn.Next(min, max + 1);
                arr[i] = num;
            }

            Console.Write("Введите значение: ");
            input_num = int.Parse(Console.ReadLine());
            foreach (var item in arr)
            {
                if (item < input_num)
                {
                    Console.Write($"{item} ");
                }
            }

#endif

#if false
            //Задание 3: Дан двумерный массив размерностью 5×5, заполненный случайными числами из
            //диапазона от –100 до 100.Определить сумму элементов массива, расположенных между
            //минимальным и максимальным элементами.
            int[,] arr = new int[5,5];
            int summa;
            Random rn = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                summa = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = rn.Next(-100, 100);
                    summa += arr[i,j];
                    string f_num = $"{arr[i, j], 4}";
                    Console.Write($"{f_num} ");
                }
                Console.Write($" Summa = {summa}");
                Console.WriteLine();
            }
#endif

#if false
            //Задание 4: Объявить одномерный(5 элементов) массив с именем A и двумерный массив (3
            //строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный массив А числами,
            //введенными с клавиатуры пользователем, а двумерный массив В случайными числами с помощью циклов.
            //Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы.
            //Найти в данных массивах общий максимальный элемент, минимальный элемент,

            //общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов
            //массива А, сумму нечетных столбцов массива В.

            int[] a = new int[5];
            double[,] b = new double[3, 4];
            Random rn = new Random();
            int aMax, aMin, summa = 0, summa2 = 0, evenASumma = 0;
            long mult = 1;
            double oddBSumma = 0;
            double bMin = b[0, 0];
            double bMax = b[0, 0];

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"Введите значение №{i + 1}: ");
                a[i] = int.Parse(Console.ReadLine());
                summa += a[i];
                mult *= a[i];
                if (a[i] % 2 == 0)
                    evenASumma += a[i];
            }

            aMin = a.Min();
            aMax = a.Max();

            Console.Write("Одномерный массив A: ");

            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine("Двумерный массив B: ");

            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = rn.NextDouble() * (100 - 1) + 1;
                    summa += (int)b[i, j];
                    string f_num = string.Format("{0:F2} ", b[i, j]);
                    Console.Write("{0} ", f_num, 4);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    mult *= (long)b[i, j];
                    if (b[i, j] < bMin)
                        bMin = b[i, j];

                    if (b[i, j] > bMax)
                        bMax = b[i, j];
                    
                    if ((b[i, j] % 2 != 0))
                        oddBSumma += b[i, j];
                }
            }

            if(aMax == (int)bMax)
                Console.WriteLine($"Общий максимальный элемент: {aMax}");
            if (aMin == (int)bMin)
                Console.WriteLine($"Общий минимальный элемент: {aMin}");

            Console.WriteLine($"Общее произведение всех элементов: {mult}");
            Console.WriteLine($"Общая сумма всех элементов: {summa}");
            Console.WriteLine($"Общая сумма четных элементов массива А: {evenASumma}");
            Console.WriteLine($"Общая сумма нечетных элементов массива B: {oddBSumma:F2}");

#endif

#if false
            //Задание 5: Написать программу, которая формирует зубчатый массив целых. Количество строк
            //пользователь вводит с клавиатуры. Количество колонок – случайное число в диапазоне от 1 до 10.
            //Элементы массива инициализируются случайными значениями в диапазоне, заданном
            //пользователем.

            Console.Write("Введите количество строк: ");
            int count_rows = int.Parse(Console.ReadLine());
            Random random = new Random();

            int[][] arr = new int[count_rows][];

            for (int i = 0; i < count_rows; i++)
            {
                int count_col = random.Next(1, 11);
                arr[i] = new int[count_col];
            }

            Console.Write("Введите минимальное значение для элементов массива: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальное значение для элементов массива: ");
            int max= int.Parse(Console.ReadLine());

            for (int i = 0; i < count_rows; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = random.Next(min, max + 1);
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }


#endif

            // Дополнительное задание
#if false
            //Задание 6: Пользователь вводит с клавиатуры три числа. Необходимо подсчитать сколько раз
            //последовательность из этих трёх чисел встречается в массиве.
            //Например: пользователь ввёл: 7 6 5;
            //        массив: 7 6 5 3 4 7 6 5 8 7 6 5;
            //количество повторений последовательности: 3.

            int count = 0;

            Console.Write("Введите 3 числа: ");
            int num = int.Parse(Console.ReadLine());

            int[] arr = { 7, 6, 5, 3, 4, 7, 6, 5, 8, 7, 6, 5 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == (num / 100))
                    i = (i <= arr.Length - 1) ? i++ : i;
                    if (arr[i] == (num / 10 % 10))
                        i = (i <= arr.Length - 1) ? i++ : i;
                        if (arr[i] == (num % 10))
                            count++;
            }

            Console.WriteLine($"Количество повторений последовательности: {count}");

#endif
            // Дополнительное задание
#if false
            //Задание 7: Разработайте приложение, которое будет находить минимальное и максимальное
            //значение в двумерном массиве.Также программа определяет минимальные и максимальные
            //значения по каждой строке(выводит справа от каждой строки) и по каждому столбцу(выводит
            //ниже матрицы).

            int[,] arr = new int[5, 6];
            int min_col = arr[0, 0];
            int min_row = arr[0, 0];
            int min = arr[0, 0];
            int max = arr[0, 0];
            Random rn = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                min_col = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rn.Next(-100, 100);
                    
                    if (arr[i, j] < min)
                        min = arr[i, j];

                    if (arr[i, j] > max)
                        max = arr[i, j];

                    if (arr[i, j] < min_col)
                        min_col = arr[i, j];

                    string f_num = $"{arr[i, j],4}";
                    Console.Write($"{f_num} ");
                    
                }
                
                Console.Write($" | {min_col}");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------");
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                min_row = arr[0, i];
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] < min_row)
                        min_row = arr[j, i];
                }
                Console.Write($" {min_row} ");
            }

            Console.WriteLine();
            Console.WriteLine($"\nArr (min = {min}, max = {max})");

#endif
            // Дополнительное задание
#if false
            //Задание 8: Даны 2 одномерных массива размерности M и N соответственно.Необходимо
            //переписать в третий массив общие элементы первых двух массивов без повторений.
            int[] arr1 = { 8, 45, 9, 465, 78, 8, };
            int[] arr2 = { 8, 10, 9, 465, 18, 8, 10, 55 };


            int[] arr3 = arr2.Where(v => arr1.Contains(v)).Distinct().ToArray();

            foreach (var v in arr3)
            {
                Console.Write($"{v}  ");
            }
#endif
            Console.ReadLine();
        }
    }
}
