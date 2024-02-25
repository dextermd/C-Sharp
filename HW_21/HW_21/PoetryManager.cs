using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_21
{
    internal class PoetryManager : IEnumerable<Poem>
    {
        List<Poem> Poems { get; set; }

        public PoetryManager()
        {
            Poems = new List<Poem>();
        }

        public PoetryManager(List<Poem> poems)
        {
            this.Poems = poems;
        }

        public IEnumerator<Poem> GetEnumerator()
        {
            for (int i = 0; i < Poems.Count; i++)
            {
                yield return Poems[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Poems.GetEnumerator();
        }

        public void ShowMenu()
        {
            int menu;
            string name;
            
            do
            {
                Console.WriteLine("\n---------МЕНЮ--------\n");
                Console.WriteLine("1. Показать стихи");
                Console.WriteLine("2. Добавить стихи");
                Console.WriteLine("3. Удалить стихи");
                Console.WriteLine("4. Изменять информацию о стихах");
                Console.WriteLine("5. Искать стих по разным характеристикам");
                Console.WriteLine("6. Сохранять коллекцию стихов в файл");
                Console.WriteLine("7. Загружать коллекцию стихов из файла");
                Console.WriteLine("8. Сериализация");
                Console.WriteLine("9. Десириализация");
                Console.WriteLine("10. Отчеты");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите номер меню: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Show(Poems);
                        break;
                    case 2:
                        Console.Clear();
                        Poem poem = new Poem();
                        poem.Add();
                        Poems.Add(poem);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Show(Poems);
                        Console.Write("Введите название стих: ");
                        name = Console.ReadLine();
                        Delete(name);
                        break;
                    case 4:
                        Console.Clear();
                        Show(Poems);
                        Console.Write("Введите название стих: ");
                        name = Console.ReadLine();
                        Edit(name);
                        break;
                    case 5:
                        Console.Clear();
                        ShowSearchMenu();
                        break;
                    case 6:
                        Console.Clear();
                        ShowSaveMenu();
                        break;
                    case 7:
                        Console.Clear();
                        ShowReadFileMenu();
                        break;
                    case 8:
                        Console.Clear();
                        Serialization();
                        break;
                    case 9:
                        Console.Clear();
                        DeSerialization();
                        break;
                    case 10:
                        Console.Clear();
                        SearchMenu();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }
        
        public void Show(List<Poem> poems)
        {
            foreach (var item in poems)
            {
                Console.WriteLine(item);
            }
        }

        public void Delete(string name)
        {
            if (!Poems.Exists(x => x.Title == name))
            {
                Console.Clear();
                Console.WriteLine("\nНету стиха с таким названием\n");
            }
            else
            {
                Console.Clear();
                Poems.RemoveAll(x => x.Title == name);
                Console.WriteLine("\nСтих Удален\n");
            }
        }

        public void SaveToFile()
        {
            if (File.Exists("data.txt"))
                File.Delete("data.txt");

            using (FileStream fs = new FileStream("data.txt", FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                sw.WriteLine(Poems.Count);

                foreach (var poem in Poems)
                {
                    sw.WriteLine(poem.Title);
                    sw.WriteLine(poem.Author);
                    sw.WriteLine(poem.Year);
                    sw.WriteLine(poem.Text);
                    sw.WriteLine(poem.Theme);
                }
                Console.WriteLine("Данные записаны в двоичный файл");
            }

        }

        public void ReadFromFile()
        {
            if (!File.Exists("data.txt"))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            Poems.Clear();

            try
            {
                using (FileStream fs = new FileStream("data.txt", FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    int count = int.Parse(sr.ReadLine());
                    Poems = new List<Poem>(count);

                    for (int i = 0; i < count; i++)
                    {
                        Poem poem = new Poem();
                        poem.Title = sr.ReadLine();
                        poem.Author = sr.ReadLine();
                        poem.Year = int.Parse(sr.ReadLine());
                        poem.Text = sr.ReadLine();
                        poem.Theme = sr.ReadLine();

                        Poems.Add(poem);
                    }
                }
                Console.WriteLine("Данные успешно загружены из файла.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {e.Message}");
            }
        }

        public void SaveToBynaryFile()
        {
            if (File.Exists("dataBinary.txt"))
                File.Delete("dataBinary.txt");

            using (FileStream fs = new FileStream("dataBinary.txt", FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                bw.Write(Poems.Count);

                foreach (var poem in Poems)
                {
                    bw.Write(poem.Title);
                    bw.Write(poem.Author);
                    bw.Write(poem.Year);
                    bw.Write(poem.Text);
                    bw.Write(poem.Theme);

                }
                Console.WriteLine("Данные записаны в двоичный файл");
            }
        }

        public void ReadFromBynaryFile()
        {
            if (!File.Exists("dataBinary.txt"))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            Poems.Clear();

            try
            {
                using (FileStream fs = new FileStream("dataBinary.txt", FileMode.Open))
                using (BufferedStream bs = new BufferedStream(fs))
                using (BinaryReader br = new BinaryReader(bs))
                {
                    int size = br.ReadInt32();
                    Poems = new List<Poem>(size);

                    for (int i = 0; i < size; i++)
                    {
                        string title = br.ReadString();
                        string author = br.ReadString();
                        int year = br.ReadInt32();
                        string text = br.ReadString();
                        string theme = br.ReadString();
                        Poem poem = new Poem(title, author, year, text, theme);

                        Poems.Add(poem);
                    }
                    Console.WriteLine("Данные  загружены из файла");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при загрузке данных из файла: {e.Message}");
            }

        }

        public void Edit(string editName)
        {
            if (!Poems.Exists(x => x.Title == editName))
            {
                Console.Clear();
                Console.WriteLine("\nНету стиха с таким названием\n");
            }
            else
            {
                Console.Clear();
                Poems.Find(x => x.Title == editName).Edit();
                Console.WriteLine("\nСтих Изменен\n");
            }
        }

        public void ShowSearchMenu()
        {
            int menu, year;
            List<Poem> listTmp = new List<Poem>();
            string strTmp;
            do
            {
                Console.WriteLine("\n---------Поиск--------\n");
                Console.WriteLine("1. Поиск по названию");
                Console.WriteLine("2. Поиск по году");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n---------Поиск по названию--------");
                        Console.WriteLine("------------------------------------\n");
                        Console.Write($"Введите: ");
                        strTmp = Console.ReadLine();
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Title.Equals(strTmp))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n---------Поиск по году--------");
                        Console.WriteLine("--------------------------------\n");
                        Console.Write($"Введите год: ");
                        year = int.Parse(Console.ReadLine());
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Year.Equals(year))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }

        public void ShowSaveMenu()
        {
            int menu;
            do
            {
                Console.WriteLine("\n---------Cохранить--------\n");
                Console.WriteLine("1. Текстовый");
                Console.WriteLine("2. Двоичный");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        SaveToFile();
                        break;
                    case 2:
                        Console.Clear();
                        SaveToBynaryFile();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }

        public void ShowReadFileMenu()
        {
            int menu;

            do
            {
                Console.WriteLine("\n---------Загружать--------\n");
                Console.WriteLine("1. Текстовый");
                Console.WriteLine("2. Двоичный");
                Console.WriteLine("0. Выход");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Введите: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        ReadFromFile();
                        break;
                    case 2:
                        Console.Clear();
                        ReadFromBynaryFile();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }

        public async void Serialization()
        {
            using (FileStream fs = new FileStream("poem.json", FileMode.Create))
            {
                
                await JsonSerializer.SerializeAsync(fs, Poems);

                Console.WriteLine("Данные записаны");
            }
        }

        public async void DeSerialization()
        {
            Poems.Clear();
            using (FileStream fs = new FileStream("poem.json", FileMode.Open))
            {
                Poems = await JsonSerializer.DeserializeAsync<List<Poem>>(fs);
            }
        }


        public void SearchMenu()
        {
            int menu;
            List<Poem> listTmp = new List<Poem>();
            string tmp;
            int year, len;
            do
            {
                Console.WriteLine("\n---------Отчёты--------\n");
                Console.WriteLine("1. Отчёт по Названию");
                Console.WriteLine("2. Отчёт по Автору");
                Console.WriteLine("3. Отчёт по Году");
                Console.WriteLine("4. Отчёт по Тексту");
                Console.WriteLine("5. Отчёт по длине стиха ");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Input: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n---------Отчёт по Названию--------");
                        Console.WriteLine("Введите название для поиска");
                        Console.WriteLine("-----------------------------------\n");
                        Console.Write($"Введите: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Title.Equals(tmp))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n---------Отчёт по Автору--------");
                        Console.WriteLine("Введите автора для поиска");
                        Console.WriteLine("-----------------------------------\n");
                        Console.Write($"Введите: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Author.Equals(tmp))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n---------Отчёт по Году--------");
                        Console.WriteLine("Введите год для поиска");
                        Console.WriteLine("---------------------------------\n");
                        Console.Write($"Введите: ");
                        year = int.Parse(Console.ReadLine());
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Year.Equals(year))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n---------Отчёт по Тексту--------");
                        Console.WriteLine("Введите текст для поиска");
                        Console.WriteLine("--------------------------------\n");
                        Console.Write($"Введите: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Text.Equals(tmp))
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("\n---------Отчёт по длине стиха--------");
                        Console.WriteLine("Введите длину для поиска");
                        Console.WriteLine("--------------------------------\n");
                        Console.Write($"Введите: ");
                        len = int.Parse(Console.ReadLine());
                        for (int i = 0; i < Poems.Count; i++)
                        {
                            if (Poems[i].Text.Length == len)
                            {
                                listTmp.Add(Poems[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }
    }
}
