namespace _22_3_Проекция
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             Сформировать запрос на получение квадратных корней всех
                положительных значений, содержащихся в массиве.
             */

            int[] mas = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

            /*var*/IEnumerable<double> query = from n in mas
                        where n > 0
                        select Math.Sqrt(n);

            foreach (double item in query)
            {
                Console.WriteLine($"{item:F2}");
            }

            //-------------------------------------------------

            /*
             Дан список Person. Написать запрос для выбора только имен объектов.
             */

            var list = new List<Person>
            {
                new Person("Marks", 6),
                new Person("Skittles", 3),
                new Person("Alex", 25),
                new Person("Tom", 26),
                new Person("Bob", 25),
            };

            var names = from n in list 
                        select n.Name; // string

            foreach (string item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------");

            /*
             Анонимный тип как результат запроса - 
             в результате запроса получить имя и возраст объектов
             */

            var queryAnonim = from p in list
                        select new
                        {
                            FullName = p.Name,
                            Age = p.Age,
                        };

            foreach (var item in queryAnonim)
            {
                Console.WriteLine($"{item.FullName} - {item.Age}");
            }
            Console.WriteLine("------------------------------------");
            //-------------------------------------------------
            // Переменные в запросах и оператор let
            // Подсчет года рождения по возрасту(имя, год рождения)
            var queryAnonim2 = from p in list
                               let year = DateTime.Now.Year - p.Age// локальная переменная в запросе
                               select new
                               {
                                   FullName = p.Name,
                                   Year = year,
                               };

            foreach (var item in queryAnonim2)
            {
                Console.WriteLine($"{item.FullName} - {item.Year}");
            }

            Console.WriteLine();

            var queryAnonim3 = list.Select(p => new
            {
                FullName = p.Name,
                Year = DateTime.Now.Year - p.Age,
            });


            foreach (var item in queryAnonim3)
            {
                Console.WriteLine($"{item.FullName} - {item.Year}");
            }
            Console.WriteLine("-----------------------------------");
            //----------------------------------------------------------

            /*
             Сформировать запрос на получение списка объектов типа 
             EmailAddress из массива объектов ContactInfo.
             */

           ContactInfo[] contacts = {
                new ContactInfo("Alex", "alex@gmail.com", "069789654"),
                new ContactInfo("Anton", "anton@mail.ru", "079321456"),
                new ContactInfo("Elena", "elena@outlook.com", "060123456")
            };

            var emailList = from contact in contacts
                            select new EmailAddress(contact.Name, contact.Email);

            foreach (EmailAddress item in emailList)
            {
                Console.WriteLine($"{item.Name} - {item.Address}");
            }

            Console.Read();
        }
    }
    record class ContactInfo(string Name, string Email, string Phone);
    record class EmailAddress(string Name, string Address);
    record class Person(string Name, int Age, string Email="no email");

    
}