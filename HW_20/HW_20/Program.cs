using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_20
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            /*
                Задание 1: Приложение генерирует 100 целых чисел. Нужно сохранить в один файл все четные числа,
                в другой все нечетные числа. Статистику работы приложения надо вывести на экран и сохранить в
                отдельный файл.
            */

            FileManager fileManager = new FileManager();

            string fileEven = "even.txt", fileOdd = "odd.txt", fileLog = "EvenOddLogs.txt";

            if (fileManager.IsFileExist(fileEven))
                fileManager.DeleteFile(fileEven);

            if (fileManager.IsFileExist(fileEven))
                fileManager.DeleteFile(fileOdd);

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    fileManager.WriteToFile(fileEven, i.ToString(), true);
                    string message = $"Add {i} to {fileEven}";
                    fileManager.Show(message);
                    fileManager.WriteLogToFile(fileLog, message);

                }else
                {
                    fileManager.WriteToFile(fileOdd, i.ToString(), true);
                    string message = $"Add {i} to {fileOdd}";
                    fileManager.Show(message);
                    fileManager.WriteLogToFile(fileLog, message);
                }
            }


#endif

#if false
            /*
                Задание 2: Пользователь вводит с клавиатуры слово для поиска в тестовом файле и слово для замены.
                Приложение должно изменить все вхождения искомого слова на слово для замены. Статистику работы
                приложения нужно записать в отдельный файл и вывести на экран.
            */

            FileManager fileManager = new FileManager();
            string file = "Nature.txt", fileLog = "task2Log.txt";
            if (!fileManager.IsFileExist(file))
            {
                Console.WriteLine("Файла не существует!");
            } 
            else
            {
                fileManager.ReadLineByLineFromFile(file);

                Console.Write("\n\nВведите слово которое нужно заменить: ");
                string word = Console.ReadLine();

                Console.Write("\n\nВведите слово на которое нужно заменить: ");
                string newWord = Console.ReadLine();    

                fileManager.ReplaceWordFromFile(file, word, newWord, fileLog);

                fileManager.ReadLineByLineFromFile(file);
            }

#endif

#if false
            /*
                Задание 3: В файле содержится 1000 целых чисел. Приложение должно проанализировать файл и
                отобразить статистику по нему:
                - количество положительных чисел
                - количество отрицательных чисел
                - количество двузначных чисел
                - количество пятизначных чисел
                Также приложение должно создавать файлы с этими числами.
            */
            string path = "random.txt";

            FileManager fm = new FileManager();
            
            int even = fm.CountValueEvenOddTwoFiveDigit(path).Item1;
            int odd = fm.CountValueEvenOddTwoFiveDigit(path).Item2;
            int two_digit = fm.CountValueEvenOddTwoFiveDigit(path).Item3;
            int five_digit = fm.CountValueEvenOddTwoFiveDigit(path).Item4;

            Console.WriteLine(
                $"\nEven Count: {even}\n" +
                $"Odd Count: {odd}\n" +
                $"Two Digit Count: {two_digit}\n" +
                $"Five Digit Count: {five_digit}\n");
#endif

#if false
            /*
                Задание 4: Дан текстовый файл. Прочитать из текстового файла только четные строки, вывести их на
                экран и записать в другой файл.

            */
            string path = "random.txt";
            FileManager fm = new FileManager();
            fm.ReadEvenLineFromFile(path, "randomEvenLine.txt");
#endif

#if false
            /*
                Задание 5: Напишите приложение, которое записывает в текстовый файл данные коллекции из
                Задания 1 (HW 19). В текстовом файле каждый элемент коллекции пронумеровать.
                Задания 1 (HW 19) : Опишите словарь, который в качестве ключа использует объект пользовательского
                класса “Человек“ (имя, возраст), а в качестве значения - список стран, где побывал человек с указанием
                года для каждой страны. Проинициализируйте словарь данными и выведите на экран.
            */

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

            string path = "travelers.txt";
            int nr = 1;
            FileManager fm = new FileManager();
            StringBuilder sb = new StringBuilder();

           fm.DeleteFile(path);
            foreach (KeyValuePair<Person, Dictionary<string, List<int>>> item in keyValues)
            {
                sb.Clear();
                Console.Write($"{item.Key} ");
                Console.Write($"был в: ");
                sb.Append($"{item.Key} был в: ");
                foreach (var item1 in item.Value)
                {
                    Console.Write($"[{item1.Key} год - {string.Join(", ", item1.Value)}], ");
                    sb.Append($"[{item1.Key} год - {string.Join(", ", item1.Value)}], ");
                }
                Console.WriteLine();
                fm.WriteToFile(path, sb.ToString(), true);
            }


#endif

#if false
            /*
                Задание 6: Создайте запись «Дневная температура». Необходимо хранить информацию о самой
                большой и самой маленькой температуре за день. Создайте массив температур. Напишите код для
                вычисления дня с максимальной разницей между самой большой и самой маленькой температурой.
            */

            DailyTemperatureRecord t1 = new DailyTemperatureRecord(new DateTime(2024,02,20), 5, -2);
            DailyTemperatureRecord t2 = new DailyTemperatureRecord(new DateTime(2024,02,21), 10, 0);
            DailyTemperatureRecord t3 = new DailyTemperatureRecord(new DateTime(2024,02,22), 9, 1);
            DailyTemperatureRecord t4 = new DailyTemperatureRecord(new DateTime(2024,02,23), 6, -30);
            DailyTemperatureRecord t5 = new DailyTemperatureRecord(new DateTime(2024,02,24), 11, 2);

            DailyTemperatureRecord[] array = new DailyTemperatureRecord[] { t1, t2, t3, t4, t5 };

            DailyTemperatureRecord max = array.OrderByDescending(x => x.MaxT - x.MinT).First();

            Console.WriteLine(max);

#endif

#if false
            /*
                Задание 7: Создайте запись «Оценки студента». Необходимо хранить информацию об
                экзаменационных оценках студента по набору предметов. Создайте массив оценок. Напишите код для
                отображения студента с максимальной, средней оценкой.
            */

            StudentGrades st1 = new StudentGrades("Dvornicov");
            st1.AddGrade("Математика", 9.5);
            st1.AddGrade("Физика", 9.9);
            st1.AddGrade("Литература", 10.0);

            StudentGrades st2 = new StudentGrades("Mamlai");
            st2.AddGrade("Математика", 12);
            st2.AddGrade("Физика", 11.2);
            st2.AddGrade("Литература", 9.2);

            StudentGrades st3 = new StudentGrades("Golovcenko");
            st3.AddGrade("Математика", 12);
            st3.AddGrade("Физика", 12.0);
            st3.AddGrade("Литература", 11.5);

            StudentGrades[] array = new StudentGrades[] { st1, st2, st3 };

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            StudentGrades max = array.OrderByDescending(x => x.GetAverage() + x.GetAverage()).First();

            Console.WriteLine(max);

#endif
            Console.Read();
        }
    }
}
