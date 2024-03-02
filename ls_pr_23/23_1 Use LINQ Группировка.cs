namespace _23_1_Use_LINQ_Группировка
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people =
            {
                new Person("Alex", "Microsoft"), new Person("Tudor", "Google"),
                new Person("Boris", "JetBrains"), new Person("Elena", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Timur", "Microsoft"),
            };
            
            //Сгруппировать массив Person по компании.
            var query = from person in people
                        group person by person.Company;

            // или метод
            var query2 = people.GroupBy(p => p.Company);

            foreach (/*var*/IGrouping<string, Person> company in query2)
            {
                Console.WriteLine($"\t\"{company.Key}\"");
                foreach (var person in company)
                {
                    Console.WriteLine($"{person.Name}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------");
            
            int []m = { 1,2,3};
            Console.WriteLine(m.Count());
            //-------------------------------------------------
            //Сделать запрос и создать из группы новый объект:
            //количество Person в компании (Наименование и Количество)

            var query3 = from person in people
                         group person by person.Company
                         into g
                         select new
                         {
                             Name = g.Key,
                             Count = g.Count()
                         };

            var query4 = people
                .GroupBy(p => p.Company)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                });


            foreach (var company in query4)
            {
                Console.WriteLine($"{company.Name} - {company.Count}");
            }

            /*
             Результат:
                Microsoft : 3
                Google : 1
                JetBrains : 2

             */
            Console.Read();
        }
    }
    record class Person(string Name, string Company);
}