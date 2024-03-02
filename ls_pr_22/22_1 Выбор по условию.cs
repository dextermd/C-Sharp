namespace _22_1_Use_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false

            // Сформировать запрос на получение получение положит. значение в отсортированном виде
            int[] m2 = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

            List<int> list = (from x in m2
                         where x > 0
                         //orderby x // по умолчанию - по возрастнанию
                         orderby x descending // по убыванию
                         select x).ToList();

            Console.WriteLine("\n Положительные значения массива в отсортированном виде:");
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

#endif

#if false

            //-----------------------------------------------------------
            /*
             Сформировать запрос на получение адресов
	         интернета, оканчивающихся на .net. и длиной > 4 символов
             */

            string[] strs = { ".com", ".net", "test.com",
                                "sitename.net", "test", ".network",
                                "hsNameC.net", "hsNameD.com" };

            IEnumerable<string> query = from address in strs
                        where address.Length > 4
                        where address.EndsWith(".net")
                        select address;

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }

            // Немедленное выполенние
            List<string> query2 = (from address in strs
                                        where address.Length > 4
                                        where address.EndsWith(".net")
                                        select address)
                                        .ToList();//***

            var query3 = strs.Where(item => item.Length > 4 && item.EndsWith(".com")).ToList();
            
            Console.WriteLine();
            // Немедленное выполнение
            foreach (string item in query3)
            {
                Console.WriteLine(item);
            }
#endif

#if false

            /*
            Задача 4: В классе Person есть список языков, которыми владеет пользователь. 
            Отфильтровать пользователей до 28 лет по определенному языку.
             */

            var people = new List<Person>
            {
            new Person ("Ivanov", 23, new List<string> {"english", "german"}),
            new Person ("Petrov", 27, new List<string> {"english", "french" }),
            new Person ("Sidorov", 29, new List<string>  { "english", "spanish" }),
            new Person ("Borisov", 24, new List<string> {"spanish", "german" })
            };

            string language = "english";

            var query = from person in people
                        from lang in person.Languages
                        where person.Age < 28
                        where lang == language  // "spanish"
                        select person;

            // Выполнение запроса
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }

#endif
            //---------------------------------------------------------
            /*
             Задача 5: Фильтрация по типу данных
             */

            var shapes = new List<Shape>
            {
                new Circle("Круг"),
                new Rectangle("Рамка"),
                new Circle("Круг 2"),
                new Rectangle("Окно"),
                new Circle("Круг 3"),
            };

            var quary = shapes.OfType<Circle>();

            foreach (var shape in quary)
            {
                Console.WriteLine(shape.Name);
            }

            Console.Read();
        }
    }
    record class Person(string Name, int Age, List<string> Languages);

    record class Shape(string Name);
    record class Circle(string Name) : Shape(Name);
    record class Rectangle(string Name) : Shape(Name);
}

