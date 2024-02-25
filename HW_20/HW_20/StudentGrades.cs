using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW_20
{
    internal class StudentGrades
    {
        public string StudentName { get; set; }
        public Dictionary<string, double> SubjectGrades { get; set; }

        public StudentGrades(string name)
        {
            StudentName = name;
            SubjectGrades = new Dictionary<string, double>();
        }

        public void AddGrade(string key, double grade)
        {
            SubjectGrades[key] = grade;
        }

        public double GetGrade(string key)
        {
            if (SubjectGrades.ContainsKey(key))
                return SubjectGrades[key];
            else return -1; 
        }
        public double GetAverage()
        {
            double result = 0;
            foreach (var item in SubjectGrades)
            {
                result += item.Value;
            }
            return  (double)result / SubjectGrades.Count;
        }

        public override string ToString()
        {
            string grades = string.Join("\n", SubjectGrades.Select(x => $"{x.Key}: {x.Value}"));
            return $"Name: {StudentName}\n{grades}\n";
        }

    }
}
