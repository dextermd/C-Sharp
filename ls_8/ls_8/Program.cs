using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ls_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            // Для класса PointPos - пусть точка должна иметь только положительные координаты
            PointPos point;
            try
            {
                point = new PointPos(-5, 3);
                Console.WriteLine($"{point.X}, {point.Y}");
            }
            catch (PointExc ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Дата и время: {ex.DateException}");
                Console.WriteLine($"Состояние данных: X = {ex.XErr}, Y = {ex.YErr}");
            }
            

#endif

#if false
            // checked, unchecked ****************************************************************
            int a = int.MaxValue;
            a++;
            Console.WriteLine(a);
            a = unchecked(a++); // Игнорируется при выполнении блока
            Console.WriteLine(a);

            int b = int.MinValue;
            Console.WriteLine(b);
            try
            {
                b = checked(b--); // OverflowException
                Console.WriteLine(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            double d = double.MaxValue;
            Console.WriteLine(d);
            d *= 2;
            Console.WriteLine(d); // ? 
            Console.WriteLine(double.IsInfinity(d)); // True

            //decimal - всегда исключение
            decimal dec = decimal.MaxValue;
            Console.WriteLine(dec);
            //dec *= 2;                 // OverflowException
            dec = unchecked(dec *= 2); // OverflowException
            Console.WriteLine(dec);
#endif

#if false
            Console.WriteLine("double");
            // Системные исключения (exceptions) **********************************************
            string errType;
            do
            {
                Console.WriteLine("\nВыберите тип ошибки");
                Console.WriteLine("1. Деление на нуль int");
                Console.WriteLine("2. Выход за границы массива");
                Console.WriteLine("3. Неправильное приведение типов");
                Console.WriteLine("4. Отрицательный размер массива");
                Console.WriteLine("5. Использование ссылки null массив");
                Console.WriteLine("6. Использование ссылки null строка");
                Console.WriteLine("7. Деление на нуль decimal");
                Console.WriteLine("8. Деление на нуль double");
                Console.WriteLine("0. Завершить работу программы");

                errType = Console.ReadLine();

                try
                {
                    switch (errType)
                    {
                        case "1": { int i = 0; int res = 5 / i; break; } // Деление на нуль

                        case "2": { int[] array = new int[5]; array[6] = 0; break; } // Выход за пределы массива

                        case "3": { Object ch = new Char(); ch = "+"; byte b = (byte)ch; break; } // Ошибка приведения типа

                        case "4": { int i = -5; int[] array = new int[i]; array[0] = 0; break; } // Отрицательный размер массива

                        //case "5": { int[] array = null; array[0] = 0; break; } // Использование ссылки null
                        case "5": { 
                                int[] array = null;
                                if (array == null)
                                    throw new ArgumentNullException(nameof(array));
                                array[0] = 0; break; 
                        } // Использование ссылки null
                        
                        case "6":
                        {
                            string s = null;
                            Console.Write($"Строка: {s?.ToUpper() ?? "Нет данных в строке"}");
                            break;
                        } // Использование ссылки null
                        case "7": { decimal i = 0; decimal res = 5 / i; break; } 
                        case "8": { double i = 0; double res = 5 / i;
                                Console.WriteLine($"Результат деления: {res}");
                                if (double.IsInfinity(res))
                                    throw new ArgumentNullException(nameof(res));
                                break; } 
                    }
                }
                catch (DivideByZeroException exp)
                {
                    Console.WriteLine(">>>> Делить на нуль нельзя!");
                    Console.WriteLine(exp.Message);
                }
                catch (IndexOutOfRangeException exp)
                {
                    Console.WriteLine(">>>> Выход за пределы массива!");
                    Console.WriteLine(exp.Message);
                }
                catch (OverflowException exp)
                {
                    Console.WriteLine(">>>> Отрицательный массива!");
                    Console.WriteLine(exp.Message);
                }
                catch (Exception exp) // базовый класс поймает System.InvalidCastException
                {
                    Console.WriteLine(">>>> Неверное приведение типов!");
                    Console.WriteLine(exp.Message);
                }
                // Для обработки всех типов исключений
                // заключительный блок catch  -  не рекомендуется
                catch
                {
                    Console.WriteLine("Ошибка!!!");
                }
                finally
                {
                    // освобождение неуправляемых ресурсов
                    Console.WriteLine("Блок finally");
                }
                Console.ReadLine();
                Console.Clear();

            } while (errType != "0");
#endif

#if false
            /*
             Написать для класса Point метод расширения,
             который определяет расстояние между двумя точками.
            */
            Point a = new Point(-10, 15);
            Console.WriteLine($"Точка A: {a}");

            Point b = new Point(2, 3);
            Console.WriteLine($"Точка Б: {b}");

            double result = a.Distance(b);
            Console.WriteLine($"Расстояние между точками {a} и {b} = {result:F}");

            // Вызов с использованием полного пути
            double r = PointExtension.Distance(a,b);
            Console.WriteLine($"Расстояние между точками {a} и {b} = {r:F}");
#endif
            Console.ReadLine();
        }
    }
}
