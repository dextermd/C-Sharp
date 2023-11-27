using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_7
{
    public static class MyExtention
    {
        public static void ColorShow<Type>(this Type[]arr, ConsoleColor color = ConsoleColor.White )
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} "); 
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ColorShow(this string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            str = str?.ToUpper() ?? "Нет данных";
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write($"{str[i]} ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            int[] m = new int[] { 1, 2, 3, 4, 5 };
            m.ColorShow();
            m.ColorShow(ConsoleColor.Blue);

            double[] arr = new double[] {1.256, 2.36, 3,4,5};
            arr.ColorShow(ConsoleColor.Red);

            string[] arr2 = new string[] { "apple", "banana" };
            arr2.ColorShow(ConsoleColor.DarkGray);

            string str = "Привет!";
            str.ColorShow();

            string b = null;
            b.ColorShow();
#endif

#if false
            //Описать класс ПРЯМОУГОЛЬНИК
            //Характеристики: ширина, высота
            //Добавить вычислемые свойства для расчета Площади и Объема.

            Rectangle rect;
            try
            {
                rect = new Rectangle(10, 5);
                
                Console.WriteLine(rect.Height + " " + rect.Width);
                Console.WriteLine(rect);
                Console.WriteLine($"Периметр: {rect.Perimetr}");
                Console.WriteLine($"Площадь: {rect.Square}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage: {0}", ex.Message);
                Console.WriteLine("\nSource: {0}", ex.Source);
                Console.WriteLine("\nStackTrace: {0}", ex.StackTrace);
                Console.WriteLine("\nTargetSite: {0}", ex.TargetSite);
            }

            Rectangle rectangle = null;
            try
            {
                rect = new Rectangle(rectangle);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Rectangle rect2 = new Rectangle {
                Height = 15, 
                Width = 5
            
            };
            Console.WriteLine(rect2);
            Rectangle rect3 = new Rectangle(rect2);
            rect2.Height = 555;
            Console.WriteLine(rect3);
#endif

            Console.ReadLine();
        }
    }
}
