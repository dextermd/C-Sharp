namespace _22_2_Use_Account
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Задача 8: Сформировать запрос на получение сведений о банковских счетах 
                    в отсортированном порядке. 
                Отсортировать эти сведения сначала по фамилии, затем по имени и, 
                    наконец, по остатку на счете(по убыванию).
             */

            Account[] accounts =
                      {   new Account("Sokolov", "Dmitrii", "335", 100.23),
                new Account("Sokolov", "Alex", "132", 10000.00),
                new Account("Borisova", "Elena", "436", 923.85),
                new Account("Borisova", "Elena", "454", 987.132),
                new Account("Semenov", "Semen", "897", 3223.19),
                new Account("Borisova", "Anna", "434", 10123.32),
                new Account("Petrov", "Petea", "543", 5017.40),
                new Account("Petrov", "Petea", "547", 34955.79),
                new Account("Petrov", "Petea", "843", 345.00),
                new Account("Alexeev", "Timur", "445", 213.67),
                new Account("Dmitrieva", "Kate","968",5146.67),
                new Account("Dmitrieva", "Kate", "078", 15345.99),
                new Account("Sokolov", "Dmitrii", "135", 900.10),
                };

            var query = from account in accounts
                        orderby account.LastName, account.FirstName, account.Balance descending
                        select account;

            string s = "";
            foreach (var item in query)
            {
                if(s != item.LastName)
                {
                    Console.WriteLine();
                    s = item.LastName;
                }
                Console.WriteLine($"{item.LastName}  {item.FirstName} - {item.Balance}");
            }

            Console.WriteLine("\n------------------------------------------");

            var query2 = accounts
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .ThenByDescending(a => a.Balance);

            s = "";
            foreach (var item in query)
            {
                if (s != item.LastName)
                {
                    Console.WriteLine();
                    s = item.LastName;
                }
                Console.WriteLine($"{item.LastName}  {item.FirstName} - {item.Balance}");
            }

            Console.Read();
        }
    }
    record Account(string LastName, string FirstName, string AccountNumber, double Balance);
}