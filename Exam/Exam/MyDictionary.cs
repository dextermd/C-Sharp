using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class MyDictionary
    {
        public string Name { get; set; }
        private Dictionary<string, List<string>> data;

        public MyDictionary() 
        {
            data = new Dictionary<string, List<string>>();
        }
        public MyDictionary(string name)
        {
            Name = name;
            data = new Dictionary<string, List<string>>();
        }

        public void AddNew(string key, params string[] values)
        {
            List<string> list = new List<string>();

            foreach (var item in values)
                list.Add(item);

            data[key] = list;
        }

        public void ShowName(int index)
        {
            if (data == null)
                return;

            Console.WriteLine($"ID: {index}, Name: {Name}");
        }

        public void Show()
        {
            if (data == null)
                return;

            foreach (KeyValuePair<string, List<string>> item in data)
                Console.WriteLine($"{item.Key,-15} - [{string.Join(",", item.Value)}]");
        }

        public void Delete(string key)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Ключ {key} отсутствует в словаре.");
            else data.Remove(key);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Слово {key} успешно удалено");
        }

        public void DeleteValues(string key, params string[] values)
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
                Console.WriteLine($"Слово {key} отсутствует в словаре.");
            else
            {
                List<string> tmpList = new List<string>(data[key]);
                data.Remove(key);
                data[newKey] = tmpList;
            }
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Слово {key} успешно изменен на {newKey}");
        }

        public void EditValueFromKey(string key, string oldValue, string newValue)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Слово {key} отсутствует в словаре.");
            else
            {
                data[key].Remove(oldValue);
                data[key].Add(newValue);
            }
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Слово {oldValue} успешно изменен на {newValue}");
        }

        public void SearchValueByKey(string key)
        {
            if (!data.ContainsKey(key))
                Console.WriteLine($"Слово {key} отсутствует в словаре.");
            else Console.Write($"{key,-15} - [{string.Join(", ", data[key])}]");
        }

        public void WriteToFile(string key, string path, bool append = false)
        {
            string saveData = "";
            if (!data.ContainsKey(key))
                Console.WriteLine($"Слово {key} отсутствует в словаре.");
            else
            {
                saveData = $"{key,-15} - [{string.Join(", ", data[key])}]";
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine(saveData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToBynaryFile(BinaryWriter bw)
        {
            bw.Write(Name);

            bw.Write(data.Count);

            foreach (var pair in data)
            {
                bw.Write(pair.Key);

                bw.Write(pair.Value.Count);

                foreach (string translation in pair.Value)
                {
                    bw.Write(translation);
                }
            }

            Console.WriteLine("Данные успешно записаны в двоичный файл");
            
        }

        public void ReadFromBynaryFile(BinaryReader br)
        {
            data.Clear();

            Name = br.ReadString();

            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                string key = br.ReadString();

                int translationsCount = br.ReadInt32();

                List<string> translations = new List<string>();

                for (int j = 0; j < translationsCount; j++)
                {
                    string translation = br.ReadString();
                    translations.Add(translation);
                }

                data.Add(key, translations);
            }

            Console.WriteLine("Данные успешно загружены из двоичного файла");
            
        }

    }
}

