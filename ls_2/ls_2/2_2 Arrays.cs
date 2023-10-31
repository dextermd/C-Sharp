using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    В языке C#, сам массив имеет ССЫЛОЧНЫЙ тип данных, 
    это значит, что после объявления переменной типа массив, 
    выделяется память, только для хранения ссылки на экземпляр массива, 
    при этом значение переменной равно null. 

    Для создания экземпляра массива, и выделения памяти для хранения элементов, 
    необходимо использовать оператор new.
 */

//------------------------------------------------------------------------------
/*
    Все массивы в С# унаследованы от класса System.Array
    т.е.  все массивы являются объектами,  массивы — это ссылочные типы

Преимущества: полученный в наследство от класса System.Array 
              немалый набор методов по работе с массивами, 
              контроль выхода за границы массива и др.; 

Недостатким — некоторое снижение быстродействия при работе с массивом вследствие того,
              что он размещается в «куче».
 */

//------------------------------------------------------------------------------
/*
    С# поддерживает следующие типы массивов:
              - одномерные;  int [] mas
              - многомерные; int[,,]
              - ступенчатые или зубчатые (масив массивов) int[][]
*/

namespace _2_2_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
#if true
            int size = 5;

            int[] mas = null;
            mas = new int[size];

            int[]ar1 = new int[5] { 12,9,8,7,6};
            int[]ar2 = new int[] { 12,9,8,7,6,9,12,-5,6};
            int[] ar3 = { 2,3,-5,8,7};
            string[] fruites = { "яблоко", "груша", "слива", "айва", "груша", "персик" };

            Console.WriteLine(ar1.GetType());
            Console.WriteLine(fruites.GetType());
            Console.WriteLine("Количество элементов: " + ar2.Length);
            Console.WriteLine("Объем памяти: "+ sizeof(int)*ar2.Length);

            string myString = "Привет, мир!"; 

            int byteCount = System.Text.Encoding.Default.GetByteCount(myString); 
            int byteCount2 = System.Text.Encoding.Unicode.GetByteCount(myString); 

            Console.WriteLine("Количество байт в строке: " + byteCount);
            Console.WriteLine("Количество байт в строке: " + byteCount2);

            Console.WriteLine("Размер строки в байтах: " + myString.Length * sizeof(char));

            Console.WriteLine(System.Text.Encoding.Default.GetType());
            Console.WriteLine(System.Text.Encoding.Unicode.GetType());

            Console.WriteLine(sizeof(char));

            ar1[2] = 100;
            for(int i = 0;i < ar1.Length;i++)
            {
                ar1[i] *= 2;
                //Console.Write(ar1[i] + "  ");
                //Console.Write("{0}  ", ar1[i]);
                Console.Write($"{ar1[i]}  ");// интерполированная строка
            }
            Console.WriteLine();
            foreach(var i in ar2)
            {
               // i *= 2;
                Console.Write($"{i} , ");
            }

            Console.WriteLine();
            for(int i = fruites.Length-1; i>=0; i--)
            {
                Console.WriteLine(fruites[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < ar1.Length; i++)
            {
                //Console.Write(ar1[ar1.Length - i -1] + "  ");
                Console.Write($"{ar1[ar1.Length - i - 1]}  " );
            }
            Console.WriteLine();

            //---------------------------------------------------------------
            // Копия массива

            int[] a = { 12, 5, 6, 9, 7 };
            int[] b = { 1,3,9,8,7 };

            b = a;// operator =  происходит копия ссылок

            a[1] = 500;
            foreach(int i in b)
            {
                Console.Write(i + " ");
            }

            // Глбокая копия массива
            // 1. поэлементное копирование
            int []copy = new int[a.Length];

            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = a[i];
            }
            Console.WriteLine();
            a[0] = 1000; // не влияет на значение в массиве copy
            Console.WriteLine("Копия массива:");
            foreach(int i in copy)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();

            //2. метод Copy класса Array
            int [] copy2 = new int[a.Length];
            Array.Copy(a, copy2, copy2.Length);
            a[2] = -2;
            Console.WriteLine("Копия массива:");
            foreach (int i in copy2)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
#endif
            //--------------------------------------------------------
            Console.WriteLine("---------------------------------------");
#if true

            int[] ms = new int[] { 12, -9, 8, 7, -6, 9, 12, -5, 6 };

            Console.WriteLine("исходный массив:");
            foreach (int i in ms)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();

            Array.Sort(ms);
            Console.WriteLine("\nМассив после сортировки по возрастанию:");
            foreach (int i in ms)
            {
                Console.Write(i + "  ");
            }

            //Array.Sort(mas, compareDecr);
            Array.Sort(ms, (x,y) => y-x); // лямбда
            //Array.Sort(ms, (x,y) => y.CompareTo(x)); // лямбда

            Console.WriteLine("\nМассив после сортировки по убыванию:");
            foreach (int i in mas)
            {
                Console.Write(i + "  ");
            }

            // Методы расширения: 
            Console.WriteLine("Min = " + mas.Min());
            Console.WriteLine("Count all = " + mas.Count());
            Console.WriteLine("Count even = " + mas.Count( x => x%2 == 0));


#endif
            Console.ReadLine();
        }

        //static int compareDecr(int a, int b)
        //{
        //    return b - a;
        //}
        static int compareDecr(int a, int b) => b - a;
    }
}


