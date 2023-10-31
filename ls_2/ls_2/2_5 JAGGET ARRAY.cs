using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
             Зубчатый массив(jagged) представляет собой МАССИВ МАССИВОВ -
             в каждой ячейке такого массива располагается одномерный массив.
*/

/*
От многомерных массивов надо отличать 
МАССИВ МАССИВОВ или так называемый "зубчатый массив":


int[][] nums = new int[3][];
nums[0] = new int[2] { 1, 2 };          // выделяем память для первого подмассива
nums[1] = new int[3] { 1, 2, 3 };       // выделяем память для второго подмассива
nums[2] = new int[5] { 1, 2, 3, 4, 5 }; // выделяем память для третьего подмассива

Здесь две группы квадратных скобок указывают, что это массив массивов, 
то есть такой массив, который в свою очередь содержит в себе другие массивы. 

Причем длина массива указывается только в первых квадратных скобках, 
все последующие квадратные скобки должны быть пусты: new int[3][]. 

В данном случае у нас массив nums содержит три массива. 
Причем размерность каждого из этих массивов может не совпадать.

Альтернативное определение массива массивов:

    int[][] numbers = { 
        new int[] { 1, 2 }, 
        new int[] { 1, 2, 3 }, 
        new int[] { 1, 2, 3, 4, 5 } 
    };
 */

namespace _2_5_JAGGET_ARRAY
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //------------------------------------------------------
            //Для самостоятельного рассмотрения
            //------------------------------------------------------

            // Вариант 1
            int[][] nums = new int[3][];
            nums[0] = new int[4] { -51, 20, 754, 8 };          // выделяем память для первого подмассива
            nums[1] = new int[3] { 47, 21, 1 };       // выделяем память для второго подмассива
            nums[2] = new int[5] { 2, 89, 5, -91, 6 }; // выделяем память для третьего подмассива

           
            // Вариант 2
            int[][] numbers = {
                    new int[] { -51, 20, 754, 8 },
                    new int[] { 47, 21, 1 },
                    new int[] { 2, 89, 5, -91, 6 }
                };

            // перебор с помощью цикла for
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // перебор с помощью цикла foreach
            foreach (int[] row in numbers)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");


            // Копия массива Array.Copy

            int[][] copy = new int[numbers.Length][];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != null)
                {
                    copy[i] = new int[numbers[i].Length];
                    Array.Copy(numbers[i], copy[i], numbers[i].Length);
                }
            }


            numbers[1][2] = 100;// Изменения оригинала не повлияют на копию

            Console.WriteLine("Копия массива");
            foreach (int[] row in copy)
            {
                foreach (int v in row)
                {
                    Console.Write($"{v} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
