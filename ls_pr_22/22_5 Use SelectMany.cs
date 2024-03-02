namespace _22_5_Use_SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             Есть список объектов (название компании, список сотрудников). 
            Написать запросы:
                - получить список всех сотрудников
                - получить список сотрудника и компании(анонимный объект)
             */

            var companies = new List<Company>
              {
                    new Company("Microsoft", new List<Person> {new Person("Tom"), new Person("Bob")}),
                    new Company("Google", new List<Person> {new Person("Sam"), new Person("Mike")}),
              };

            //1. получить список всех сотрудников

            var listAll = from company in companies
                          from empl in company.Staff
                          select empl;

            // или

            var listAll2 = companies.SelectMany(c => c.Staff);

            Console.WriteLine("Список всех сотрудников:\n");
            foreach (var empl in listAll2)
            {
                Console.WriteLine($"{empl.Name}");
            }
            Console.WriteLine("-------------------------------");

            //2. получить список сотрудника и компании(анонимный объект)

            var listAnonim = from company in companies
                             from empl in company.Staff
                             select new
                             {
                                 Name = empl.Name,
                                 EmplCompany = company.Name
                             };

            Console.WriteLine("\nСотрудник - названии компании\n");
            foreach (var item in listAnonim)
            {
                Console.WriteLine($"{item.Name} - {item.EmplCompany}");
            }

            var listAnonim2 = companies.SelectMany(c => c.Staff,
                (c, empl) => new
                {
                    Name = empl.Name,
                    EmplCompany = c.Name
                });

            Console.WriteLine("\nСотрудник - названии компании\n");
            foreach (var item in listAnonim)
            {
                Console.WriteLine($"{item.Name} - {item.EmplCompany}");
            }

            Console.Read();
        }
    }
    record class Company(string Name, List<Person> Staff);
    record class Person(string Name);
}