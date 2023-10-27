using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            //Задание 1: Пользователь вводит с клавиатуры два целых числа.Программа рассчитывает и выводит на
            //экран среднее арифметическое этих значений(дробное число, два знака после точки).
            //Проверить корректность ввода данных(обработать исключительную ситуацию).

            int num1 = 0, num2 = 0;

            Console.Write("Введите первое число: ");
            try
            {
                num1 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.Write("Введите второе число: ");
            try
            {
                num2 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }


            Console.WriteLine("Cреднее арифметическое: {0:F2}", ((num1 + num2) / 2));

#endif

#if false
            //Задание 2: Пользователь вводит с клавиатуры радиус круга(дробное число). Программа рассчитывает и
            //выводит на экран длину окружности и площадь круга.Использовать число PI математической библиотеки.
            //Формулы : длина окружности: 2PIr; площадь круга: PIr2

            NumberFormatInfo format = new NumberFormatInfo();
            format.CurrencyDecimalSeparator = ".";

            Console.Write("Введите радиус круга: ");
            double radius = double.Parse(Console.ReadLine(), format);
            double length = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;
            Console.WriteLine("Длина окружности {0:f2}, площадь круга {1:f2}", length, area);
#endif

#if false
            //Задание 3: Пользователь вводит с клавиатуры целое число в диапазоне от 1 до 100.Если число кратно 3
            //(делится на 3 без остатка) нужно вывести слово Fizz. Если число кратно 5 нужно вывести слово Buzz. Если
            //число кратно 3 и 5 нужно вывести Fizz Buzz. Если число не кратно не 3 и 5 нужно вывести само число. Если
            //пользователь ввел значение не в диапазоне от 1 до 100 требуется вывести сообщение об ошибке

            Console.Write("Введите число от 1 до 100: ");
            
            try
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 1 || num > 100)
                    throw new FormatException("Ошибка: Число должно быть от 1 до 100.");

                if (num % 3 == 0) Console.WriteLine("Fizz");
                else if (num % 5 == 0) Console.WriteLine("Buzz");
                else if (num % 3 == 0 && num % 5 == 0) Console.WriteLine("Число: " + num);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: {0}", ex.Message);
            }
#endif

#if false
            //Задание 4: Пользователь вводит с клавиатуры два целых числа.Первое число — это значение, второе число
            //процент, который необходимо посчитать. Результат вывести с двумя знаками после запятой.
            //Например, ввели с клавиатуры 127 и 4.Требуется вывести на экран 4 процентов от 127.
            //Результат: 5,08.

            int num1 = 0, num2 = 0;

            Console.Write("Введите значение: ");
            try
            {
                num1 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.Write("Введите процент: ");
            try
            {
                num2 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            double result = ((double)num1 * num2) / 100;

            Console.WriteLine("Результат: {0:F2}", result);
#endif

#if false
            //Задание 5: Пользователь вводит с клавиатуры целое число. Посчитать количество цифр в числе, сумму всех
            //цифр целого числа.Результат вывести на экран в разном цвете

            Console.Write("Введите целое число: ");
            int num = int.Parse(Console.ReadLine());
            int num_count = 0;
            int summa = 0;

            while (num != 0)
            {
                summa += num % 10;
                num_count++;
                num /= 10;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Результат: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("кол-во цыфр в числе = {0}, сумма всех чисел = {1}.", num_count, summa);
            Console.ResetColor();
            
#endif

#if false
            //Задание 6: Даны целые положительные числа a и b(a < b).Вывести все целые числа от a до b включительно;
            //каждое число должно выводиться на новой строке; при этом каждое число должно выводиться количество
            //раз, равное его значению.
            //Например: если a = 3, а b = 7, то программа должна сформировать в консоли следующий вывод:
            // 3 3 3
            // 4 4 4 4
            // 5 5 5 5 5
            // 6 6 6 6 6 6
            // 7 7 7 7 7 7 7

            int a = 3, b = 7;
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.Write("\n");
            }

#endif

#if false
            //Задание 7: Пользователь вводит с клавиатуры два целых числа.Нужно показать все четные числа в
            //указанном диапазоне. Если границы диапазона указаны неправильно требуется произвести нормализацию
            //границ.
            //Например, пользователь ввел 20 и 11, требуется нормализация, после которой начало
            //диапазона станет равно 11, а окончание 20.

            int num1 = 0, num2 = 0, min = 0, max = 0;

            Console.Write("Введите первое число: ");
            try
            {
                num1 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            Console.Write("Введите второе число: ");
            try
            {
                num2 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            min = (num1 < num2) ? num1 : num2;
            max = (num1 < num2) ? num2 : num1;

            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                    Console.Write("{0} ", i);
            }

#endif

#if false
            //Задание 8: Пользователь вводит с клавиатуры пять целых чисел.Необходимо найти сумму чисел,
            //максимум и минимум, произведение чисел.Результат вычислений вывести на экран в разном цвете.

            int[] numbers = new int[5];
            int summa = 0;
            for (int i = 0; i < 5; i++)
            {
                summa += numbers[i];
                Console.Write("Введите число №{0}: ", i + 1);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Максимум: {0}, Минимум: {1}", numbers.Min(), numbers.Max());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сумма чисел = {0}", summa);
            Console.ResetColor();
#endif
            Console.ReadLine();

        }
    }
}
