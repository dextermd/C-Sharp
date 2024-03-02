namespace _23_3_HomeAppliances_Соединение
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
            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")
            };


            // Соединение по компании
            var empls = from p in people
                        join comp in companies
                        on p.Company equals comp.Title
                        select new
                        {
                            Name = p.Name,
                            Company = comp.Title
                        };

            // или 
            var empls2 = people.Join(companies,
                p => p.Company,// свойство-селектор первого набора
                comp => comp.Title,// свойство-селектор второго набора
                (p, comp) => new
                {
                    Name = p.Name,
                    Company = comp.Title
                });


            foreach (var emp in empls2)
            {
                Console.WriteLine($"{emp.Name} - {emp.Company}");
            }


            Console.Read();
        }
    }
    record class Person(string Name, string Company);
    record class Company(string Title, string Language);
}