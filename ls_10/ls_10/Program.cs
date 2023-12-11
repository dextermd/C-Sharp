using ls_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ls_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            // Пример двухмерного индексатора (Class Matrix)
            // использование класса Matrix
            Matrix matrix = new Matrix(3, 5);

            Random random = new Random();

            // формирование массива с помощью индексатора
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = random.Next(5, 10);
                    Console.Write($"{matrix[i, j],6}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"matrix[1, 3]: {matrix[1, 3]}");

            Console.WriteLine($"matrix[2, 1]: {matrix[2, 1]}");
            matrix[2, 1] = 50;
            Console.WriteLine($"matrix[2, 1]: {matrix[2, 1]}");

            // вывод
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{matrix[i, j],6}");
                }
                Console.WriteLine();
            }
#endif

#if false
            // Индексаторы ***********************************************************************************************
            /*
                Опишите класс футболиста, который содержит имя футболиста и его номер на поле. 
                И определите класс футбольной команды, который хранит 11 футболистов в виде массива и обеспечивает доступ к футболистам из массива через индексатор.
 
                Добавьте в класс футболиста возможность хранения телефона.
                Перегрузите индексатор для получения номера телефона по имени.
            */

            FootballTeam team = new FootballTeam();
            team[1] = new FootballPlayer("Ivanov", 1, "+37368499542");
            team[2] = new FootballPlayer("Petrov", 9, "+37307985646");
            Console.WriteLine(team[1].FullName);
            Console.WriteLine(team[2].FullName);

            Console.WriteLine(team["Ivanov"]);

            Console.WriteLine(team);

            Console.WriteLine(team["Ivanov"]);

            Console.WriteLine(team[1]);
            Console.WriteLine(team[2]);
#endif

#if false
            // Индексаторы ***********************************************************************************************
            // Добавьте в класс Point индексотор  для доступа к значениям ккординат.
            // По индексу 0 получаем / устанавливаем значение X, по индексу 1 - значение Y, в противном случае исключение;

            Point k = new Point(5, 12);
            Console.WriteLine($"Point k: {k}");
            try
            {
                k[0] = -12;
                k[1] = 56;
                Console.WriteLine($"Point k: {k}");
            }
            catch (IndexOutOfRangeException exp)
            {
                Console.WriteLine(exp.Message);
            }
#endif

#if false
            // Индексаторы ***********************************************************************************************
            /*
                // Перегрузка операторов, индексатор

                Описать простой класс MyArray для хранения целых значений.
                Поле - одномерный массив целых.
                Реализовать конструторы: по умолчанию, принимающий размер массива и с неопределенным количеством значений массива.
                Написать метод для вывода массива на экран.

                Перегрузить оператор + для конкатенации двух объектов класса, результат - другой массив.

                Реализовать индексатор для доступа к значению объекта типа MyArray по индексу.
            */

            MyArray myArray = new MyArray(2,3,6,9,10,9);
            myArray.Show();
            Console.WriteLine();
            // Небезопасный код try - catch
            Console.WriteLine($"{myArray[1]}");
            myArray[1] = 25;
            Console.WriteLine($"{myArray[1]}");
            myArray.Show();


#endif

#if false
            // Преобразования типов **************************************************************************************
            // Point - Преобразования типа: Point в int
            // string в Point

            Point point = new Point(5,10);
            int p = point;
            Console.WriteLine($"Целое число {p} на основе точки {point}");

            string str = "25;-6;69";
            Point point_str = str;
            Console.WriteLine($"Точка {point_str} на основе строки {str}");
#endif
            Console.ReadLine();
        }
    }
}
