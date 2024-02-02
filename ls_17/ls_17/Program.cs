using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_17
{
    internal class Program
    {
        static public T Maximum<T>(T x, T y) where T : IComparable<T>
        {
            return x.CompareTo(y) > 0 ? x : y;
        }

        static public T Maximum<T>(T x, T y, IComparer<T> comparer)
        {
            return comparer.Compare(x, y) > 0 ? x : y;
        }
        static public T Maximum<T>(T x, T y, Func<T, T, int> comparer)
        {
            return comparer(x, y) > 0 ? x : y;
        }

        static void Main(string[] args)
        {

#if false
            /*
                Задача: Для простого класса Product (Наименование товараm цена)
                реализовать стандартный обобщенный интерфэйс IComparable<Product+>
            */
            Product product = new Product("apple",12.25);
            Product product2 = new Product("orange",20.34);
            Product product3 = new Product("orange",20.34);

            Console.WriteLine($"Сравнение обьектов {product.Name} и {product2.Name} по имени: {product.CompareTo(product2)}");
            Console.WriteLine($"Сравнение обьектов {product2.Name} и {product.Name} по имени: { product2.CompareTo(product)}");
            Console.WriteLine($"Сравнение обьектов {product2.Name} и {product3.Name} по имени: { product3.CompareTo(product2)}");

            Console.WriteLine($"Сравнение обьектов {product2.Name} и {product3.Name} по имени: { product3.Equals(product2)}");
#endif

#if false
            // ----------------------- Ограничения --------------------------
            //  Задача: Реализовать обобщенный метод для нахождения максимального
            //  значения из двух переменных обобщенного типа.

            int a = 20, b = 21;
            Console.WriteLine($"Max: {a}, {b} = {Maximum(a,b)}");

            Product product = new Product("apple", 22.25);
            Product product2 = new Product("orange", 20.34);

            Console.WriteLine($"Max: {product.Name}, {product2.Name} = {Maximum(product, product2)}");

            Console.WriteLine($"Max by price: {product.Name}, {product2.Name} = {Maximum(product, product2, new PriceCompareIncr())}");

            Console.WriteLine($"Max by price: {product.Name}, {product2.Name} = {Maximum(product, product2, (x,y) => x.Price.CompareTo(y.Price))}");
#endif

#if true

        /*
            Задача: Напишите обобщенную коллекцию динамического массива.
            Реализуйте возможность просмотра коллекции при помощи foreach.
            Напишите метод для добавления элемента в конец массива, 
            метод изменения размера(емкости) массива.
            Реализуйте индексатор для доступа к элементам коллекции.
 
            Напишите методы :
            - Resize для изменения емкости массива
            - Contains для поиска элемента в массиве.
        */

            DymanicArray<int> dymanicArray = new DymanicArray<int>(4);

            Console.WriteLine($"Count: {dymanicArray.Count}");
            Console.WriteLine($"Capacity: {dymanicArray.Capacity}");
            Console.WriteLine();

            dymanicArray.Push(10);
            dymanicArray.Push(-3);
            dymanicArray.Push(158);
            dymanicArray.Push(-9);


            for (int i = 0; i < dymanicArray.Count; i++)
            {
                Console.Write($"{dymanicArray[i]}  ");
            }

            Console.WriteLine($"Count: {dymanicArray.Count}");
            Console.WriteLine($"Capacity: {dymanicArray.Capacity}");
            Console.WriteLine();


            DymanicArray<string> array = new DymanicArray<string>(10);
            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            Console.WriteLine();

            array.Push("Остров сокровищ");
            array.Push("Война и мир");
            array.Push("Старик и море");
            array.Push("Программирование на C++");
            array.Push("Три товарища");


            for (int i = 0; i < array.Count; i++)
            {
                Console.Write($"{array[i]}  ");
            }

            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            Console.WriteLine();

            foreach (var item in array)
            {
                Console.Write($"{item}\n");
            }

            Console.WriteLine();

            Print(array);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            Console.WriteLine();

            array.Resize(20);

            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            Console.WriteLine();

            array.Resize(3);

            Console.WriteLine($"Count: {array.Count}");
            Console.WriteLine($"Capacity: {array.Capacity}");
            Console.WriteLine();

            Print(array);
            Console.WriteLine();

            Console.WriteLine($"Contains index = {array.Contains("Старик и море")}");

            array[2] = "Новое значение";

            Print(array);

#endif


            Console.ReadLine();
        }
        public static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write($"{item}\n");
            }
        }
    }
    internal class PriceCompareIncr : IComparer<Product>
    {
        public int Compare(Product x, Product y) 
        { 
            return x.Price.CompareTo(y.Price); 
        }
    }
}
