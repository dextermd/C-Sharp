using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ls_18
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            /*
                Задача: Создайте generic класс односвязный список MyList<T>. Реализуйте
                стандартные методы и свойства для работы односвязного
                списка.
            */

            // Reference Type
            Node<int> node = new Node<int>(5);
            Node<int> node2 = new Node<int>(5);
            Node<int> node3 = new Node<int>(15);

            Console.WriteLine($"{node} == {node2} => {node.Equals(node2)}");
            Console.WriteLine($"{node} == {node3} => {node.Equals(node3)}");
            Console.WriteLine($"{node}.CompareTo({node2}) => {node.CompareTo(node2)}");
            Console.WriteLine($"{node}.CompareTo({node3}) => {node.CompareTo(node3)}");
            Console.WriteLine($"{node3}.CompareTo({node}) => {node3.CompareTo(node)}");

            MyList<int> myList = new MyList<int>();
            myList.AddEnd(12);
            myList.AddEnd(-7);
            myList.AddEnd(156);
            myList.AddEnd(120);

            Console.WriteLine();

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            myList.Show();

            Console.WriteLine($"Кол-во элементов списка {myList.Count}");

            Console.WriteLine();
            myList.AddBegin(10);
            myList.Show();
            myList.AddBegin(1);
            myList.Show();
            myList.AddEnd(66);
            myList.Show();

            Console.WriteLine($"Кол-во элементов списка {myList.Count}");

            if (myList.Contains(156))
                Console.WriteLine("Значение найдено ");
            else Console.WriteLine("Значение не найдено ");

            Console.WriteLine();

            Product product = new Product("Pen", 25.35);
            Product product1 = new Product("Notebook", 45.15);
            Product product2 = new Product("Line", 5.10);

            MyList<Product> products = new MyList<Product>();

            products.AddEnd(product);
            products.AddEnd(product1);
            products.AddBegin(product2);

            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            products.Show();

#endif

#if false
            ArrayList arrayList = new ArrayList();
            Console.WriteLine($"Capacity: {arrayList.Capacity}");
            Console.WriteLine($"Count: {arrayList.Count}");

            Console.WriteLine();

            ArrayList arrayList2 = new ArrayList(new int[] {2, -6, 6, 9, 15, -78, 56,3 });
            Console.WriteLine($"Capacity: {arrayList2.Capacity}");
            Console.WriteLine($"Count: {arrayList2.Count}");

            Console.WriteLine();

            arrayList2.Add(145);
            arrayList2.Add(-145);
            arrayList2.Add(20);

            Console.WriteLine($"Capacity: {arrayList2.Capacity}");
            Console.WriteLine($"Count: {arrayList2.Count}");

            foreach (var item in arrayList2)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();

            arrayList2.Remove(15);

            foreach (var item in arrayList2)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();

            arrayList2.RemoveAt(0);

            foreach (var item in arrayList2)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();


            Product product = new Product("Pen", 25.35);
            Product product1 = new Product("Notebook", 45.15);
            Product product2 = new Product("Line", 5.10);

            arrayList2.Add(product);
            arrayList2.Add(product1);
            arrayList2.Add(product2);

            foreach (var item in arrayList2)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();

#endif

#if true
            List<string> list = new List<string> { "one", "two", "three" };

            List<int> list2 = new List<int> { 1, 2, 3 };
            
            list2.Add(-125);
            list2.Add(632);
            list2.Add(50);

            foreach (var item in list2)
            {
                Console.Write(item + "  ");
            }

            Console.WriteLine();

            Product product = new Product("Pen", 25.35);
            Product product1 = new Product("Notebook", 45.15);
            Product product2 = new Product("Line", 5.10);

            List<Product> list3 = new List<Product> { product, product1, product2 };

            foreach (var item in list3)
            {
                Console.WriteLine(item + "  ");
            }

            Console.WriteLine();

            list3.Sort();

            foreach (var item in list3)
            {
                Console.WriteLine(item + "  ");
            }

            Console.WriteLine();


            list3.Sort((x, y) => y.Price.CompareTo(x.Price));

            foreach (var item in list3)
            {
                Console.WriteLine(item + "  ");
            }

            Console.WriteLine();

            int min = 20, max = 30;
            List<Product> list4 =  list3.FindAll(p => p.Price >= min && p.Price <= max);

            foreach (var item in list4)
            {
                Console.WriteLine(item + "  ");
            }

            Console.WriteLine();

            PriceRange range = new PriceRange() { min = 1, max = 6 };

            List<Product> list5 = list3.FindAll(range.IsInRange);

            foreach (var item in list5)
            {
                Console.WriteLine(item + "  ");
            }

            Console.WriteLine();

            list3.ForEach(p => {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[{p}]");
                Console.ResetColor();
            });

#endif

            Console.ReadLine();
        }

        // Класс, содержащий критерий поиска
        internal class PriceRange
        {
            public double min;
            public double max;

            public bool IsInRange(Product product)
            {
                return product.Price >= min && product.Price <= max;
            }
        }
    }
}
