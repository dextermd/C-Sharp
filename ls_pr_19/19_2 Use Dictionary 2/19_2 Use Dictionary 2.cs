using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Создайте Dictionary<T>, где в качестве ключа будет объект пользовательского класса 
 Person(имя, возраст), а в качестве значения - список стран, где побывал человек.
 */

namespace _19_2_Use_Traveler
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            Console.Read();
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
