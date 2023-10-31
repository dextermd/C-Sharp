using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    internal class Program
    {
        static void func(out int a)
        {
            a = 10;
            a++;
            //Console.WriteLine("hello!"); 
            // out гарантирует, что значение будет инициалировано в методе
        }
        enum MyColors : byte
        { 
            Test, Red , Green, Blue , Test2 
        };
        static void Main(string[] args)
        {

            MyColors myColors = MyColors.Red;
            Console.WriteLine(myColors); // Red

            //Console.WriteLine("Введите цвет: ");
            //string s = Console.ReadLine();
            //MyColors color = (MyColors)Enum.Parse(typeof(MyColors), s, ignoreCase: true);
            //Console.WriteLine("Ваш выбор: "+ color);

            Console.WriteLine("Объем памяти: {0}", sizeof(MyColors));// 1

            switch (myColors)
            {
                case MyColors.Test:
                    break;
                case MyColors.Red:
                    break;
                case MyColors.Green:
                    break;
                case MyColors.Blue:
                    break;
                case MyColors.Test2:
                    break;
                default:
                    break;
            }

            Console.WriteLine("Введите наименование дня недели: ");
            string day = Console.ReadLine();

            switch(day)
            {
                case "Понедельник":
                    Console.WriteLine("Начало недели!");
                    break;
                case "Суббота":
                    Console.WriteLine("Ура!");
                    break;
                default:
                    Console.WriteLine("Неверные данные");
                    break;
            }

            //------------------------------------------------------------
            ConsoleKey key;

            do
            {
                Console.WriteLine("Нажмите любую кллавишу: ");
                key = Console.ReadKey().Key;
                Console.WriteLine("Нажата клавиша: "+key);
            }while (key != ConsoleKey.Escape);

            object a = 20;
            object b = 20.25;
            double d = (double)b;

            Console.WriteLine(b.GetType());
            Console.WriteLine(d.GetType());

            object[] mas = { "Hello", 2023, '!', new DateTime(2023, 10, 30), DateTime.Now };
            foreach(object v in mas)
            {
                Console.WriteLine(v);
            }

            DateTime dateTime = new DateTime();
            string str;
            Console.WriteLine("Введите дату DD.MM.YYYY: "); 
            str = Console.ReadLine();

            dateTime = DateTime.Parse(str);
            Console.WriteLine(dateTime.ToLongDateString());
            Console.WriteLine("Номер дня в году: " + dateTime.DayOfYear);


#if false

            int x;
            func(out x);
            Console.WriteLine("x = " + x);


            // Преобразование и приведение примитивных типов------------------

            // - явное(explicit)  =  сужающее 
            // - неявное(implicit) = расширяющее
            
            int a = 10;
            long b = 125;
            double d = 25.236;
            //float f = 12.45;// ошибка  сужающее приведение
            float f = 12.45F;
            float f2 = (float)12.569;
            decimal dc = 1654.123M;

            //f = d;//
            f = (float)d;

            f = Convert.ToSingle(f);
            Console.WriteLine(f);

            //d = dc;
            d = (double)dc;
            d = Convert.ToDouble(dc);
            Console.WriteLine(d);

            a = (int)b;
            a = Convert.ToInt32(b);
            Console.WriteLine(a);

            //dc = d;
            dc = Convert.ToDecimal(d);
            Console.WriteLine(dc);


            //bool bl = a;
            a = 0;
            bool bl = Convert.ToBoolean(a);
            Console.WriteLine(bl);//False

            int r = Convert.ToInt32(bl);
            Console.WriteLine(r);

            string s = "654651"; 
            long lg = Convert.ToInt64(s); // FormatException: 
            Console.WriteLine(lg);

            int n;
            s = "789khkhkj632";
            bool result = int.TryParse(s, out n);// Исключение не выбрасывается
            if (result)
            {
                Console.WriteLine("n = " + n);
            }
            else
            {
                Console.WriteLine("Ошибка конвертации");
            }
#endif




            Console.ReadLine();
        }
    }
}

/*
         Суффиксы литералов:
             - L или l тип long;
             - F или f тип float;
             - D или d тип double;
             - M или m  тип decimal;
             - U или u делает число беззнаковым     
              (суффикс «U» может быть объединён с суффиксами, специфицирующими тип данных).
         */

