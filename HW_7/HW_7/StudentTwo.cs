using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    internal class StudentTwo
    {
        private string surname;
        private string name;
        private static DateTime age;
        private string vuz;
        private int[][] grades;

        private static int[][] GradeFilter(int[][] gr) => gr?.Select(subGrades => subGrades.Where(n => n < 13 && n > 0).ToArray()).ToArray() ?? new int[0][];
        private static int[] GradeFilter(int[] gr) => gr?.Where(n => n < 13 && n > 0).ToArray() ?? new int[0];
        public DateTime Age { get => age; set => age = value; }

        public static int GetAge() 
        {
            DateTime today = DateTime.Today;
            int tmpAge = today.Year - age.Year;

            if (age.Date > today.AddYears(-tmpAge))
            {
                tmpAge--;
            }
            return tmpAge;
        }
        public StudentTwo() : this("No Surname", "No Name", "01.01.0001", "No Vuz", null) { }
        public StudentTwo(in string surname, in string name, in string age, in string vuz, int[][] grades)
        {
            this.surname = surname;
            this.name = name;
            Age = DateTime.Parse(age);
            this.vuz = vuz;
            this.grades = GradeFilter(grades);
        }
        public StudentTwo(StudentTwo obj)
        {
            surname = obj.surname;
            name = obj.name;
            age = obj.Age;
            vuz = obj.vuz;
            grades = obj.grades;

    }
        private string GetStringGrades()
        {
            if (grades != null && grades.Length > 0)
            {
                StringBuilder result = new StringBuilder();

                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] != null && grades[i].Length > 0)
                    {
                        string subjectName = GetSubjectName(i);
                        string gradesString = string.Join(", ", grades[i]);

                        result.AppendLine($"Оценки по {subjectName}: {gradesString}");
                    }
                    else
                    {
                        result.AppendLine($"Нету оценок по {GetSubjectName(i)}");
                    }
                }

                return result.ToString();
            }
            else return "No grades";
        }
        public double[] GetGradeAverage() 
        {
            double[] result = new double[grades.Length];
            if (grades != null & grades.Length > 0) 
            {
                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] != null && grades[i].Length > 0)
                    {
                        result[i] = grades[i].Average();
                    }
                    else
                    {
                        result[i] = 0.0;
                    }
                }
            }
            return result;
        }
        public void ShowGrades()
        {
            Console.WriteLine($"{GetStringGrades()}");
        }
        public override string ToString()
        {
            return $"Surname: {surname}\n" +
                   $"Name   : {name}\n" +
                   $"Age    : {age:D}\n" +
                   $"Vuz    : {vuz}\n" +
                   $"{GetStringGrades()}";
        }
        public void SetGrade(int[][] grade)
        {
            int[][] tmp = new int[grades.Length][];
            for (int i = 0;i < tmp.Length;i++) 
            {
                tmp[i] = grades[i].Concat(grade[i]).ToArray();
            }
            grades = GradeFilter(tmp);
        }
        public double GetAverageBySubject(int index)
        {
            if (grades != null && grades[index].Length > 0)
            {
                return grades[index].Average();
            }else
            {
                Console.WriteLine("Нету оценок по этому предмету");
                return 0.0;
            }

        }
        public static string GetSubjectName(int index)
        {
            switch (index)
            {
                case 0:
                    return "программированию";
                case 1:
                    return "администрированию";
                case 2:
                    return "дизайну";
                default:
                    return $"{index}";
            }
        }
        public void Init()
        {
            int[][] gr = new int[3][];
            bool isData;

            Console.WriteLine("Введите студента!");
            Console.Write("Фамилия: ");
            surname = Console.ReadLine();
            Console.Write("Имя: ");
            name = Console.ReadLine();
            Console.Write("Группа: ");
            vuz = Console.ReadLine();

            do
            {
                Console.Write("Введите дату dd.MM.yyyy: ");
                string input = Console.ReadLine();
                string dateFormat = "dd.MM.yyyy";
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo("ru-RU");

                isData = DateTime.TryParseExact(input, dateFormat, cultureInfo, DateTimeStyles.None, out age);
            } while (!isData);

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Введите оценки по {GetSubjectName(i)}: ");
                string strGr = Console.ReadLine();
                string[] strGrArr = strGr.Split(" .,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                gr[i] = new int[strGrArr.Length];
                for (int j = 0; j < strGrArr.Length; j++)
                {
                    gr[i][j] = int.Parse(strGrArr[j]);
                }
            }
            grades = GradeFilter(gr);
            
        }
    }
}
