using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_1_Use_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            //Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("Roman", "012345678");
            dic.Add("Timur", "321654789");
            dic.Add("Anna", "012345678");
            dic.Add("Elena", "032145698");
            //dic.Add("Elena", "032145698");//System.ArgumentException: 'Элемент с тем же ключом уже был добавлен.'

            dic["Elena"] = "9988775544";// изменение значения по ключу
            dic["Maryna"] = "012345678";// добавление нового элемента

            // Доступ к значению по ключу
            Console.WriteLine("Телефон Anna: " + dic["Anna"]);

            foreach (/*var*/KeyValuePair<string,string> item in dic)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }

            // Поиск значения по ключу:ContainsKey
            string keyFind = "Timur";
            if(dic.ContainsKey(keyFind))
            {
                Console.WriteLine($"Значение по ключу: {keyFind} => {dic[keyFind]}");
            }
            else
            {
                Console.WriteLine($"Ключ: { keyFind}  не найден");
            }

            Dictionary<string, double> keyValuePairs = new Dictionary<string, double>()
            {
                ["Pen"] = 25.56,
                ["Albom"] = 125.56,
                ["Notebook"] = 39.78,
                ["Lastic"] = 25.56,
            };

            Dictionary<string, double> keyValuePairs2 = new Dictionary<string, double>()
            {
                {"Pen"     , 25.56 },
                {"Albom"   , 125.56 },
                {"Notebook", 39.78},
                { "Lastic" , 25.56 },
            };

            keyValuePairs2["Lastic"] = 5.45;
            PrintDictionary<string, double>(keyValuePairs2);

            // Поиск значения по ключу: TryGetValue
            string key = "Last";
           if( keyValuePairs2.TryGetValue(key, out double price))
            {
                Console.WriteLine($"Значение по ключу: { key} Цена: {price}");
            }
            else
            {
                Console.WriteLine($"Ключ: { key}  не найден");
            }
            Console.WriteLine("Цена: "+ price);

            // Получение коллекции ключей
            ICollection allKeys= keyValuePairs2.Keys;
            foreach(string item in allKeys)
            {
                Console.WriteLine(item);
            }

            // Получаем коллекцию ключей:
            ArrayList arrayList = new ArrayList(keyValuePairs2.Keys);
            arrayList.Sort();
            foreach(string item in arrayList)
            {
                Console.WriteLine(item + " " + keyValuePairs2[item]);
            }

            

            Console.Read();
        }
        static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dic)
        {
            Console.WriteLine();
            foreach (/*var*/KeyValuePair<TKey, TValue> item in dic)
            {
                Console.WriteLine($"{item.Key, -15}{item.Value}");
            }
        }
    }
}
