using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Описать класс КООРДИНАТА для хранения трех координат дробного типа.
 
Конструтор, методы доступа.
Вывод данных об объекте.
 
Посчитать количество созданных объектов.
*/

namespace ls_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if true
            /*
                Описать класс Point (две координаты)
                с использованием свойств
                Вместо Show переопределить метод ToString()
            */

            Point point = new Point();
            Console.WriteLine($"{point.X};{point.Y}");
            point.X = 20;
            point.Y = -5;
            Console.WriteLine($"{point.X};{point.Y}");

            string tmp = $"{point.X};{point.Y}";
            Console.WriteLine(tmp);

            // Инициализация обьекта через свойства
            Point point2 = new Point
            {
                X = -10,
                Y = 95
            };

            Console.WriteLine($"{point2.X};{point2.Y}");
            Console.WriteLine();


            Console.WriteLine(point2); // отрабатывает public override string ToString()
            Console.WriteLine($"{point2}"); // отрабатывает public override string ToString()

            Point point3 = new Point(point); // Отрабатывает конструктор копирование
            Console.WriteLine(point3);



#endif

#if false
            /*
                Описать класс КООРДИНАТА для хранения трех координат дробного типа.
                Конструтор, методы доступа.
                Вывод данных об объекте.
                Посчитать количество созданных объектов.
            */

            Coord coord = new Coord();
            coord.Show();
            Coord coord2 = new Coord(12.35, 45.5, 33.11);
            coord2.Show();
            coord2.SetX(560);
            coord2.Show();

            // Доступ у статическому полю класса ТОЛЬКО через имя класса
            Console.WriteLine("Кол-во обьектов: {0}", Coord.GetCount());
            Console.WriteLine("MAX : {0}", Coord.MAX);
            Console.WriteLine("MIN : {0}", Coord.MIN);

            // 1. Конструктор копий
            Coord coord4 = new Coord(coord2);
            coord2.SetX(-200);
            coord4.Show();

            // 2. Метод Copy
            Coord coord3 = coord4.Copy();
            coord4.SetY(1000);
            coord3.Show();

            Console.WriteLine("Кол-во обьектов: {0}", Coord.GetCount());
            // К нестатическому полю readonly доступ через экземпляр класса
            Console.WriteLine($"Name : {coord2.name}");

            // Деконструкторы - выполняет декомпозицию обьекта (извлекаем одновременно все значения)
            coord3.Deconstruct(out double rx, out double ry, out double rz);
            Console.WriteLine($"{rx:F2} {ry:F2} {rz:F2}");

            (double rx2, double ry2, double rz2) = coord3;
            Console.WriteLine($"{rx:F2} {ry:F2} {rz:F2}");


#endif


            Console.ReadLine();
        }
    }
}
