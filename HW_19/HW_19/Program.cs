using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class Program
    {
        static void Main(string[] args)
        {


#if false
            //  Опишите словарь, который в качестве ключа использует объект пользовательского класса
            //  “Человек“ (имя, возраст), а в качестве значения -список стран, где побывал человек с указанием года
            //  для каждой страны.Проинициализируйте словарь данными и выведите на экран.

            Dictionary<Person, Dictionary<string, List<int>>> keyValues = new Dictionary<Person, Dictionary<string, List<int>>>
            {
                {
                    new Person("Ruslan", 33),
                    new Dictionary<string, List<int>>
                    {
                        {"England", new List<int> {2005, 2010, 2015} },
                        {"Canada", new List<int> {2005, 2010, 2015} },
                        {"Germany",new List<int> {2005, 2010, 2015} },
                    }
                },
                {
                    new Person("Lita", 28),
                    new Dictionary<string, List<int>>
                    {
                        {"Russia", new List<int> {2006, 2010, 2015} },
                        {"Moldova", new List<int> {2005, 2010, 2015} },
                        {"Germany",new List<int> {2005, 2010, 2015} },
                    }
                },
                {
                    new Person("Vladimir", 31),
                    new Dictionary<string, List<int>>
                    {
                        {"Japan", new List<int> { 2013, 2010, 2015} },
                        {"China", new List<int> { 2010, 2011, 2015} },
                        {"Vietnam",new List<int> { 2000, 2011, 2015} },

                    }
                }
            };

            foreach (KeyValuePair<Person, Dictionary<string, List<int>>> item in keyValues)
            {
                Console.Write($"{item.Key} ");
                Console.Write($"был в: ");
                foreach (var item1 in item.Value)
                {
                    Console.Write($"[{item1.Key} год - {string.Join(", ", item1.Value)}], ");
                }
                Console.WriteLine();
            }
#endif

#if false
            //  Задание 2: Создайте приложение для менеджмента сотрудников и паролей.Необходимо хранить
            //  следующую информацию:
            //      − Логины сотрудников
            //      − Пароли сотрудников
            //  Для хранения информации используйте Dictionary<Т>.
            //  Приложение должно предоставлять такую функциональность:
            //      − Добавление логина и пароля сотрудника
            //      − Удаление логина сотрудника
            //      − Изменение информации о логине и пароле сотрудника
            //      − Получение информации о пароле по логину сотрудника

            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.AddEmployee("username1", "password1");
            employeeManagement.AddEmployee("username2", "password2");
            employeeManagement.AddEmployee("username3", "password3");
            employeeManagement.AddEmployee("username4", "password4");
            employeeManagement.AddEmployee("username5", "password5");

            employeeManagement.Show();

            Console.WriteLine();
            employeeManagement.RemoveEmployee("username3");
            employeeManagement.Show();

            Console.WriteLine();
            employeeManagement.EditEmployee("username1", "username1 Edited", "password1 Edited");
            employeeManagement.Show();

            Console.WriteLine();

            employeeManagement.GetEmployee("username3");

            Console.WriteLine();

            employeeManagement.GetEmployee("username2");

#endif

#if false
            //  Задание 3: Создайте приложение “Англо - французский словарь“. Необходимо хранить следующую
            //  информацию:
            //      + Слово на английском языке
            //      + Варианты перевода на французский
            //  Для хранения информации используйте Dictionary<Т>.
            //  Приложение должно предоставлять такую функциональность:
            //      + Добавление слова и вариантов перевода
            //      + Удаление слова
            //      + Удаление варианта перевода
            //      + Изменение слова
            //      + Изменение варианта перевода
            //      + Поиск перевода слова

            EnglishFrenchDictionary dictionary = new EnglishFrenchDictionary();
            dictionary.Show();

            dictionary.AddNew("bike", "velo", "le velo", "la moto", "la becane");
            dictionary.AddNew("help", "aide", "servir", "renforcer");
            dictionary.AddNew("drive");
            dictionary.AddNew("color", "la couleur", "les coloris", "le teint");
            dictionary.AddNew("fat");
            dictionary.Show();

            Console.WriteLine("\n------------------Delete-------------------------\n");

            dictionary.Delete("help");
            dictionary.Show();

            Console.WriteLine("\n------------------DeleteValue-------------------------\n");

            dictionary.DeleteValue("bike", "la becane", "velo");
            dictionary.Show();

            Console.WriteLine("\n------------------DeleteValue-------------------------\n");

            dictionary.DeleteValue("help", "aide");

            Console.WriteLine("\n------------------EditKey-------------------------\n");

            dictionary.EditKey("color", "colorEdited");
            dictionary.Show();

            Console.WriteLine("\n------------------EditValueFromKey-------------------------\n");

            dictionary.EditValueFromKey("colorEdited", "le teint", "le teint Edited");
            dictionary.Show();

            Console.WriteLine("\n------------------SearchValueByKey-------------------------\n");

            dictionary.SearchValueByKey("colorEdited");
#endif

#if false
            //  Задание 4: Создайте класс “Океанариум“. Он должен содержать информацию о жителях Океанариума.
            //  Создайте классы для каждого жителя Океанариума. Они должны содержать информацию о конкретном
            //  морском существе. Реализуйте поддержку итератора для класса Океанариум. Протестируйте
            //  возможность использования foreach для Океанариума.

            Dolphin dolphin1 = new Dolphin
            {
                Name = "Dolly",
                Age = 8,
                Gender = "Female"
            };

            Dolphin dolphin2 = new Dolphin
            {
                Name = "Flipper",
                Age = 12,
                Gender = "Male"
            };

            Dolphin dolphin3 = new Dolphin
            {
                Name = "Splash",
                Age = 6,
                Gender = "Female"
            };

            SeaTurtle turtle1 = new SeaTurtle
            {
                Name = "Shelly",
                Age = 25,
                Habitat = "Coral reef"
            };

            SeaTurtle turtle2 = new SeaTurtle
            {
                Name = "Terry",
                Age = 30,
                Habitat = "Seagrass bed"
            };

            SeaTurtle turtle3 = new SeaTurtle
            {
                Name = "Squirt",
                Age = 15,
                Habitat = "Mangrove swamp"
            };

            Dolphin[] dolphins = new Dolphin[] { dolphin1, dolphin2, dolphin3 };
            SeaTurtle[] seaTurtle = new SeaTurtle[] { turtle1, turtle2, turtle3 };

            Oceanarium oceanarium = new Oceanarium(dolphins, seaTurtle);

            foreach (var value in oceanarium)
            {
                Console.WriteLine(value);
            }


#endif

#if false
            //  Задание 5: Опишите класс “Простые числа” с двумя полями min и max типа long.Реализуйте для класса
            //  конструкторы и итератор, который должен проходить только по простым числам в диапазоне от min до
            //  max.Продемонстрируйте работу итератора, используя конструкцию foreach.

            long min = 1;
            long max = 100;

            PrimeNumbers primes = new PrimeNumbers(min, max);

            Console.WriteLine($"Простые числа между {min} и {max}:");
            foreach (long prime in primes)
            {
                Console.Write($"{prime} ");
            }

#endif

            Console.Read();
        }
    }
}
