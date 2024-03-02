using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class QuizResult
    {
        public string Username { get; set; }
        public string Category { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }

        public QuizResult(string username, string category, int correctAnswers, int totalQuestions)
        {
            Username = username;
            Category = category;
            CorrectAnswers = correctAnswers;
            TotalQuestions = totalQuestions;
        }
    }
}
