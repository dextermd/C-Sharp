using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_1_Use_Traveler_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            foreach (KeyValuePair<Person, List<string>> myDictionary in travelLog)
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine($"{myDictionary.Key} \nПосетил следующий страны: {string.Join(", ", myDictionary.Value)}");
            }

            Person secondPerson = new Person("Маркс", 28);

            if (travelLog.ContainsKey(secondPerson))
            {
                Console.WriteLine($"Персонаж {firstPerson.Name} найден!\nОн посетил страны: {string.Join(", ", travelLog[firstPerson])}");
            }
            else
            {
                Console.WriteLine("Персонаж не найден!");
            }



            Console.ReadLine();
        }
    }
}
