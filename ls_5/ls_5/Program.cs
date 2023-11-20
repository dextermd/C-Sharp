using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace ls_5
{
    struct Point
    {
        public double X; 
        public double Y;
        public decimal a;
        public decimal b;
        public decimal c;
        public decimal v;
    }

    internal class Program
    {
        static public void Message() => Console.WriteLine("Hello, World");
        static public int Sum(int a, int b) => a + b;

        static public void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        static public void SetPoint(ref Point p)
        {
            p.X = 10;
            p.Y = 5;
        }
        
        static void SetArray(int[] m)
        {
            m[0] = 200;
        }
        static ref int TestRef(int[] arr)
        {
            return ref arr[0];
        }
        static void MyResize(ref int[] arr, int newSize)
        {
            int[] tmp = new int[newSize];
            if (newSize > arr.Length)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    tmp[i] = arr[i];
                }
            }else
            {
                for (int i = 0; i < newSize; i++)
                {
                    tmp[i] = arr[i];
                }
            }

            arr = tmp;
        }

        static void Arifmetic(int a, int b, out int summa, out int mult)
        {
            summa = a + b;
            mult = a * b;
        }
        static void SquarePerimetr(int height, int width, out int sq, out int per)
        {
            sq = height * width;
            per = 2 * (width + height);
        }

        static void SetRectangle(int height, int width)
        {
            Console.WriteLine("Высота: {0}", height);
            Console.WriteLine("Ширина: {0}", width);
        }
        static void TestIN(in int a, in StringBuilder sb)
        {
            // a = 25; // readonly
            Console.WriteLine($"{a}");

            sb.Append("!"); // значения меенять можно
            // sb = new StringBuilder(); // ссылку менять нельзя
        }
        static void TestPoint(Point p) { }
        static void TestPointIN(in Point p) { }
        static int Sum(params int[] parameters)
        {
            int sum = 0;
            foreach (var i in parameters)
            {
                sum += i;
            }

            return sum;
        }
        static void TestParams(params object[] parameters)
        {
            foreach (var param in parameters)
            {
                Console.WriteLine("Тип {0}  Значение {1}", param.GetType(), param);
            }
        }
        static void Main(string[] args)
        {

#if true
            int[] m = new int[] { 5, 3, 6 };
            MyDll.ShowColorArr(m);

#endif

#if false
            // --------------------------------------------------------------------------
            // ****add ------------------------------------------------------------------

            TestParams("Hello!!!", 12.652, '+', true);
            int a = 10;
            object obj = a; 
            Console.WriteLine(obj);

#endif

#if false
            // --------------------------------------------------------------------------
            // Ключевое слово params
            // - params всегда последний в списке параметров
            // - должен казывать на одномерный массив любого типа
            // - в одном методе может быть только один модификатор params

            int summa = Sum();
            Console.WriteLine(summa);

            summa = Sum(2,3,6,10,6); 
            Console.WriteLine(summa);

            int[] arr = new int[] { 1, 3, 9 };
            summa = Sum(arr);
            Console.WriteLine(summa);
#endif

#if false
            // --------------------------------------------------------------------------
            // Привер: Проверка скорости выполнения программы
            // using System.Diagnostic;

            Point p = new Point();

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0;i < int.MaxValue;i++)
            {
                TestPoint(p);
            }
            sw.Stop();
            Console.WriteLine("TestPoint => " + sw.ElapsedMilliseconds);

            sw.Restart();

            for (int i = 0; i < int.MaxValue; i++)
            {
                TestPointIN(p);
            }
            sw.Stop();
            Console.WriteLine("TestPointIN => " + sw.ElapsedMilliseconds);
#endif

#if false
            // --------------------------------------------------------------------------
            // Ключевое слово in, начиная  версии языка 7.2

            // Ключевое слово in позволяет передавать параметр по ссылке обьект структуры,
            // но изменить внутри метода переменную не может (по сути readonly)

            // Мотивация использования: экономия памяти при передаче структур !!!

#endif

#if false
            // --------------------------------------------------------------------------
            // Написать функцию которая принимает размеры прямугольника и возвращает его площадь и периметр.

            SetRectangle(25, 30);
            SetRectangle(width: 5, height: 10);
#endif

#if false
            Console.Write("Введите число: ");
            string str = Console.ReadLine();

            bool r = int.TryParse(str, out int number);
            if (r)
            {
                Console.WriteLine($"Number: {number}");
            }
            else
            {
                Console.WriteLine("Неверные данные!");
            }

            // --------------------------------------------------------------------------
            // out

            // ref и out = работают по ссылке
            // при out можем не задавать начальное значение
            // !!! out - раоантирует, что метод будет присвоено значение !!!
            // В функцию с параметром ref нельзя передать неинициализированную переменую

            Console.WriteLine();
            int a = 5, b = 3, sm, mlt;
            Arifmetic(a, b, out sm, out mlt);
            Console.WriteLine($"Сумма: {sm}. Умножение: {mlt}.");

            Console.WriteLine();
            Arifmetic(a, b, out int sm2, out int mlt2); // Обьявляем переменные прямо при вызове метода (в параметрах)
            Console.WriteLine($"Сумма: {sm2}. Умножение: {mlt2}.");
#endif

#if false
            // --------------------------------------------------------------------------
            // Написать метод MyResize который меняет размер массива
            int[] m = new int[] { 5, 3, 6 };
            //Array.Resize(ref m, 10);
            MyResize(ref m, 10);
            foreach (var item in m)
            {
                Console.Write(item + " ");
            }
#endif

#if false

            // --------------------------------------------------------------------------
            // Массив
            Console.WriteLine();
            int[] m = new int[] { 5,3,6 };
            SetArray(m);
            Console.WriteLine("m[0] {0}", m[0]);

            // --------------------------------------------------------------------------
            // Ссылочная локальная переменная - появилась в более поздних версиях языка
            Console.WriteLine();
            ref int myRef = ref m[0];
            myRef = 500;
            Console.WriteLine("m[0] {0}", m[0]);

            // --------------------------------------------------------------------------
            // Возврат по ссылке
            Console.WriteLine();
            ref int result = ref TestRef(m);
            result = -200;
            Console.WriteLine("m[0] {0}", m[0]); // -200

            // --------------------------------------------------------------------------
            Console.WriteLine();
            Point p = new Point();
            Console.WriteLine($"{p.X}  {p.Y}");
            SetPoint(ref p);
            Console.WriteLine($"{p.X}  {p.Y}");

            // --------------------------------------------------------------------------
            // Модификаторы параметров, которые передаются методам: ref
            // Написать метод Swap для обмена целых
            Console.WriteLine();
            int a = 5; int b = 10;
            Console.WriteLine($"{a}  {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"{a}  {b}");


            // --------------------------------------------------------------------------
            // Методы -------------------------------------------------------------------
            // Короткая запись метода => Однострочный метод
            // Реализация тела метода-выражения
            // Expression-bodied method
            
            Console.WriteLine();
            Message();
            Console.WriteLine(Sum(2,6));



#endif
            Console.ReadLine();
        }
    }
}
