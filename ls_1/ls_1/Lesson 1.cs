using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            System.Console.WriteLine("Hello, \"World!\"");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Привет, С#");
            Console.ForegroundColor= ConsoleColor.Gray;
            Console.Write("Доброго дня!");
            Console.Write("\n\nКаждый новый день - \nначало изучения С#!");
            Console.WriteLine();

#if false

            Console.WriteLine("\nВведите имя: ");

            string name = Console.ReadLine();
            Console.WriteLine("Привет, " + name + "!!!");
            Console.WriteLine("Введите ваш возраст : ");
            string age = Console.ReadLine();
            Console.WriteLine(name + " -> " + age);
#endif
            Console.WriteLine(12.GetType());//System.Int32
            Console.WriteLine("Объем памяти для Int32: "+ sizeof(Int32));
            Console.WriteLine("Объем памяти для Int64: "+ sizeof(Int64));
            Console.WriteLine("Max Value: " + Int64.MaxValue);
            Console.WriteLine("Max Value: " + Int32.MaxValue);

            Console.WriteLine(12L.GetType());//System.Int64

            int a = 5, b = 10;
            Console.WriteLine(a + " + " + b + " = " + (a+b) );//5 + 10 = 15
            Console.WriteLine("    {0} + {1} = {2}", a, b, (a+b));

#if false

            Console.WriteLine("Введи целое число: ");

            //string tmp = Console.ReadLine();
            //a = int.Parse(tmp);

            //a = int.Parse(Console.ReadLine());  //FormatException: 
            try
            {
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("a = {0}", a);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный ввод данных");
            }

#endif

            Console.WriteLine(25.56);
            Console.WriteLine("Объем памяти : "+sizeof(double));
            Console.WriteLine("Тип: " + 25.56.GetType());//System.Double
            Console.WriteLine("Тип: " + 25.56f.GetType());//System.Single
            Console.WriteLine("Тип: " + 25.56M.GetType());//System.Decimal
            Console.WriteLine("Max value : " + double.MaxValue);

            Console.WriteLine(10d/3);
            Console.WriteLine(10m/3);

#if false

            double d;
            Console.WriteLine("Введи дробное число через запятую: ");
            d = double.Parse(Console.ReadLine());
            Console.WriteLine("double d = " + d);
            Console.WriteLine("double d = {0:F2}", d); //F2- два знака после точки
            Console.WriteLine("double d = {0,15:F4}", d); //15 - ширина поля

            // отделение тысяч по установленной системе
            Console.WriteLine("N format: {0:N}", 99654999);

            long tel = 654313165468;
            // Настраиваемый формат с использованием #
            Console.WriteLine("{0:+# (###) ##-###-###}", tel);

            Console.WriteLine("Введи дробное число через точку: ");
            NumberFormatInfo info = new NumberFormatInfo()
            {
                NumberDecimalSeparator = "."  ,  
            };

            d = double.Parse(Console.ReadLine(), info);
            Console.WriteLine("double d = {0,10:F4}", d);

#endif
            //bool p = 15; // ошибка
            bool p = true;
            Console.WriteLine(p);

            //int x = 12;
            //if (x) { }

            if (p)
                Console.WriteLine(p);
            else Console.WriteLine("Не правда");


            char c = 'a';
            Console.WriteLine(c.GetType());//System.Char
            Console.WriteLine("Объем памяти System.Char: "+ sizeof(char));

#if false


            Console.WriteLine("Введи символ: ");
            c  = char.Parse(Console.ReadLine());
            Console.WriteLine("Символ: {0} ", c);
            Console.WriteLine("Код символ: {0} ", (int)c);

            Console.WriteLine("Введи символ: ");
            c = Console.ReadKey().KeyChar;
            Console.WriteLine("\nСимвол: {0} ", c);
#endif
            char s = ' ';
            Console.WriteLine(char.IsDigit(c));//False
            Console.WriteLine(char.ToUpper(c));//A
            Console.WriteLine(char.IsWhiteSpace(s));//True

            Console.WriteLine(-10 % 4);
            Console.WriteLine(10d / 4);
            Console.WriteLine("10d / 3 = {0:F2} ", 10d / 3);
            Console.WriteLine((double)10 / 4);
            
            Console.WriteLine(Math.PI);


            //Форматированный вывод(дополнительно)------------------------
            // ***
            Console.WriteLine("Форматированный вывод\n");

            // денежный формат по настройкам системы, возможно округление
            Console.WriteLine("C format: {0:C}", 999987.987);

            // если форматирование портит информацию, то оно отбрасывается
            // D4 - количество цифр для вывода, дополняется нулями перед числом
            Console.WriteLine("D4 format: {0:D9}", 99999);

            Console.WriteLine("E format: {0:E}", 99999.7552498);

            // F3 - количество цифр после точки, работает округление
            Console.WriteLine("F3 format: {0:F3}", 99999.999999);

            // отделение тысяч по установленной системе
            Console.WriteLine("N format: {0:N}", 99999);

            // 16 - ричный формат с отображением заглавных букв
            Console.WriteLine("X format: {0:X}", 99999);

            // 16 - ричный формат с отображением строчных букв
            Console.WriteLine("x format: {0:x}", 99999);

            Console.WriteLine("P format: {0:P}", 25);
            //Console.ReadLine();
            Console.ReadKey();
           
           
        }
    }
}

//----------------------------------------------------------------
/*
         Суффиксы литералов:
             - L или l тип long;
             - F или f тип float;
             - D или d тип double;
             - M или m  тип decimal;
             - U или u делает число беззнаковым     
              (суффикс «U» может быть объединён с суффиксами, специфицирующими тип данных).
         */

//----------------------------------------------------------------

/*
 
Спецификатор	Применяется к	            Значение	                                Пример

C	        Числовым типам	                Символ местной валюты	                    $835.50 (США)  £835.50 (Великобритания) 835.50L(Moldova)
D	        Только к целочисленным типам	Обычное целое	                            835
E	        Числовым типам	                Экспоненциальная нотация	                8.35Е+002
F	        Числовым типам	                С фиксированной десятичной точкой	        835.50
G	        Числовым типам	                Обычные числа	835.5
N	        Числовым типам	                Формат чисел, принятый в данной местности	4,384.50 (Великобритания/США) 4 384,50 (континентальная Европа) 
P	        Числовым типам	                Процентная нотация	                        835,000.00%
X	        Только к целочисленным типам	Шестнадцатеричный формат	                1a1f
 */
