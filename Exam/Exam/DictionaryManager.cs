using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class DictionaryManager
    {
        private List<MyDictionary> dictionaries;

        public DictionaryManager() { }

        public void ShowMenu()
        {
            dictionaries = new List<MyDictionary>();
            ReadFromBynaryFile();

            int menu;

            do
            {
                Console.WriteLine("\n---------МЕНЮ--------\n");
                Console.WriteLine("1. Создать словарь");
                Console.WriteLine("2. Войти в словарь");
                Console.WriteLine("0. Выход [C сохранением словарей в файл]");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите номер меню: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        CreateNewDictionary();
                        break;
                    case 2:
                        Console.Clear();
                        isEmpty();
                        break;
                    case 0:
                        Console.Clear();
                        SaveToBynaryFile();
                        break;
                }
            } while (menu != 0);
        }
        public bool isEmpty()
        {
            if (dictionaries == null)
            {
                Console.WriteLine("Нету словарей");
                return true;
            } else
            {
                ShowDictionaries();
                return false;
            }
        }

        public void ShowDictionaries()
        {
            if (dictionaries == null)
                return;
            else
            {
                for (int i = 0; i < dictionaries.Count; i++)
                {
                    dictionaries[i].ShowName(i + 1);
                }
                Console.WriteLine();
                Console.Write("Введите ID для входа в словарь (0 = Выход): ");
                int index;
                string tmp = Console.ReadLine();
                bool isInt = int.TryParse(tmp, out index);
                if (index == 0)
                {
                    Console.Clear();
                    return;
                }

                if (isInt)
                {
                    if (index >= 0 && index <= dictionaries.Count)
                    {
                        Console.Clear();
                        ShowDictionaryMenu(index);
                    }
                } else Console.WriteLine("Неверный формат!");

            }
        }

        public void CreateNewDictionary()
        {
            Console.WriteLine("*********Создание словаря***********");
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();
            MyDictionary myDictionary = new MyDictionary(name);
            dictionaries.Add(myDictionary);
            Console.Clear();
            Console.WriteLine("Словарь успешно создан!");
        }

        public void ShowDictionaryMenu(int index)
        {
            int currentIndex = index - 1;
            int menu;

            do
            {
                Console.WriteLine($"\n--------- МЕНЮ СЛОВАРЯ -> ({dictionaries[currentIndex].Name}) ---------\n");
                Console.WriteLine("1. Добавить слово и его перевод");
                Console.WriteLine("2. Заменить сово");
                Console.WriteLine("3. Заменить перевод слова");
                Console.WriteLine("4. Удалить слово");
                Console.WriteLine("5. Удалить перевод слова");
                Console.WriteLine("6. Искать перевод");
                Console.WriteLine("7. Экспорт в файл слова и его перевод.");
                Console.WriteLine("8. Вывети словарь на экран");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите номер меню: ");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        AddWordAndTranslate(currentIndex);
                        break;
                    case 2:
                        Console.Clear();
                        EditWord(currentIndex);
                        break;
                    case 3:
                        Console.Clear();
                        EditWordTranslateWord(currentIndex);
                        break;
                    case 4:
                        Console.Clear();
                        DeleteWord(currentIndex);
                        break;
                    case 5:
                        Console.Clear();
                        DeleteWordTranslateWords(currentIndex);
                        break;
                    case 6:
                        Console.Clear();
                        SearchWord(currentIndex);
                        break;
                    case 7:
                        Console.Clear();
                        ExportWordToFile(currentIndex);
                        break;
                    case 8:
                        Console.Clear();
                        ShowCurrentDicrionary(currentIndex);
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }

        public void AddWordAndTranslate(int index)
        {
            Console.WriteLine();
            Console.Write("Введите новое слово: ");
            string key = Console.ReadLine();

            List<string> translations = new List<string>();

            string userInput;
            do
            {
                Console.Write("Введите вариант перевода (для завершения введите 'end'): ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() != "end")
                {
                    translations.Add(userInput);
                }
            } while (userInput.ToLower() != "end");

            Console.Clear();
            dictionaries[index].AddNew(key, translations.ToArray());
            Console.WriteLine("Вы успешно добавили слово и его перевод!");
        }

        public void ShowCurrentDicrionary(int index)
        {
            Console.WriteLine();
            dictionaries[index].Show();
        }

        public void EditWord(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово которогое хотите заменить: ");
            string key = Console.ReadLine();
            Console.Write("Введите слово на которое хотите заменить: ");
            string newKey = Console.ReadLine();
            dictionaries[index].EditKey(key, newKey);
        }

        public void EditWordTranslateWord(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово в котором хотите заменить: ");
            string key = Console.ReadLine();
            Console.Write("Введите слово которое хотите заменить: ");
            string oldValue = Console.ReadLine();
            Console.Write("Введите слово на которое хотите заменить: ");
            string newValue = Console.ReadLine();
            dictionaries[index].EditValueFromKey(key, oldValue, newValue);
        }

        public void DeleteWord(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово которогое хотите удалить: ");
            string key = Console.ReadLine();
            dictionaries[index].Delete(key);
        }

        public void DeleteWordTranslateWords(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово в котором хотите удалить: ");
            string key = Console.ReadLine();

            List<string> translations = new List<string>();

            string userInput;
            do
            {
                Console.Write("Введите слова которые хотите удалить (для завершения введите 'end'): ");
                userInput = Console.ReadLine();
                if (userInput.ToLower() != "end")
                {
                    translations.Add(userInput);
                }
            } while (userInput.ToLower() != "end");

            Console.Clear();
            dictionaries[index].DeleteValues(key, translations.ToArray());
            Console.WriteLine("Вы успешно удалили слова из перевода!");
        }

        public void SearchWord(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово которое хотите найти: ");
            string key = Console.ReadLine();
            Console.WriteLine();
            dictionaries[index].SearchValueByKey(key);
        }

        public void ExportWordToFile(int index)
        {
            Console.WriteLine();
            Console.Write("Введите слово которое хотите экспортировать: ");
            string key = Console.ReadLine();
            string path = $"{key}.txt";
            Console.WriteLine();
            dictionaries[index].WriteToFile(key, path);
        }

        public void SaveToBynaryFile()
        {
            if (dictionaries == null)
                return;

            if (File.Exists("data.txt"))
                File.Delete("data.txt");

            using (FileStream fs = new FileStream("data.txt", FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                bw.Write(dictionaries.Count);

                foreach (var dictionary in dictionaries)
                {
                    dictionary.SaveToBynaryFile(bw);
                }
            }
        }

        public void ReadFromBynaryFile()
        {
            if (!File.Exists("data.txt"))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            dictionaries.Clear();

            try
            {
                using (FileStream fs = new FileStream("data.txt", FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (BinaryReader br = new BinaryReader(bs))
                {
                    int size = br.ReadInt32();
                    dictionaries = new List<MyDictionary>(size);

                    for (int i = 0; i < size; i++)
                    {
                        var dictionary = new MyDictionary();
                        dictionary.ReadFromBynaryFile(br);
                        dictionaries.Add(dictionary);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {e.Message}");
            }
        }



    }

}
