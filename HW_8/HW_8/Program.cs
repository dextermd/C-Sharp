using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

#if false
            /*
                Задание 3: Пользователь вводит в строку с клавиатуры логическое выражение. Например, 3>2 или
                7<3. Программа должна посчитать результат введенного выражения и дать результат true или
                false. В строке могут быть только целые числа и операторы: <, >, <=, >=, ==, !=. Для обработки
                ошибок ввода используйте механизм исключений.
            */

            Console.Write("Введите логическое выражение: ");
            string input = Console.ReadLine().Replace(" ", "");

            try
            {
                char[] tmp = input.Where(c => !char.IsDigit(c)).ToArray();
                string oper = new string(tmp);
                string[] strNum = input.Split(oper.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (strNum.Length < 1 || strNum.Length > 2) throw new Exception("Неверное выражение");
                if (oper != "<" && oper != ">" && oper != "<=" && oper != ">=" && oper != "==" && oper != "!=") 
                    throw new Exception("Неверный оператор");

                switch (oper)
                {
                    case "<": Console.WriteLine(int.Parse(strNum[0]) < int.Parse(strNum[1])); break;
                    case ">": Console.WriteLine(int.Parse(strNum[0]) > int.Parse(strNum[1])); break;
                    case "<=": Console.WriteLine(int.Parse(strNum[0]) <= int.Parse(strNum[1])); break;
                    case ">=": Console.WriteLine(int.Parse(strNum[0]) >= int.Parse(strNum[1])); break;
                    case "==": Console.WriteLine(int.Parse(strNum[0]) == int.Parse(strNum[1])); break;
                    case "!=": Console.WriteLine(int.Parse(strNum[0]) != int.Parse(strNum[1])); break;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
#endif

#if true
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
            int[] arr = { 10, 5, 3, 14, 8, 16, 44, 98, 7 };
            try
            {
                Console.Write($"Введите первое число от 1 до {arr.Length}: ");
                int firstNum = int.Parse(Console.ReadLine()) -1;

                Console.Write($"Введите второе число от 1 до {arr.Length}: ");
                int secondNum = int.Parse(Console.ReadLine()) -1;

                Console.WriteLine($"{arr[firstNum]} + {arr[secondNum]} = {arr[firstNum] + arr[secondNum]}");
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (IndexOutOfRangeException e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (OverflowException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            
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
