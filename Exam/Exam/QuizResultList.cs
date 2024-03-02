using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class QuizResultList
    {
        private List<QuizResult> results = new List<QuizResult>();

        public void AddResult(QuizResult result)
        {
            results.Add(result);
        }

        public void DisplayResults(string username)
        {
            var userResults = results.Where(r => r.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();

            if (userResults.Count == 0)
            {
                Console.WriteLine($"Результаты викторин для пользователя {username} отсутствуют.");
                return;
            }

            Console.WriteLine($"Результаты викторин для пользователя {username}:");
            foreach (var result in userResults)
            {
                Console.WriteLine($"Категория: {result.Category}, Правильных ответов: {result.CorrectAnswers} из {result.TotalQuestions}");
            }
        }

        public void DisplayTopResults(string category)
        {
            var topResults = results.Where(r => r.Category == category)
                                    .OrderByDescending(r => r.CorrectAnswers)
                                    .ThenBy(r => r.TotalQuestions)
                                    .Take(20);

            if (!topResults.Any())
            {
                Console.WriteLine($"Результаты викторин для категории \"{category}\" отсутствуют.");
                return;
            }

            Console.WriteLine($"Топ-20 результатов для категории \"{category}\":");
            foreach (var result in topResults)
            {
                Console.WriteLine($"Пользователь: {result.Username}, Правильных ответов: {result.CorrectAnswers} из {result.TotalQuestions}");
            }
        }

        public void SaveResultsToFile()
        {
            string filePath = "quizResults.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (var result in results)
                {
                    writer.WriteLine($"{result.Username},{result.Category},{result.CorrectAnswers},{result.TotalQuestions}");

                }
            }
        }

        public void LoadResultsFromFile()
        {
            string filePath = "quizResults.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл с результатами викторин не найден.");
                return;
            }

            results.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 4)
                    {
                        try
                        {
                            string username = parts[0];
                            string category = parts[1];
                            int correctAnswers = int.Parse(parts[2]);
                            int totalQuestions = int.Parse(parts[3]);

                            QuizResult result = new QuizResult(username, category, correctAnswers, totalQuestions);
                            results.Add(result);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка при чтении данных из файла. Некорректный формат.");
                        }
                    }
                }
            }

            Console.WriteLine("Результаты викторин успешно загружены из файла.");
        }
    }
}
