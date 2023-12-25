using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //Задание 1: Создайте интерфейс IOutput.В нём должно быть два метода:
            //    − void Show() — отображает информацию;
            //    − void Show(string info) — отображает информацию и информационное сообщение, которое было указано в параметре info.
            //Создайте класс Array(массив целого типа) с необходимыми методами.Этот класс должен
            //имплементировать интерфейс IOutput.
            //    − Метод Show() — отображает на экран элементы массива.
            //    − Метод Show(string info) — отображает на экран элементы массива и информационное сообщение, указанное в параметре info.
            //Напишите код для тестирования полученной функциональности.
            MyArray array = new MyArray();
            array.Show();
            Console.WriteLine();
            array.Show("World");
#endif

#if false
            //Задание 2: Создайте интерфейс IMath.В нём должно быть четыре метода:
            //    − int Max() — возвращает максимум;
            //    − int Min() — возвращает минимум;
            //    − float Avg() — возвращает среднеарифметическое;
            //    − bool Search(int valueToSearch) — ищет valueSearch внутри контейнера данных.Возвращает true,
            //если значение найдено.Возвращает false, если значение не найдено.
            //Класс, созданный в первом задании Array, должен имплементировать интерфейс IMath.
            //    − Метод Max — возвращает максимум среди элементов массива.
            //    − Метод Min — возвращает минимум среди элементов массива.
            //    − Метод Avg — возвращает среднеарифметическое среди элементов массива.
            //    − Метод Search — ищет значение внутри массива. Возвращает true, если значение найдено.
            //Возвращает false, если значение не найдено.
            //Напишите код для тестирования полученной функциональности.

            MyArray arr = new MyArray();
            Console.WriteLine($"Max arr = {arr.Max()}");
            Console.WriteLine($"Min arr = {arr.Min()}");
            Console.WriteLine($"Avg arr = {arr.Avg():F2}");
            Console.WriteLine($"45 exist in arr ?: {arr.Search(45)}");
#endif

#if false
            //Задание 3: Создайте интерфейс ISort.В нём должны быть методы:
            //    − void SortAsc() — сортировка по возрастанию;
            //    − void SortDesc() — сортировка по убыванию;
            //    − void SortByParam(bool isAsc) — сортировка в зависимости от переданного параметра. Если isAsc равен true,
            //    сортируем по возрастанию.Если isAsc равен false, сортируем по убыванию.
            //Класс, созданный в первом задании Array, должен имплементировать интерфейс ISort.
            //    − Метод SortAsc — сортирует массив по возрастанию.
            //    − Метод SortDesc — сортирует массив по убыванию.
            //    − Метод SortByParam — сортирует массив в зависимости от переданного параметра.Если isAsc равен
            //true, сортируем по возрастанию.Если isAsc равен false, сортируем по убыванию.
            //Напишите код для тестирования полученной функциональности.

            MyArray array = new MyArray();
            array.Show();
            Console.WriteLine();
            array.SortAsc();
            array.Show();
            Console.WriteLine();
            array.SortDesc();
            array.Show();
            Console.WriteLine();
            array.SortByParam(true);
            array.Show();
            Console.WriteLine();
            array.SortByParam(false);
            array.Show();
#endif

#if false
            //Задание 4: Опишите класс “Клиенты банка”, который хранит массив объектов класса
            //“Кредитная карточка” (домашнее задание 9).
            //Также в классе “Клиенты банка” реализуйте конструкторы.Добавьте возможность перебора элементов коллекции “Клиенты банка” при
            //помощи цикла foreach.Реализуйте метод для сортировки элементов коллекции по имени
            //владельца кредитной карты в алфавитном порядке(реализуйте интерфейс IComparable).
            //Продемонстрируйте работу программы на примерах.

            BankCustomer bankCustomer = new BankCustomer();
            
            foreach (var item in bankCustomer)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("************* bankCustomer посе сортировки *************");

            bankCustomer.Sort();

            foreach (var item in bankCustomer)
            {
                Console.WriteLine(item);
            }
#endif

            Console.ReadLine();
        }
    }
}
