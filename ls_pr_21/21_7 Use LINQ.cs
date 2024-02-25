//using System.Linq;

namespace Use_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] m = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

            /*var*/ IEnumerable<int> query = from x in m 
                                     where x > 0
                                     select x;

            Console.WriteLine("Положительные значения массива:");
            // Выполнение запроса:
            foreach (int item in query)
            {
                Console.Write($"{item}  ");
            }

            m[0] = -200;

            Console.WriteLine("\nПоложительные значения массива:");
            // Выполнение запроса:
            foreach (int item in query)
            {
                Console.Write($"{item}  ");
            }

            Console.WriteLine("\n------------------------------------------");
            //public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)

            // Использование метода расширения
            IEnumerable<int> query2 = m.Where(x => x > 0);

            Console.WriteLine("\n значения массива:");
            // Выполнение запроса:
            foreach (int item in query2)
            {
                Console.Write($"{item}  ");
            }

            Console.WriteLine("\n------------------------------------------");
            // Использование метода статического класса
            IEnumerable<int> query3 = Enumerable.Where(m, x => x > 0);



            //-------------------------------------------------------------
            // Сформировать запрос на получение получение положит. значение в отсортированном виде
            int[] m2 = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

            var query4 = from x in m2
                         where x > 0
                         //orderby x // по умолчанию - по возрастнанию
                         orderby x descending // по убыванию
                         select x;

            Console.WriteLine("\n Положительные значения массива в отсортированном виде:");
            foreach(int item in query4)
            {
                Console.Write(item + " ");
            }

            //var query5 = m2.Where(x => x > 0).OrderByDescending(x=>x);
            var query5 = m2
                    .Where(x => x > 0)
                    .OrderByDescending(x=>x);

            Console.WriteLine("\n Положительные значения массива в отсортированном виде:");
            foreach (int item in query5)
            {
                Console.Write(item + " ");
            }

            var query6 = Enumerable
                         .OrderByDescending(Enumerable
                         .Where(m2, x => x > 0), x=>x);

            Console.Read();
        }
    }
}