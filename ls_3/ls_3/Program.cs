using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if fasle
            // Задача: отсортировать каждую строку матрицы по возрастанию
            const int row = 2, col = 3; // const надо если сразу инициализировать
            int[,] arr = new int[row, col] { { 110, 22, -312 }, { 300, 4, 60 } };
            
            // Print
            for (int i = 0; i < arr.GetLength(0); i++) 
            { 
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                // Копия текущей строки матрицы в одномерный массив
                int[] s = new int[arr.GetLength(1)];
                for (int j = 0;j < arr.GetLength(1); j++)
                {
                    s[j] = arr[i, j];
                }
                // Сортировка одномерного массива
                Array.Sort(s);
                Console.WriteLine($"Max = {s.Max()}");

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = s[j];
                }
            }

            Console.WriteLine("\nМассив после сортировки");
            // Print
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }


#endif

#if false
            // ILDASM - Microsoft Intermediate Language Disassembler


            // Массивы строки
            string str = "Hello, World!";

            Console.WriteLine(str[0]);

            //str[0] == '!';
            str += '!';
            Console.WriteLine(str);
            str = "TEST";
            Console.WriteLine(str);

            StringBuilder sb = new StringBuilder("privet", 60);
            sb.Append('!');
            sb[0] = 'P';
            Console.WriteLine(sb + " " + sb.Capacity);

            // Конструкторы:
            string line = new string('*', 20);
            Console.WriteLine(line);

            char[] math_op = { '+', '-', '/', '*', '%' };
            string operations = new string(math_op);
            Console.WriteLine(operations + " " + operations.Length);
             
            operations = new string(math_op, 2,3); // со индекса 2 взять 3 значения
            Console.WriteLine(operations + " " + operations.Length);

#endif

            Console.ReadLine();
        }
    }
}
