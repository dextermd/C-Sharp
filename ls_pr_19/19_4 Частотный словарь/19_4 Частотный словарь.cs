using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Частотный словарь: посчитать количество повторений слов в строке и общее количество слов.

Мишка по лесу идет, Мишка ищет сладкий мед. Если мишка мед найдет, В гости зайку позовет.
Прыг-прыг-прыг - что было сил Мячик маленький спешил, А за ним большой бежал, ПРЫГ - и вмиг его догнал.
 */

namespace _19_4_Частотный_словарь
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "Мишка по лесу идет,    Мишка ищет сладкий мед. Если Мишка мед найдет,   В гости зайку позовет.\n" +
                "Мишка по лесу идет,    Мишка ищет сладкий мед. Если Мишка мед найдет,   В гости зайку позовет.";

            string []words = str.Split(new char[] {' ',',','.','!','\n'}, StringSplitOptions.RemoveEmptyEntries);

            /*Sorted*/Dictionary<string, int> vocabular = new /*Sorted*/Dictionary<string, int>();
            foreach (string word in words)
            {
                if(vocabular.ContainsKey(word))
                {
                    vocabular[word]++;
                }
                else
                {
                    vocabular[word] = 1;
                    //vocabular.Add(word, 1);
                }
            }
            Console.WriteLine($"{"Слово", -10}Повторения");
            foreach (KeyValuePair<string, int> pair in vocabular)
            {
                Console.WriteLine($"{pair.Key, -15} {pair.Value}");
            }

            Console.Read();
        }
    }
}
