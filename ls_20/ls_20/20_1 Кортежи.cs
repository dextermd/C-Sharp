using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_1_Кортежи
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, int, string, double> tuple = new Tuple<int, int, string, double>(5, 15, "Hello", 25.5);
            Console.WriteLine($"{tuple.Item1}  {tuple.Item2}  {tuple.Item3}  {tuple.Item4}");

            // Неявное определение типа
            var tuple2 = ("Sokolov", 100_000_000);
            tuple2.Item2 += 500;
            Console.WriteLine($"{tuple2.Item1}  {tuple2.Item2}");

            var tuple3 = ("Marks", new List<int> { 10, 6, 9, 12, 12, 12 });
            Console.WriteLine($"{tuple3.Item1}  {string.Join(" ", tuple3.Item2)}");


            // Явное определение типа
            (int, int) tuple4 = (15, 20);

            // Можно задавать имена полям
            var tuple5 = (name: "Skittles", salary: 100);
            Console.WriteLine($"{tuple5.name}  {tuple5.salary}");


            string str1 = "C++";
            string str2 = "C#";
            Console.WriteLine($"{str1} {str2}");
            (str1, str2) = (str2, str1);// обмен значениями
            Console.WriteLine($"{str1} {str2}");

            // декомпозиция tuple4 на отдельные переменные
            var (a, b) = tuple4;
            Console.WriteLine($"{a}   {b}"); // 15   20


            // Воврат значений из метода
            // Написать метод, который подсчитывает количество : четных, нечетных, полож., отриц.
            // значений массива и возвращает результат из функции.

            int []m=new int[] {12,-25,1,2,4,156,-8,0,23,44,-3};
            var counts = CountValue(m);
            Console.WriteLine($"\nКоличетсов четных: {counts.Item1}" +
                $"\nКоличество нечетных: {counts.Item2}" +
                $"\nКоличество положительных: {counts.Item3}" +
                $"\nКоличество отрицательных: {counts.Item4}");

            Console.Read();
        }
        public static (int, int, int, int) CountValue(int[]mas)
        {
            int even=0, odd=0, pos=0, neg=0;
            foreach (var item in mas)
            {
                if (item % 2 == 0) even++;
                else odd++;
                if(item >=0) pos++;
                else neg++;
            }
            return (even, odd, pos, neg);// Неименованный кортеж
        }
    }
}
