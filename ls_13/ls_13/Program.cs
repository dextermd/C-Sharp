using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            Car car = new Car("Bendly", 300, 30000, new Car.CarInfo { Number = "AFE 963", Year = 2024 });
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

            // Реализовать возможность сортировки массива по разным критериям, перезагрузить метод Sort
            // Передать в качестве параметра интерфэйсу

            garage.Sort(new SpeedCompareIncr());

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            garage.Sort(new SpeedCompareDecr());

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            garage.Sort(Car.SortBySpeedIncr); // Через статическое свойство 

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            //В классе Car описать внутренний класс CarInfo
            //для хранения информации об автомобиле: номер, год выпуска.

            //Самостоятельно реализовать сортиовку по году выпуска
            //(по возрастанию и убыванию).

            garage.Sort(Car.SortByYearDecr); // Через статическое свойство 

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }


            garage.Sort(Car.SortByYearIncr); // Через статическое свойство 

            Console.WriteLine("Массив после сортировки\n");

            foreach (var item in garage)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            // Реализовать возможность копирования объекта (глубокая копия).

            Console.WriteLine();
            Console.WriteLine("-------------------------- Обьект ---------------------------------");
            Console.WriteLine(car);
            Console.WriteLine("-------------------------- Копия Обьекта ---------------------------------");
            Car carC = (Car)car.Clone();
            car.CarInformation.Year = 2010;
            car.Speed = 250;
            Console.WriteLine(carC); // год тут тоже поменялся потому что мы  сделали поверхостную копию (копию ссылки).

            Console.WriteLine();
            Car carC2 = (Car)carC.Copy();
            carC.CarInformation.Year = 1111;
            carC.Speed = 222;
            Console.WriteLine(carC2);
#endif

            // Делегаты
#if false
            Calculator calculator = new Calculator();

            double d1 = 2.5, d2 = 6.8;
            CalcDelegate calcDelegate = new CalcDelegate(calculator.Add);
            Console.WriteLine($"{d1} + {d2} = {calcDelegate(d1,d2)}");

            calcDelegate = new CalcDelegate(Calculator.Sub);
            Console.WriteLine($"{d1} - {d2} = {calcDelegate(d1, d2)}");

            // Синтаксис группового пербразования методов
            calcDelegate = calculator.Mult;
            Console.WriteLine($"{d1} * {d2} = {calcDelegate(d1, d2)}");
            Console.WriteLine($"{d1} * {d2} = {calcDelegate.Invoke(d1, d2)}");

            calcDelegate = calculator.Div;
            Console.WriteLine($"{d1} / {d2} = {calcDelegate.Invoke(d1, d2)}");
#endif

            // Делегаты
#if true
            Calculator calculator = new Calculator();
            CalcDelegate delAll = null;

            double d1 = 2.5, d2 = 6.7;

            delAll = calculator.Add;
            Console.WriteLine($"Сложение: {delAll(d1, d2)}");
            delAll += Calculator.Sub;
            Console.WriteLine($"Деление: {delAll(d1, d2)}");
            delAll += calculator.Div;
            Console.WriteLine($"Вычетание: {delAll(d1, d2)}");

            Console.WriteLine();
            Console.WriteLine();

            delAll += new CalcDelegate(calculator.Div);
            delAll += new CalcDelegate(calculator.Mult);
            delAll += Test;
     

            foreach (CalcDelegate item in delAll.GetInvocationList())
            {
                Console.WriteLine(item(d1, d2));
                
            }

            Calculator t = new Calculator();
            CalcDelegate calcDelegate = t.Add;

            DoOperation(2.5, 7.8, calcDelegate);
            DoOperation(2.5, 7.8, t.Mult);


#endif

            Console.ReadLine();
        }


        static double Test(double x, double y)
        {
            Console.WriteLine("Test: ");
            return x + y;
        }

        static void DoOperation(double x, double y, CalcDelegate oper)
        {
            double r = oper(x, y);
            Console.WriteLine($"result: {r}");
        }
    }
}
