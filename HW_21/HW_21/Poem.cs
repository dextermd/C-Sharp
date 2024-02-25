using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_21
{
    internal class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }

        public Poem() { }

        public Poem(string title, string author, int year, string text, string theme)
        {
            Title = title;
            Author = author;
            Year = year;
            Text = text;
            Theme = theme;
        }

        public void Add()
        {
            Console.Write("Введите Название стиха: ");
            Title = Console.ReadLine();

            Console.Write("Введите ФИО автора: ");
            Author = Console.ReadLine();

            Console.Write("Введите Год написания: ");
            Year = int.Parse(Console.ReadLine());

            Console.Write("Введите Текст стиха: ");
            Text = Console.ReadLine();

            Console.Write("Введите Тема стиха: ");
            Theme = Console.ReadLine();

            Console.WriteLine();
        }

        public void Edit()
        {
            Console.Write("Введите Новое Название стиха: ");
            Title = Console.ReadLine();

            Console.Write("Введите Новое ФИО автора: ");
            Author = Console.ReadLine();

            Console.Write("Введите Новый Год написания: ");
            Year = int.Parse(Console.ReadLine());

            Console.Write("Введите Новый Текст стиха: ");
            Text = Console.ReadLine();

            Console.Write("Введите Новую Тема стиха: ");
            Theme = Console.ReadLine();

            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"\n\nНазвание: {Title}\n" +
                   $"Автор: {Author}\n" +
                   $"Год написания: {Year}\n" +
                   $"Тема: {Theme}\n" +
                   $"Текст:\n{Text}\n" +
                   $"\n\n";
        }
    }
}
