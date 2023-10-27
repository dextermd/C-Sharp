using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello World!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Привет, C#");
            Console.ResetColor();
            Console.Write("Доброго дня!");
            Console.Write("\nКаждый новый день  - начало изучения C#!\n");
#endif

#if false
            Console.Write("\nВведите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Привет, " + name + "!!!");

            Console.Write("Введите ваш возраст: ");
            string age = Console.ReadLine();
            Console.WriteLine(name + " -> " + age);
#endif

#if false

            Console.WriteLine(12.GetType()); // System.Int32
            Console.WriteLine("Обьем памяти для Int32: " + sizeof(Int32)); 
            Console.WriteLine("Обьем памяти для Int64: " + sizeof(Int64));
            Console.WriteLine("Max Value (Int32): " + Int32.MaxValue);
            Console.WriteLine("Max Value (Int64): " + Int64.MaxValue);

            Console.WriteLine(12L.GetType()); // System.Int64

            int a = 5, b = 10;
            Console.WriteLine(a + " + " + b + " = " + (a + b));
            Console.WriteLine("{0} + {1} = {2}", a, b, (a + b));

            Console.Write("Введи целое число: ");

            //string tmp = Console.ReadLine();
            //a = int.Parse(tmp);

            // a = int.Parse(Console.ReadLine()); // FormatException:

            try
            {
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("a = {0}", a);
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный ввод данных");
            }

#endif

#if false

            Console.WriteLine(25.56);
            Console.WriteLine("Обьем памяти: " + sizeof(double));
            Console.WriteLine("Тип: " + 25.56.GetType());   // System.Double
            Console.WriteLine("Тип: " + 25.56f.GetType());  // System.Single
            Console.WriteLine("Тип: " + 25.56m.GetType());  // System.Decimal
            Console.WriteLine("Max value: " + double.MaxValue);

            Console.WriteLine(10d/3);
            Console.WriteLine(10m/3);

            double d;
            Console.Write("Введи дробное число через запятую: ");
            d = double.Parse(Console.ReadLine());
            Console.WriteLine("double d = " + d);
            Console.WriteLine("double d = {0:F2}", d); //F2 Кол-во знаков после точки или запятой 
            Console.WriteLine("double d = {0,15:F2}", d);  // 15 - ширина поля

            // отделение тысяч по  установленной системе
            Console.WriteLine("N format: {0:N}", 99654999);

            long tel = 654313165468;
            // Настраиваемый формат с использованием #
            Console.WriteLine("{0:+# (###) ##-###-###}", tel);

            Console.Write("Введи дробное число через точку: ");

            NumberFormatInfo info = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            d = double.Parse(Console.ReadLine(), info);
            Console.WriteLine("double d = {0,10:F4}", d);

#endif

#if false
            // bool p = 1; // error
            bool p = true;
            Console.WriteLine(p);

            if (p)
                Console.WriteLine(p);
            else Console.WriteLine("Не правда");

            char c = 'a';
            Console.WriteLine(c.GetType()); // System.Char
            Console.WriteLine("Обьем памяти System.Char: " + sizeof(char));

            Console.Write("Введи символ: ");
            c = char.Parse(Console.ReadLine());
            Console.WriteLine(c);
            Console.WriteLine("Символ: {0}", c);
            Console.WriteLine("Код символа: {0}", (int)c);

            Console.Write("Введи символ: ");
            c = Console.ReadKey().KeyChar;
            Console.WriteLine(c);
#endif

#if false
            char s = ' ';
            Console.WriteLine(char.IsDigit(s));
            Console.WriteLine(char.ToUpper(s));
            Console.WriteLine(char.IsWhiteSpace(s));

            Console.WriteLine(-10 % 4);
            Console.WriteLine(10d / 4);
            Console.WriteLine("10d / 3 = {0:F2} ", 10d / 3);
            Console.WriteLine((double) 10 / 4);
            Console.WriteLine(Math.PI);

#endif
            Console.ReadLine();
        }
    }
}
