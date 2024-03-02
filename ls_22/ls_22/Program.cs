using _My_Person;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace ls_22
{
    record class ContactInfo(string Name, string Email, string Phone);
    record class EmailAddress(string Name, string Address);
    record class Company(string Name, List<Person> Staff);

    class Program
    {
        static void Main(string[] args)
        {

#if false

// Сформировать запрос на получение квадратных корней всех положительных значений, содержащихся в массиве

int[] arr = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };
IEnumerable<double> query = from n in arr where n > 0 select Math.Sqrt(n);

foreach (var item in query)
{
    Console.WriteLine(item);
}

#endif

#if false

/*
Анонимный тип как результат запроса - в результате запроса получить имя и возраст объектов
*/

var list = new List<Person>
    {

        new Person("Marks", 6),

        new Person("Skittles", 3),

        new Person("Alex", 25),

        new Person("Tom", 26),

        new Person("Bob", 25),

};

var names = from n in list select n.Name; // string

foreach (string item in names)
{
    Console.WriteLine(item);
}

Console.WriteLine("\n---------------------------------------\n");

// Анонимный тип как результат запроса - в результате запроса получить имя и возраст обьектов

var queryAnonim = from p in list
            select new
            {
                FullName = p.Name,
                Age = p.Age,
            };

foreach (var item in queryAnonim)
{
    Console.WriteLine($"{item.FullName} -  {item.Age}");
}

Console.WriteLine("\n---------------------------------------\n");

// Переменные в запросах и оператор let
// Подсчет года рождения по возрасту(имя, год рождения)

var queryAnonim2 = from p in list
                   let year = DateTime.Now.Year - p.Age // Локальная переменная в запросе
                   select new
                   {
                       FullName = p.Name,
                       year = year,
                   };

foreach (var item in queryAnonim2)
{
    Console.WriteLine($"{item.FullName} -  {item.year}");
}

Console.WriteLine("\n---------------------------------------\n");

var queryAnonim3 = list.Select(p => new
{
    Fullname = p.Name,
    Year = DateTime.Now.Year - p.Age,
});

foreach (var item in queryAnonim3)
{
    Console.WriteLine($"{item.Fullname} -  {item.Year}");
}

#endif

#if false

// Сформировать запрос на получение списка объектов типа EmailAddress из массива объектов ContactInfo.

EmailAddress[] addrs = {
    new EmailAddress("Alex", "alex@gmail.com"),
    new EmailAddress("Anton", "anton@mail.ru"),
    new EmailAddress("Elena", "elena@outlook.com")
};
-

ContactInfo[] contacts = {
    new ContactInfo("Alex", "alex@gmail.com", "069789654"),
    new ContactInfo("Anton", "anton@mail.ru", "079321456"),
    new ContactInfo("Elena", "elena@outlook.com", "060123456")
}

var emailList = from contact in contacts
                select new(contact.Namem contact.Email);

foreach (var item in emailList)
{
    Console.WriteLine($"{item.Name} - {item.Address}");
}



#endif

#if false
            /*
                Есть список объектов (название компании, список сотрудников). Написать запросы:
                    - получить список всех сотрудников
                    - получить список сотрудника и компании(анонимный объект)

            */
            var companies = new List<Company>
              {
                  new Company("Microsoft",
            new List<Person> {new Person("Tom"), new Person("Bob")}),
                  new Company("Google",
            new List<Person> {new Person("Sam"), new Person("Mike")}),
              };

            // 1. Получить список всех сотрудников
            var list = from company in companies
                       from empl in company.Staff
                       select empl;

            // или 

            Console.WriteLine("Список всех сотрудников:");

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name}");
            }

            Console.WriteLine("\n-------------------------------\n");

            // 2.  получить список сотридника и компании(анонимный обьект)

            var listAnonim = from company in companies
                             from empl in company.Staff
                             select new
                             {
                                 Name = empl.Name,
                                 EmplCompany = company.Name
                             };

            // или

            var listAnonim2 = companies.SelectMany(x => x.Staff, (c, empl) => new
            {
                Name = empl.Name,
                EmplCompany = c.Name
            });

            Console.WriteLine("Сотрудник - название компании:");

            foreach (var item in listAnonim2)
            {
                Console.WriteLine($"{item.Name} - {item.EmplCompany}");
            }
#endif

#if true
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

            var allCountries2 = travelLog.SelectMany(x => x.Value).Distinct();

            Console.WriteLine("\nСписок всех стран:");
            foreach (var item in allCountries2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n--------------------------------\n");

            //---------------------------------------------------------------
            // 2. список имен всех людей из словаря(имена)

            var allNames = from travel in travelLog.Keys
                            select travel.Name;

            var allNames2 = travelLog.Keys.Select(x => x.Name).Distinct();

            Console.WriteLine("\nСписок имен:");
            foreach (var item in allNames2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n--------------------------------\n");

            //---------------------------------------------------------------
            // 3. список всех людей(Person) из словаря

            var all2 = travelLog.Keys
                .SelectMany(p => new List<Person> { p })
                .OrderBy(p => p.Name);

            Console.WriteLine("\nСписок :");
            foreach (var item in all2)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n--------------------------------\n");

            //---------------------------------------------------------------
            // - на список всех путешественников в виде: страна – имя Person (анонимный объект)

            var al = from travel in travelLog
                     from country in travel.Value
                     orderby country
                     select new
                     {
                         Country = country,
                         PPerson = travel.Key
                     };
            

            Console.WriteLine("\nСписок страна – имя :");
            foreach (var item in al)
            {
                Console.WriteLine($"{item.Country, -20}{item.PPerson.Name}");
            }

            Console.WriteLine("\n--------------------------------\n");

            //---------------------------------------------------------------
            // Групировка путешествиников по странам

            var queryGroup = from travel in travelLog
                             from country in travel.Value
                             group travel.Key by country into countryGroup
                             orderby countryGroup.Key
                             select new
                             {
                                 Country = countryGroup.Key,
                                 Travelers = countryGroup.ToList(),
                             };

            Console.WriteLine("\nСписок страна – имя (Group):");
            foreach (var group in queryGroup)
            {
                Console.Write($"Страна: {group.Country}  - ");
                foreach (var person in group.Travelers)
                {
                    Console.Write($"{person.Name}, ");
                }
                Console.WriteLine();
            }

#endif

        }
    }


}