using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            // Ключ-значение - Dictionary (Ключ уникальный, Значение)
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Roman", "0123456789");
            dic.Add("Timur", "0243456789");
            dic.Add("Anna", "0663456789");
            dic.Add("Elena", "0783456789");

            dic["Anna"] = "000000000"; // Изминение знаачения по ключу
            dic["Maryna"] = "11111110101"; // Если такого ключа нету то будет добавдение нового элемента

            // Доступ к значению по ключу
            Console.WriteLine("\nТелефон Anna = " + dic["Anna"] + "\n");

            foreach (KeyValuePair<string, string> item in dic)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }

            // Поиск значения по ключу:
            string keyFind = "Timur";
            if (dic.ContainsKey(keyFind))
            {
                Console.WriteLine($"\nЗначение по ключу: {keyFind} {dic[keyFind]}");
            } else
            {
                Console.WriteLine($"\nКлюч: {keyFind} не найден");
            }

            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>()
            {
                ["Pen"] = 25.56,
                ["Albom"] = 125.5,
                ["Notebook"] = 39.56,
                ["Lastic"] = 20.6,
            };

            Dictionary<string, double> keyValuePairs2 = new Dictionary<string, double>()
            {
                {"Pen", 25.56 },
                {"Albom", 125.5 },
                {"Notebook", 39.56 },
                {"Lastic", 20.6 },
            };

            keyValuePairs2["Lastic"] = 5.45;

            Console.WriteLine();
            PrintDictionary(keyValuePairs2);

            // Поиск значения по ключу: 
            string key = "Lastic";
            if (keyValuePairs2.TryGetValue(key, out double price))
            {
                Console.WriteLine($"\nЗначение по ключу: {key} => {price}");
            }else
            {
                Console.WriteLine($"\nКлюч: {key} не найден");
            }

            Console.WriteLine("\nПолучение коллекции ключей\n");

            // Получение коллекции ключей
            ICollection allKeys = keyValuePairs2.Keys;
            foreach (var item in allKeys)
            {
                Console.WriteLine(item);
            }

            // Получение коллекции ключей
            ArrayList arrayList = new ArrayList(keyValuePairs2.Keys);
            arrayList.Sort();

            Console.WriteLine();

            foreach (string item in arrayList)
            {
                Console.WriteLine($"{item} {keyValuePairs2[item]}");
            }
#endif

#if false
            /*
                Создайте Dictionary<T>, где в качестве ключа будет объект пользовательского класса 
                Person(имя, возраст), а в качестве значения - список стран, где побывал человек.
            */

            Person fitstPerson = new Person("Marks", 6);

            Dictionary<Person, List<string>> travelLog = new Dictionary<Person, List<string>>
            {
                {
                    new Person("Ruslan", 33),
                    new List<string> { "Germany", "Canada", "Romania", "England" }
                },
                {
                    new Person("Maryna", 33),
                    new List<string> { "Italia", "Moldova", "Francia", "Australia" }
                },
                                {
                    fitstPerson,
                    new List<string> { "Italia", "Moldova", "Francia"}
                },
            };

            foreach (KeyValuePair<Person, List<string>> item in travelLog)
            {
                Console.WriteLine($"\n{item.Key} посетил следующие страны: {string.Join(", ", item.Value)}");
            }

            Console.WriteLine();

            if (travelLog.ContainsKey(fitstPerson)) 
            {
                Console.WriteLine($"\nПерсонаж {fitstPerson.Name} найден!\nOн посетил: {string.Join(", ", travelLog[fitstPerson])}");
            }
            else
            {
                Console.WriteLine($"\nКлюч: {fitstPerson} не найден");
            }
#endif

#if false
            //  Частотный словарь ***********************************************
            /*
                Частотный словарь: посчитать количество повторений слов в строке и общее количество слов.
                Мишка по лесу идет, Мишка ищет сладкий мед. Если мишка мед найдет, В гости зайку позовет.
                Прыг-прыг-прыг - что было сил Мячик маленький спешил, А за ним большой бежал, ПРЫГ - и вмиг его догнал.
            */

            string str = "Мишка по лесу идет, Мишка ищет сладкий мед. Если мишка мед найдет, В гости зайку позовет." +
                         "Прыг-прыг-прыг - что было сил Мячик маленький спешил, А за ним большой бежал, ПРЫГ - и вмиг его догнал.";

            string[] words = str.Split(new char[] { ' ', ',', '.', '-', '!', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            
            SortedDictionary<string, int> vocabular = new SortedDictionary<string, int>();
            foreach (string word in words)
            {
                if (vocabular.ContainsKey(word))
                {
                    vocabular[word]++;
                }else
                {
                    vocabular[word] = 1;
                    //vocabular.Add(word, 1);
                }
            }

            Console.WriteLine($"{"Слово", -15} Повторения");
            foreach (KeyValuePair<string, int> pair in vocabular)
            {
                Console.WriteLine($"{pair.Key, -15} {pair.Value}");
            }
#endif

#if false
            /*
             Создайте Dictionary<T>, где в качестве ключа будет объект пользовательского класса 
             Person(имя, возраст), а в качестве значения - список стран, где побывал человек.
            */

            Dictionary<string, List<string>> multimap = new Dictionary<string, List<string>>();

            // Добавление элементов
            AddToMultimap(multimap, "key1", "value1");
            AddToMultimap(multimap, "key2", "value2");
            AddToMultimap(multimap, "key1", "value3");
            AddToMultimap(multimap, "key3", "value4");
            AddToMultimap(multimap, "key1", "value5");

            // Вывод элементов
            foreach (var entry in multimap)
            {
                string key = entry.Key;
                List<string> values = entry.Value;

                Console.WriteLine($"{key}: {string.Join(", ", values)}");
            }

#endif

#if false
            // Итерыторы
            PersonTwo[] people = new PersonTwo[]
            {
                new PersonTwo("Ivanov"),
                new PersonTwo("Petrov"),
                new PersonTwo("Sidorov"),
                new PersonTwo("Sokolov"),
                new PersonTwo("Kotikov"),
                new PersonTwo("Dimov"),
                new PersonTwo("Kolom"),
                new PersonTwo("Kotikov 1"),
                new PersonTwo("Kotikov 2"),

            };

            Company companies = new Company(people);

            foreach (PersonTwo value in companies)
            {
                Console.WriteLine(value.Name);
            }

            Console.WriteLine();

            PrintValues(companies);

            Console.WriteLine();

            foreach (PersonTwo value in companies) //.GetEnumerator(2, 6))
            {
                Console.WriteLine(value.Name);
            }

            Console.WriteLine();

            Numbers numbers = new Numbers(10);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            WorkDays workdays = new WorkDays();

            foreach (var item in workdays)
            {
                Console.WriteLine(item);
            }
#endif

#if false
            Point3D p = new Point3D(125, 6, -125);
            foreach (var item in p)
            {
                Console.Write($"{item} ");
            }

#endif

            Console.ReadLine();
        }
        static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dic)
        {
            foreach (KeyValuePair<TKey, TValue> item in dic)
            {
                Console.WriteLine($"{item.Key, -15}\t{item.Value}");
            }
        }

        public static void PrintValues(IEnumerable collection)
        {
            IEnumerator enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        static void AddToMultimap(Dictionary<string, List<string>> multimap, string key, string value)
        {
            if (!multimap.TryGetValue(key, out List<string> values))
            {
                values = new List<string>();
                multimap[key] = values;
            }
            values.Add(value);
        }
    }
}
