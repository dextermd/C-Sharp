using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //Задание 1: Реализовать класс «Книга» с характеристиками: Автор и Название.
            //В классе Книга описать внутренний класс Дополнительная Информация: Издательство, год
            //издания, Жанр, стоимость, количество.Опишите класс «Книжный магазин», в котором есть
            //массив книг. Реализуйте возможности:
            //    -просмотра книг магазина с использованием оператора foreach,
            //    -сортировку книг по разным критериям(Автору, Названию, Жанру, Стоимости)
            //    -создание независимой копии книги.
            //Для этого необходимо реализовать соответствующие интерфейсы.
            //Продемонстрируйте работу на проинициализированном объекте «Книжный магазин».

            BookShop bookShop = new BookShop();
            Book book = new Book("a","a","a","a","a",1,1);

            foreach (var bookItem in bookShop)
            {
                Console.WriteLine(bookItem);
            }

            Console.WriteLine("---------------------AuthorCompareDecr-------------------------");
            bookShop.Sort(new AuthorCompareDecr());

            foreach (var bookItem in bookShop)
            {
                Console.WriteLine(bookItem);
            }

            Console.WriteLine("---------------------AuthorCompareIncr-------------------------");
            bookShop.Sort(new AuthorCompareIncr());

            Console.WriteLine();
            Console.WriteLine(book);

            Book book1 = (Book)book.Clone();
            book.Author = "!!!!!";

            Console.WriteLine(book1); ;


#endif

#if true
            //Задание 2: Создайте набор методов для работы с массивами:
            //-Метод для отображения всех чисел по определенному критерию;
            //-Метод для подсчета количества чисел по определенному критерию;
            //Протестировать методы для данных массива: четные, нечетные, больше нуля, меньше нуля,
            //простые.Используйте механизмы делегатов.
            //Также выведите массивы по всем критериям последовательно.Пример работы программы:

            int[] arr = { 1, 20, -3, 4, 5, 6, 199, -8, 9, -10, 277, -12, 13, 14, 15 };

            ArrWork arrWork = new ArrWork();
            Console.WriteLine($"Четные числа: \n {arrWork.Show(arrWork.GetEven(arr))}");
            Console.WriteLine($"Количество четных чисел в массиве: {arrWork.GetEvenCount(arr)}");
            Console.WriteLine($"Нечетные числа: \n {arrWork.Show(arrWork.GetOdd(arr))}");
            Console.WriteLine($"Количество нечетных чисел в массиве: {arrWork.GetOddCoun(arr)}");
            Console.WriteLine($"Простые числа: \n{arrWork.Show(arrWork.GetPrime(arr))}");
            Console.WriteLine($"Количество простых чисел в массиве: {arrWork.GetPrimeCount(arr)}");
            Console.WriteLine($"Числа больше нуля: \n{arrWork.Show(arrWork.GreaterThanZero(arr))}");
            Console.WriteLine($"Количество чисел больше нуля в массиве: {arrWork.GreaterThanZeroCount(arr)}");
            Console.WriteLine($"Числа меньше нуля: \n{arrWork.Show(arrWork.LessThanZero(arr))}");
            Console.WriteLine($"Количество чисел меньше нуля в массиве: {arrWork.LessThanZeroCount(arr)}");

            Console.WriteLine("========================================");

            ArrWorkDelegate arrWorkDelegate = null;
            arrWorkDelegate = arrWork.GetEven;
            arrWorkDelegate += new ArrWorkDelegate(arrWork.GetOdd);
            arrWorkDelegate += new ArrWorkDelegate(arrWork.GetPrime);
            arrWorkDelegate += new ArrWorkDelegate(arrWork.GreaterThanZero);
            arrWorkDelegate += new ArrWorkDelegate(arrWork.LessThanZero);

            foreach (ArrWorkDelegate item in arrWorkDelegate.GetInvocationList())
            {
                Console.WriteLine($"Result: {arrWork.Show(item(arr))}");
            }
#endif
            Console.ReadLine();
        }
    }
}
