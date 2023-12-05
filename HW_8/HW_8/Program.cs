using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            /*
                Задание 1: Пользователь вводит с клавиатуры в строку набор 0 и 1. Необходимо преобразовать
                строку в число целого типа в десятичном представлении. Предусмотреть случай выхода за
                границы диапазона, определяемого типом int, неправильный ввод. Используйте механизм
                исключений.
            */

            Console.Write("Введите набор 0 и 1: ");
            string input = Console.ReadLine();

            try
            {
                int result = Convert.ToInt32(input, 2);
                Console.WriteLine($"Десятичное представление: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод. Введите только 0 и 1.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Выход за границы диапазона int.");
            }


#endif

#if false
            /*
                Задание 2: Пользователь вводит в строку с клавиатуры математическое выражение. Например,
                3*2*1*4. Программа должна посчитать результат введенного выражения. В строке могут быть
                только целые числа и оператор *. Для обработки ошибок ввода используйте механизм
                исключений.
            */
            Console.Write("Введите математическое выражение: ");
            string input = Console.ReadLine();
            string[] tmp = input.Split('*');
            try
            {
                int[] numbers = tmp.Select(x => int.Parse(x)).ToArray(); 
                int result = 1;
                for (int i = 0; i < numbers.Length; i++) //int result = numbers.Aggregate((x, y) => x * y);
                {
                    result *= numbers[i];
                }
                Console.WriteLine($"{result}");
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
#endif

#if true
            /*
                Задание 3: Пользователь вводит в строку с клавиатуры логическое выражение. Например, 3>2 или
                7<3. Программа должна посчитать результат введенного выражения и дать результат true или
                false. В строке могут быть только целые числа и операторы: <, >, <=, >=, ==, !=. Для обработки
                ошибок ввода используйте механизм исключений.
            */

            Console.Write("Введите логическое выражение: ");
            string input = Console.ReadLine();
            char[] tmp = input.Where(c => !char.IsDigit(c)).ToArray();
            char[] numbers = input.Where(c => !char.IsDigit(c)).ToArray();
            string oper = new string(tmp);
            Console.WriteLine(oper);
            

            
            try
            { 

                //Console.WriteLine($"{result}");
            }
            catch (FormatException exc)
            {
                //Console.WriteLine(exc.Message);
            }

#endif

#if false
            /*
                Задача 4: Дан массив целых произвольного размера. С клавиатуры вводится два числа -
                порядковые номера элементов массива, которые необходимо суммировать. Обработать
                ситуации, когда:
                         - были введены не числа,
                         - одно из чисел или оба больше или меньше размера массива,
                         - одно из чисел превышают допустимые значения заданного типа(int).
                 Сообщения об ошибках выводить другим цветом. Для обработки ошибок ввода
                используйте механизм исключений.

            */

#endif


#if false
            /*
                Задание 5: Написать приложение, которое позволяет вводить только четные числа для
                заполнения массива с клавиатуры. Реализовать класс для специального исключения и при вводе
                нечетного числа генерировать исключение специального (пользовательского) типа. Исключение
                генерировать из метода, который проверяет данные на корректный ввод и в случае некорректных
                данных генерирует исключение. Осуществить передачу данных, которые спровоцировали
                исключительную ситуацию и при обработке выводить их на экран отдельным цветом.
                Продемонстрировать работу программы на заполненном массиве. 
            */

#endif
            Console.ReadLine();
        }
    }
}
