using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ls_2
{
    internal class Program
    {
        static void func(out int a)
        {
            a = 10;
            //Console.WriteLine("Hello!");
            // out гарантирует, что значение будет инициализировано в методе
        }

        enum MyColors : byte
        {
            Test, Red, Greeb, Blue, Test2 
        };

        //static int compareDecr(int a, int b)
        //{
        //    return b - a;
        //}

        static int compareDect(int a, int b) => b - a;

        static void Main(string[] args)
        {

#if false
            // -------------------------------------------------------------------
            int[] arr = new int[] { 12, -9, 8, 7, -6, 9, 12, -5, 6 };
            int count;
            // Array.Sort(arr, compareDect);
            //Array.Sort(arr, (a, b) => a.CompareTo(b)); // Лямбда
            Array.Sort(arr, (a, b) => b - a); // Лямбда
            Console.WriteLine("Массив после сортировки: ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Min = " + arr.Min());
            Console.WriteLine("Count all = " + arr.Count());
            Console.WriteLine("Count even = " + arr.Count( (x) => x % 2 == 0) );
#endif

#if false
            // Array ------------------------------------------------------------------------

            int size = 5;
            int[] arr = null;
            arr = new int[size];

            int[] arr2 = new int[5] { 12, 9, 8 ,7, 6};
            int[] arr3 = new int[] { 12, 9, 8 ,7, 6};
            int[] arr4 = { 2, 3, -5, 8, 7 };
            string[] fruites = { "яблоко", "груша", "слива", "айва", "груша", "персик" };

            Console.WriteLine(arr2.GetType());
            Console.WriteLine(fruites.GetType());
            Console.WriteLine("Количество элементов: " + arr2.Length);
            Console.WriteLine("Количество элементов: " + fruites.Length);
            Console.WriteLine("Обьем памяти: " + sizeof(int)* arr2.Length);

            arr2[2] = 100;
            
            for (int i = 0; i < arr2.Length; i++)
            {
                //Console.Write(arr2[i] + " ");
                //Console.Write("{0}  ", arr2[i]);
                Console.Write($"{arr2[i]}  "); // интерполированная строка
            }

            Console.WriteLine();

            for (int i = 0; i < arr2.Length; i++)
            {
                //Console.Write(arr2[i] + " ");
                //Console.Write("{0}  ", arr2[i]);
                Console.Write($"{arr2[arr2.Length - i - 1]}  "); // интерполированная строка
            }

            Console.WriteLine();

            for (int i = arr2.Length -1; i >= 0; i--)
            {
                //Console.Write(arr2[i] + " ");
                //Console.Write("{0}  ", arr2[i]);
                Console.Write($"{arr2[i]}  "); // интерполированная строка
            }

            Console.WriteLine();

            foreach (var item in fruites)
            {
                //Console.Write(item + " ");
                //Console.Write("{0}  ", item);
                Console.Write($"{item}  "); // интерполированная строка
            }

            Console.WriteLine();

            // -----------------------------------------------------------------
            //Копия массива

            int[] a = { 12, 5, 6, 9, 7 };
            int[] b = { 1, 3, 9, 8, 0 };

            b = a; // operator =  происходит копия ссылок

            a[1] = 500;
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // Глубокая копия массива
            // 1. поэлементное копирование

            int[] copy = new int[a.Length];
            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = a[i];
            }

            a[0] = 1000; // не влияет на значение в массиве copy

            Console.Write("Копия массива: ");
            foreach (var item in copy)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            // 2.

            int[] copy2 = new int[a.Length];
            Array.Copy(a, copy2, a.Length);
            a[2] = -2;
            Console.Write("Копия массива: ");
            foreach (var item in copy2)
            {
                Console.Write(item + " ");
            }
  

#endif

#if false
            // Enum -------------------------------------------------------------
            MyColors myColors = MyColors.Red;
            Console.WriteLine(myColors); // Red

            //Console.Write("Введите цвет: ");
            //string s = Console.ReadLine();
            //MyColors color = (MyColors)Enum.Parse(typeof(MyColors), s, ignoreCase:true);
            //Console.WriteLine("Ваш выбор: " + color);

            Console.WriteLine("Обьем памяти: {0}", sizeof(MyColors));

            // --------------------------- Switch ------------------------------

            switch (myColors)
            {
                case MyColors.Test:
                    break;
                case MyColors.Red:
                    break;
                case MyColors.Greeb:
                    break;
                case MyColors.Blue:
                    break;
                case MyColors.Test2:
                    break;
                default:
                    break;
            }

            Console.Write("Введите наименование для недели: ");
            string day = Console.ReadLine();

            switch (day)
            {
                case "Понедельник":
                    Console.WriteLine("Давай на работу!");
                    break;
                case "Суббота":
                    Console.WriteLine("Ура!");
                    break;
                default:
                    Console.WriteLine("Неверные данные");
                    break;
            }

            // -------------------------------------------------------------

            ConsoleKey key;

            do
            {
                Console.Write("Нажмите любую клавишу: ");
                key = Console.ReadKey().Key;
                Console.WriteLine("Нажатая клавиша: " + key);
            } while (key != ConsoleKey.Escape);

            object a = 20;
            object b = 20.25;
            double d = (double)b;

            Console.WriteLine(b.GetType());
            Console.WriteLine(d.GetType());

            object[] arr = { "Hello", 2023, '!', new DateTime(2023, 10, 30), DateTime.Now };
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            DateTime dateTime = new DateTime();
            string str;
            Console.Write("Введите дату DD.MM.YYYY: ");
            str = Console.ReadLine();
            dateTime = DateTime.Parse(str);
            Console.WriteLine(dateTime.ToLongDateString());
            Console.WriteLine("Номер дня в году: " + dateTime.DayOfYear);


#endif

#if false
            int x;
            func(out x);
            Console.WriteLine("x = " + x);


            // Convert Data
            // Преоброзование и преведение примитивных типов

            // - явное(explicit) = сужающее
            // - неаяное(implicit) = расширяющее

            int a = 1; 
            long b = 125;
            double d = 25.236;
            float f = 12.45F;
            float f2 = (float)12.569;
            decimal dc = 1654.123M;

            f = (float)d;
            f = Convert.ToSingle(f);
            Console.WriteLine(f);

            d = (double)dc;
            d = Convert.ToDouble(dc);
            Console.WriteLine(d);

            a = (int)b;
            a = Convert.ToInt32(b);
            Console.WriteLine(a);

        
            dc = Convert.ToDecimal(d);
            Console.WriteLine(dc);

            //bool bl = a;
            bool bl = Convert.ToBoolean(a);
            Console.WriteLine(bl);

            int r = Convert.ToInt32(bl);
            Console.WriteLine(r);

            string s = "654651";
            long lg = Convert.ToInt64(s);
            Console.WriteLine(lg);

            int n;
            s = "987986";
            bool result = int.TryParse(s, out n);
            if (result)
            {
                Console.WriteLine("n = " + n);
            }else
            {
                Console.WriteLine("Ошибка конвертации");
            }
            

#endif

            Console.ReadLine();
        }
    }
}
