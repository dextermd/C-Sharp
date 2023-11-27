using ls_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseRectanglePoint
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if true
            //Описать класс ПРЯМОУГОЛЬНИК
            //Характеристики: координаты левого верхнего и правого нижнего углов.
            //Тип координат - класс Point

            RectanglePoint rectanglePoint = new RectanglePoint();
            Console.WriteLine($"{rectanglePoint.TopLeft.X}");

            RectanglePoint rectanglePoint2 = new RectanglePoint(new Point(5,-5), new Point(2,9));
            Console.WriteLine($"{rectanglePoint2.TopLeft}" + $"{rectanglePoint2.BottomRight}");

            RectanglePoint rectanglePoint3 = new RectanglePoint(rectanglePoint2);
            rectanglePoint2.TopLeft.X = 100;
            Console.WriteLine($"{rectanglePoint3.TopLeft}" + $"{rectanglePoint3.BottomRight}");
            Console.WriteLine($"{rectanglePoint3}");

            string s = null;
            //if (s == null)
            //{
            //    //Console.WriteLine("Нет данных");
            //    s = s ?? "Нет данных";
            //    Console.WriteLine(s);
            //}
            //else
            //{
            //    Console.Write("Строка: {0}", s.ToUpper());
            //}

            // ?? - оператор обьединения c null
            // ?. - оператор условного null
            Console.Write("Строка: {0}", s?.ToUpper() ?? "Нет данных!");

#endif
            Console.ReadLine();
        }
    }
}
