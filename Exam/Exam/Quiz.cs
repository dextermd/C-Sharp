using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Quiz
    {
        public string Title { get; set; }
        public QuizCategory Category { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

    }
}
