using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //Задание 1: Напишите приложение, которое после запуска запрашивает пароль. Если
            //пользователь вводит верный пароль(он хранится в строке текста), то программа просит у
            //пользователя ввести имя и приветствует его по имени. Если же пароль неверный, то сообщает об
            //этом и желает хорошего дня.

            string dbPassword = "password";
            Console.Write("Введите пароль: ");
            string inputPassword = Console.ReadLine();
            bool isPasswordCorrect = inputPassword.Contains(dbPassword);
            
            if (isPasswordCorrect)
            {
                Console.Write("\nВведите имя: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Привет {name}");
            }else
            {
                Console.WriteLine("Неверный пароль!\nXорошего дня!");
            }
#endif

#if false
            //Задача 2.Напишите программу, которая запрашивает с клавиатуры строку произвольной длины
            //и символ.Считает и выводит на экран процент вхождения заданного символа в строку.

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();

            Console.Write("Введите символ: ");
            char c = char.Parse(Console.ReadLine());

            int totalCharCount = str.Length;
            int charCount = str.Count( (x) => x == c);

            double result = ((double)charCount / (double)totalCharCount) * 100;
            
            Console.WriteLine($"Кол-во символов {charCount}, процент вхождения составляет {result:F}% от строки, в которой {totalCharCount} символов.");

#endif

#if false
            //Задача 3.Напишите программу, которая запрашивает с клавиатуры строку произвольной длины,
            //считает и выводи на экран процент вхождения гласных букв латинского алфавита в строку(не
            //различая регистры).

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            str = str.ToLower();
            int totalCharCount = str.Length;
            int charCount = str.Count((x => "aeiou".Contains(x)));
            double result = ((double)charCount / (double)totalCharCount) * 100;

            Console.WriteLine($"Кол-во гласных {charCount}, процент вхождения составляет {result:F}% от строки, в которой {totalCharCount} символов.");
#endif

#if false
            //Задание 4: Напишите приложение, которое запрашивает строку с клавиатуры и осуществляет
            //реверс всей строки(без использования методов).Полученную строку вывести на экран.

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string strRevers = "";
            for (int i = str.Length -1; i >= 0; i--)
            {
                strRevers += str[i].ToString();
            }
            Console.WriteLine(strRevers);
#endif

#if false
            //Задание 5: Пользователь вводит предложение с клавиатуры.Программа подсчитывает и выводит
            //на экран количество:
            //− слов в предложении;
            //− символов(включая пробелы);
            //− символов(не включая пробелы);
            //− цифр.

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string[] arrStr;
            arrStr = str.Split(" ,.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int numCount = str.Count(x => "1234567890".Contains(x));
            int wordsCount = arrStr.Length;
            int charCount = str.Length;
            int charNotEmptyCount = str.Count(x => x != ' ');

            Console.WriteLine($"Количество слов в предложении: {wordsCount}");
            Console.WriteLine($"Общее количество символов (включая пробелы): {charCount}");
            Console.WriteLine($"Количество символов (не включая пробелы): {charNotEmptyCount}");
            Console.WriteLine($"Количество цифр: {numCount}");
#endif

#if false
            //Задание 6: Пользователь вводит предложение с клавиатуры.Программа должна перевернуть
            //каждое слово предложения и вывести результат на экран.
            //Например:
            //пользователь ввёл: sun cat dogs cup tea;
            //после переворота: nus tac sgod puc aet.

            Console.Write("Введите строку: ");
            string str = Console.ReadLine();

            string[] arrStr;
            arrStr = str.Split(" ,.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] arrStrRevers = new string[arrStr.Length];
            string strRevers = "";

            for (int i = 0; i < arrStr.Length; i++)
            {
                for (int j = arrStr[i].Length - 1; j >= 0; j--)
                {
                    strRevers += arrStr[i][j].ToString();
                }

                arrStrRevers[i] = strRevers;
                strRevers = "";
            }

            foreach (var item in arrStrRevers)
            {
                Console.Write(item + " ");
            }


#endif

#if false
            //Задание 7: Дано предложение, состоящее из множества слов.Ввести слово, содержащееся в этом
            //предложении.Программа должна удалить все вхождения этого слова в строку независимо от
            //регистра.Например:
            //Исходная строка: Вздох не тот! Ход не тот! Смех не тот! Свет не тот!
            //Слово для удаления: НЕ
            //Предложение после удаления слова: Вздох тот!Ход тот! Смех тот!Свет тот!

            string str = "Вздох не тот! Ход не тот! Смех не тот! Свет не тот!";
            string removeStr = "НЕ";

            str = str.Replace(removeStr.ToLower(), "");
            str = str.Replace(removeStr, "");
            str = str.Replace("  ", " ");

            Console.WriteLine(str);
#endif

            Console.ReadLine();
        }
    }
}
