using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            // -----------------------------------------------------------------------------------------------------
            // Перегрузить унарный оператор ++ для класса Point
            // Унарные ++ -- - (смена знака)
            Point first = new Point(1, 5);
            Console.WriteLine($"До работы оператора++ {first} после {first++}"); // перегрузка оператора ++ ( public static Point operator ++(Point a) )
            Console.WriteLine($"До работы оператора-- {first} после {++first}"); // перегрузка оператора -- ( public static Point operator --(Point a) )
            Console.WriteLine($"До работы оператора- {first} после {-first}"); // перегрузка оператора- ( public static Point operator -(Point a) )
            Point second = new Point(-first);
            Console.WriteLine($"Новая координата на основе точки, но с измененным знаком: {second}");
            Console.WriteLine($"До работы оператора+ {first} после {+first}"); // перегрузка оператора+ ( public static Point operator +(Point a) )

            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------
            // Бинарные :
            // Point + Point
            // Point += Point
            // Point + int и наоборот
            Point p = new Point(1,8);
            Point p1 = new Point(4, 5);
            Point p3 = p + p1;
            Console.WriteLine($"p = {p}, p1 = {p1}");
            Console.WriteLine($"Результат сложения p3 = {p3}");

            p3 += new Point(2, 3);
            Console.WriteLine($"p3 += new Point(2, 3) будет: {p3}");

            int a = 10;
            Point p4 = p3 + a;
            Console.WriteLine($"{p3} + {a} = {p4}");

            a = -20;
            Point p5 = a + p4;
            Console.WriteLine($"{a} + {p4} = {p5}");

            string s = "31321";
            Console.WriteLine(s.GetHashCode());

            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------
            // Сравнение == != < >

            Point pt = new Point(20,-5);
            Point pt2 = new Point(20,-5);

            Console.WriteLine($"{pt} == {pt2} => {pt == pt2}");
            bool r = pt != pt2;
            Console.WriteLine($"{pt} != {pt2} => {r}");

            Console.WriteLine();

            Point pg = new Point(20, -50);
            Point pg2 = new Point(2, -5);
            Console.WriteLine($"{pg} > {pg2} => {pg > pg2}");
            Console.WriteLine($"{pg} < {pg2} => {pg < pg2}");

            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------
            // True и False
            Point k1 = new Point(-20, -5);
            Point k2 = new Point(0, -5);
            Point k3 = new Point(0, 0);
            Point k4 = new Point(-5, -5);
            Point k5 = new Point(-20, -5);

            if(k1)
                Console.WriteLine($"{k1} => True");
            else Console.WriteLine($"{k1} => False");

            if (k2)
                Console.WriteLine($"{k2} => True");
            else Console.WriteLine($"{k2} => False");

            if (k3)
                Console.WriteLine($"{k3} => True");
            else Console.WriteLine($"{k3} => False");

            if (k4)
                Console.WriteLine($"{k4} => True");
            else Console.WriteLine($"{k4} => False");

            Console.WriteLine();

            // -----------------------------------------------------------------------------------------------------
            // && ||

            if (k1 && k2)
                Console.WriteLine($"{k1} && {k2} => True");
            else Console.WriteLine($"{k1} && {k2} => False");
 
            if (k1 || k3)
                Console.WriteLine($"{k1} && {k3} => True");
            else Console.WriteLine($"{k1} && {k3} => False");

#endif
            Console.ReadLine();
        }
    }
}
