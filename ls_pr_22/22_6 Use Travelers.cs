
using _My_Person;

namespace Use_Travelers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             Для словаря путешественников сделать запросы на:
                - список всех стран из словаря
                - список имен всех людей из словаря(имена)
                - список всех людей(Person) из словаря
                - на список всех путешественников в виде: страна – имя Person
                (анонимный объект)
             */

            Person firstPerson = new Person("Маркс", 6);
            Console.WriteLine(firstPerson);

            Dictionary<Person, List<string>> travelLog = new Dictionary<Person, List<string>>
            {
                {
                    new Person("Юра", 34),
                    new List<string> {"Италия", "Молдова", "Франция"}
                },
                {
                    new Person("Марина", 30),
                    new List<string> {"Италия", "Молдова", "Франция", "Австралия"}

                },
                {
                    firstPerson,
                    new List<string> {"Италия", "Молдова", "Франция"}
                }
            };
            Console.WriteLine($"Количество элементов: {travelLog.Count}");

            foreach (KeyValuePair<Person, List<string>> myDictionary in travelLog)
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine($"{myDictionary.Key} \nПосетил следующие страны: {string.Join(", ", myDictionary.Value)}");
            }
            //---------------------------------------------------------------
            // 1. список всех стран из словаря

            var allCountries = (from travel in travelLog
                                from country in travel.Value
                                select country).Distinct();


            var allCountries2 = travelLog.SelectMany(myDictionary => myDictionary.Value).Distinct();

            Console.WriteLine("\nСписок всех стран: \n");
            foreach (var country in allCountries)
            {
                Console.WriteLine(country);
            }
            Console.WriteLine("--------------------------------");
            //---------------------------------------------------------------
            //2. список имен всех путешественников из словаря(имена)

            var allNames = from travel in travelLog.Keys
                           select travel.Name;

            var allNames2 = travelLog.Keys
                .Select(p => p.Name)
                .OrderBy(p => p);

            Console.WriteLine("\nСписок всех путешественников: \n");
            foreach (var name in allNames2)
            {
                Console.WriteLine(name);// string
            }

            //---------------------------------------------------------------
            //3. список всех людей(Person) из словаря

            var allTravels = travelLog.Keys
                .SelectMany(p => new List<Person> { p })
                .OrderBy(p => p.Name);


            Console.WriteLine("\nСписок всех путешественников(): \n");
            foreach (var person in allTravels)
            {
                Console.WriteLine(person);// Person
            }
            Console.WriteLine();
            //----------------------------------------------------
            //4.  - на список всех путешественников в виде: страна – имя Person
            //      (анонимный объект)

            var query = from travel in travelLog
                        from country in travel.Value
                        orderby country
                        select new
                        {
                            Country = country,
                            Pers = travel.Key
                        };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Country,-20}{item.Pers.Name,-20} ");
            }
            Console.WriteLine("---------------------------------------");


            //----------------------------------------------------
            // Группировка путешественников по странам

            var queryGroup = from travel in travelLog
                             from country in travel.Value
                             group travel.Key by country into countryGroup
                             orderby countryGroup.Key
                             select new
                             {
                                 Country = countryGroup.Key,
                                 Travelers = countryGroup.ToList()
                             };

            foreach(var group  in queryGroup)
            {
                Console.WriteLine( $"Страна: {group.Country}");
                foreach (var person in group.Travelers)
                {
                    Console.WriteLine($"  {person.Name}");
                }
                Console.WriteLine();
            }




            Console.Read();
        }
    }
}