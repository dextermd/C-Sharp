﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    string message = fileManager.GetMessage($"Add {i} to {fileEven}");
                    fileManager.Message(message);
                    fileManager.WriteLogToFile(fileLog, message);

                }else
                {
                    fileManager.WriteToFile(fileOdd, i.ToString(), true);
                    string message = fileManager.GetMessage($"Add {i} to {fileOdd}");
                    fileManager.Message(message);
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

#if true
            /*
                Задание 3: В файле содержится 1000 целых чисел. Приложение должно проанализировать файл и
                отобразить статистику по нему:
                - количество положительных чисел
                - количество отрицательных чисел
                - количество двузначных чисел
                - количество пятизначных чисел
                Также приложение должно создавать файлы с этими числами.
            */

#endif

#if true
            /*
                Задание 4: Дан текстовый файл. Прочитать из текстового файла только четные строки, вывести их на
                экран и записать в другой файл.

            */

#endif

#if true
            /*
                Задание 5: Напишите приложение, которое записывает в текстовый файл данные коллекции из
                Задания 1 (HW 19). В текстовом файле каждый элемент коллекции пронумеровать.
                Задания 1 (HW 19) : Опишите словарь, который в качестве ключа использует объект пользовательского
                класса “Человек“ (имя, возраст), а в качестве значения - список стран, где побывал человек с указанием
                года для каждой страны. Проинициализируйте словарь данными и выведите на экран.
            */

#endif

#if true
            /*
                Задание 6: Создайте запись «Дневная температура». Необходимо хранить информацию о самой
                большой и самой маленькой температуре за день. Создайте массив температур. Напишите код для
                вычисления дня с максимальной разницей между самой большой и самой маленькой температурой.
            */

#endif

#if true
            /*
                Задание 7: Создайте запись «Оценки студента». Необходимо хранить информацию об
                экзаменационных оценках студента по набору предметов. Создайте массив оценок. Напишите код для
                отображения студента с максимальной, средней оценкой.
            */

#endif
            Console.Read();
        }
    }
}
