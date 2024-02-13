using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class EnglishFrenchDictionary
    {
        private Dictionary<string, List<string>> data;
        public EnglishFrenchDictionary() => data = new Dictionary<string, List<string>>();

        public void AddNew(string key, params string[] values) 
        {
            List<string> list = new List<string>();

            foreach (var item in values)
                list.Add(item);
            
            data[key] = list;
        }

        public void Show()
        {
            if (data == null)
                return;

            foreach (KeyValuePair<string, List<string>> item in data)
                Console.WriteLine($"{item.Key, -15} - [{string.Join(",", item.Value)}]");
        }

        public void Delete(string key)
        {
            if (!data.ContainsKey(key)) 
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else data.Remove(key);
        }

        public void DeleteValue(string key, params string[] values)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else
            {
                foreach (var item in values)
                    data[key].RemoveAll(x => x.Equals(item));
            }
        }

        public void EditKey(string key, string newKey)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else
            {
                List<string> tmpList = new List<string>(data[key]);
                data.Remove(key);
                data[newKey] = tmpList;
            }
        }

        public void EditValueFromKey(string key, string oldValue, string newValue)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else
            {
                data[key].Remove(oldValue);
                data[key].Add(newValue);
            }
        }

        public void SearchValueByKey(string key)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else Console.Write($"{key, -15} - [{string.Join(", ", data[key])}]");
        }
    }
}
