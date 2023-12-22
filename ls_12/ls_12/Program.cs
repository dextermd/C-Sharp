using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Реализовать абстрактный базовый класс Геом. Фигуры, который включает:
                - автоматическое свойство Name
                - Конструкторы
                - абстрактный метод Draw
                - перегрузку ToString
 
                Описать производные классы: Круг, Прямоугольник, Треугольник, Шестиугольник.
                    Круг - добавить радиус
                    Прямоугольник - добавить ширину и высоту
                    Треугольник(прямоугольный) - добавить сторону и высоту
                    Шестиугольник  - добавить сторону
 
                Для всех производных классов описать конструкторы, переопределить методы Draw и ToString.
 
                Описать интерфейсы: IArea, IPerimeter, IPointy, IDraw3D
                    IArea - метод Area 
                    IPerimeter - метод Perimeter
 
                    IPointy - свойство Points только для чтения: количество точек
                    IDraw3D - метод Draw
 
 
                Для классов Круг, Прямоугольник, Треугольник реализовать интерфейсы: IArea, IPerimeter
 
                Для классов Прямоугольник, Треугольник, Шестиугольник  реализовать интерфейс: IPointy
 
                *** Для класса Шестиугольник  реализовать интерфейс IDraw3D с методом Draw.
            */
#if false
            Circle circle = new Circle { Name = "Колобок", Radius = 5.5 };
            Console.WriteLine(circle);
            Console.WriteLine($"Периметр: {circle.Perimeter():F2}");
            Console.WriteLine($"Площадь: {circle.Area():F2}");

            Console.WriteLine();

            Triangle triangle = new Triangle("Линейка", 10.2, 2.4);
            Console.WriteLine(triangle);

            Console.WriteLine();

            Rectangle rectangle = new Rectangle("Рамка", 10, 6);
            Console.WriteLine(rectangle);

            Console.WriteLine();

            Hexagon hexagon = new Hexagon { Name = "Соты", Side = 0.25 };
            Console.WriteLine(hexagon);
            hexagon.Draw();
            (hexagon as IDraw3D).Draw();
            (hexagon as IColorDraw).Draw();         

            Console.WriteLine();

            // --------------------------------------------------------------

            IArea area = new Circle("My Circle", 50.25);
            Console.WriteLine($"Площадь: {area.Area():F2}");

            Console.WriteLine($"{(area as Circle).Radius}");

            Console.WriteLine();

            area = rectangle;
            Console.WriteLine(area);
            Console.WriteLine($"Площадь: {area.Area():F2}");

            Console.WriteLine();

            // --------------------------------------------------------------

            IPointy[] pointies = {rectangle, hexagon, triangle};
            Console.WriteLine("Массив обьектов(массив ссылок на интерфейс)\n");
            foreach ( IPointy pointy in pointies)
            {
                Console.WriteLine(pointy);
                Console.WriteLine($"У обекта {pointy.Points} углов");
                Console.WriteLine();
            }
#endif
            /*
                Создать класс автомобиль Car, характеристики: марка, скорость, цена.
                Реализовать конструкторы и перегрузить метод ToString().
 
                Создать класс гараж Garage, массив автомобилей.
                Реализовать конструкторы.
 
                Объявить объект типа Garage, проинициализировать и вывести на экран.
 
                Для возможности использовани цикла foreach надо реализовать интерфейс IEnumerable.
                Тип станет коллекцией.
            */
#if true
            Car car = new Car("Bendly", 300, 30000);
            Console.WriteLine(car);
            Console.WriteLine();

            Garage garage = new Garage();
            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            garage.Sort();

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
#endif

            Console.ReadLine();
        }
    }
}
