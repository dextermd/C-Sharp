using ls_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            /*
                Задание 1: Для уже существующего класса MyArray (делали на занятии) перегрузить оператор +
                для конкатенации двух объектов класса, результат - другой массив. Также для этого класса
                реализуйте приведение к типу double (возвращать среднее арифметическое массива).
                Продемонстрируйте работу программы.
            */

            MyArray arr1 = new MyArray(5, 6, 8, 7, 9, 8, 2);
            Write($"arr1 = ");
            arr1.Show();

            WriteLine();

            MyArray arr2 = new MyArray(10, 7, 3, 1, 1, 2, 4);
            Write($"arr2 = ");
            arr2.Show();

            WriteLine();

            MyArray arr3 = new MyArray();
            arr3 = arr1 + arr2;
            Write($"arr3 = ");
            arr3.Show();

            double avg = arr3;
            WriteLine();
            WriteLine($"Average arr3 = {avg:F}");
#endif

#if false
            /*
                Задание 2: Опишите два класса: для хранения температуры по Цельсию и Фаренгейту.
                Реализуйте возможность явного приведения типа объектов этих классов. Использовать
                инструмент приведения типов. 
                Формулы:
                    Цельсий х 1,8 + 32 = Фаренгейт
                    (Фаренгейт — 32) : 1,8 = Цельсий
            */
            Celsius celsius = new Celsius(36.6);
            Fahrenheit fahrenheit = new Fahrenheit(90.1);

            Fahrenheit f = celsius;
            WriteLine($"Celsius {celsius} to Fahrenheit {f}");

            Celsius c = fahrenheit;
            WriteLine($"Fahrenheit {fahrenheit} to Celsius {c}");

#endif

#if false
            /*
                Задание 3: Опишите класс, объект которого хранит количество отработанных часов за каждый
                рабочий день (5 рабочих дней). В классе реализуйте индексатор для доступа к количеству часов
                за заданный день, который передается в виде названия дня недели (например, Понедельник), при
                этом регистр не учитывается. При помощи индексатора можно задать и получить количество
                часов за указанный день. Также программа выводит на экран результаты по каждому дню и
                вычисляет сумму всех отработанных часов за неделю. Обработать возможные исключительные
                ситуации, например – неверное название дня недели.
               
                Пример работы программы,
                        День недели Кол-во часов
                        Понедельник: 4
                        Вторник: 5
                        Четверг: 3,5
                        Всего часов: 12,5
            */
            HoursWorked hoursWorked = new HoursWorked();
            WriteLine(hoursWorked);
            hoursWorked["Понедельник"] = 8.6;
            hoursWorked["Пятница"] = 3.2;
            WriteLine(hoursWorked);
#endif

#if false
            /*
                Задание 4: Для уже существующего класса Matrix (делали на занятии) перегрузите индексатор
                только для чтения для квадратной матрицы, который по названию диагонали возвращает
                максимальное значение по этой диагонали в матрице. Например, для главной диагонали имя
                “first”, для вспомогательной – “second”. Обработать исключительные ситуации: неверное имя
                диагонали и неквадратная матрица. В каждом случае выводить соответствующее сообщение
                отдельным цветом.
            */

            Matrix matrix = new Matrix(8,8);
            matrix.Show();

            WriteLine();

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = random.Next(100, 999);
                }
            }

            matrix.Show();

            try
            {
                WriteLine($"Max first = {matrix["first"]}");
                WriteLine($"Max second = {matrix["second"]}");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

#endif
            ReadLine();
        }
    }
}
