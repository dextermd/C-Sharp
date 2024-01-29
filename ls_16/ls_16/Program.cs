using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_16
{
    internal class Program
    {
        static void PrintOperation<T>(T a, T b, Action<T, T> action) => action(a, b);

        static void Swap<T>(ref T а, ref T b)
        {
            Console.WriteLine("В Swap() передан тип: {0}", typeof(T));
            T temp;
            temp = а;
            а = b;
            b = temp;
        }
        static void Main(string[] args)
        {

#if false
            // Generic delegate

            int a = 10, b = 5;
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());

            Swap<int>(ref a, ref b);
            Console.WriteLine($"{a}  {b}");

            PointT<int> p = new PointT<int>(5, 9);
            PointT<int> p2 = new PointT<int>(15, 2);
            Console.WriteLine(p);
            Console.WriteLine(p2);


            Swap<PointT<int>>(ref p, ref p2);
            Console.WriteLine($"{p}  {p2}");

            PointT<int> sum = p + p2;
            Console.WriteLine($"{p} + {p2} = {sum}");


            PointT<string> strP = new PointT<string>("1", "2");
            PointT<string> strP2 = new PointT<string>("3", "red");

            PointT<string> strSum = strP + strP2;
            Console.WriteLine($"{strP} + {strP2} = {strSum}");

            PointT<PointT<int>> rp = new PointT<PointT<int>>(p, p2);
            PointT<PointT<int>> rp2 = new PointT<PointT<int>>(p, p2);

            PointT<PointT<int>> rSum = rp + rp2;
            Console.WriteLine($"{rp} + {rp2} = {rSum}");
#endif

#if false
            // Generic delegate
            /*
                Задача: Написать обобщенный делегат для хранения ссылок методов, 
                которые выводят на экран результат арифметических операций 
                двух объектов обобщенного типа
                в виде: 5+3=8
            */

            MyClass myClass = new MyClass();

            // Custom delegate  (он в MyClass -> public delegate void ShowOperation<T1, T2>(T1 x, T2 y);)
            ShowOperation<int, int> delInt = myClass.AddInt;  
            delInt += myClass.SubInt;
            delInt += myClass.MultInt;

            foreach (ShowOperation<int, int> item in delInt.GetInvocationList()) 
            {
                item(5, 2);
            }

            Console.WriteLine();

            // Standard delegate
            Action<int, int> delIntA = myClass.AddInt;
            delIntA += myClass.SubInt;
            delIntA += myClass.MultInt;

            foreach (Action<int, int> item in delIntA.GetInvocationList())
            {
                item(5, 2);
            }

            ShowOperation<double, double> delDbl = myClass.MultDouble;
            
#endif

#if false
            // Generic delegate
            /*
                Задача: Описать обобщенный метод, который выводит результаты арифметических операций
                в зависимости от переданного параметра - стандартного делегата
            */
            MyClass myClass = new MyClass();
            PrintOperation<double>(2.5, 5.6, myClass.MultDouble);
            PrintOperation<int>(2, 5, myClass.AddInt);
#endif

#if false
            // Generic delegate
            /*
                 Задача: Написать обобщенный делегат для хранения ссылок методов, 
                 которые возвращают результат арифметических операций двух объектов обобщенного типа.
             */

            TestClass testClass = new TestClass();

            // Custom delegate
            MathOperation<int> math = testClass.AddInt;
            math += testClass.SubInt;
            math += testClass.MultInt;

            Console.WriteLine("\n\n------Результаты арифметических операций:");

            foreach (MathOperation<int> item in math.GetInvocationList())
            {
                Console.WriteLine($"{item(10,4)}");
            }

            Console.WriteLine();

            // Standard delegate
            Func<int, int, int> mathF = testClass.AddInt;
            mathF += testClass.SubInt;
            mathF += testClass.MultInt;

            Console.WriteLine("\n\n------Результаты арифметических операций:");

            foreach (Func<int, int, int> item in mathF.GetInvocationList())
            {
                Console.WriteLine($"{item(10, 4)}");
            }


            Func<int, int, double> func = testClass.Average;
            Console.WriteLine("\n\n------Результат: " +  func(2, 6));
#endif

#if false
            // Generic delegate
            /*
                Задача: Реализовать обобщенный метод для изменения данных массива по
                второму параметру - стандартном делегату.
            */

            int[] m = { 5, 6, -8, 10, 2, -6, 1, -9 };
            //Transform(m, SignRevers);
            Transform(m, x => -x);

            Console.WriteLine("------Результат :");

            foreach (var item in m)
            {
                Console.Write($"{item} ");
            }
#endif

#if false
            // Generic delegate
            //Задача: Реализовать обобщенный метод для подсчета количества элементов массива по
            //переданному в качестве параметра стандартном делегату

            int[] m = { 5, 6, -8, 10, 2, -6, 1, -9, 17 };
            

            Console.WriteLine($"Кол-во отрицательных значений : {CountValue(m, IsNegative)}");
            Console.WriteLine($"Кол-во четных значений : {CountValue(m, IsEven)}");
            Console.WriteLine($"Кол-во положительных значений : {CountValue(m, x => x > 0)}");
#endif

#if false
            // Generic delegate
            int[] m = { 5, 6, -8, 10, 2, -6, 1, -9, 17 };

            Array.Sort(m, (x,y) => y.CompareTo(x));
#endif

#if false
            // Generic Interface // Custom
            /*
            Задача: Описать обобщенный интерфейс для подсчета 
            площади фигур разного типа(например: круг, прямоугольник...)
            */

            Circle circle = new Circle { Radius = 2 };
            Console.WriteLine($"Площадь: {circle.Area():F2}");

            Rectangle rectangle = new Rectangle { Height = 5, Width = 3 };
            Console.WriteLine($"Площадь: {rectangle.Area()}");
#endif

#if true
            // Generic Interface // Standart
            /*
                Задача: Для простого класса Product (Наименование товара, цена) 
                реализовать стандартный обобщенный интерфейс  IComparable<Product>
            */

            Product product = new Product("Хлеб", 10.2);
            Product product2 = new Product("Вода", 5.4);
            Product product3 = new Product("Мясо", 12.1);
            Product product4 = new Product("Чипсы", 3.8);

            Product[] listProduct = { product, product2, product3, product4 };
            
            foreach (var item in listProduct)
            {
                Console.WriteLine(item);
            }


#endif

            Console.ReadLine();
        }

        public static void Transform<T>(T[] arr, Func<T, T> transform)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = transform(arr[i]);
            }
        }

        static int SignRevers(int a) => -a;

        //public static int CountValue<T>(T[] arr, Func<T, bool> predicate)
        public static int CountValue<T>(T[] arr, Predicate<T> predicate)
        {
            int c = 0;
            foreach (T item in arr)
            {
                if (predicate(item)) c++;
            }
            return c;
        }

        static public bool IsNegative(int k) => k < 0;
        static public bool IsEven(int k) => k % 2 == 0;
    }
}
