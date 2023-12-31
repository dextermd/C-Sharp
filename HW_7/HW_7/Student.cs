﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HW_7
{
    internal class Student
    {
        private string surname;
        private string name;
        private string group;
        private int age;
        private int[] grades;

        public string Surname { get => surname; }
        public string Name { get => name; }
        public int Age { get => age; }

        public Student() : this("No Surname", "No Name", "No Group", 00, null){ }
        public Student(in string surname, in string name, in string group, in int age, params int[] grades)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.age = age;
            this.grades = grades?.Where(n => n < 13 && n > 0).ToArray() ?? new int[0];
        }
        public Student(Student obj)
        {
            surname = obj.surname;
            name = obj.name;
            group = obj.group;
            age = obj.age;
            grades = obj.grades;
        }
        public string GetStringGrades()
        {
            if (grades != null) {
                string str_grades = string.Join(", ", grades);
                return str_grades;
            }else return "No grades";
        }
        public double GetGradeAverage() => grades.Average();
        public void ShowGrades()
        {
            foreach (var grade in grades)
            {
                Console.Write(grade + " ");
            }
        }
        public override string ToString()
        {
            return $"Surname: {surname}\n" +
                   $"Name   : {name}\n" +
                   $"Group  : {group}\n" +
                   $"Age    : {age}\n" +
                   $"Grades : {GetStringGrades()}";
        }
        public void SetGrade(params int[] grade)
        {
            int[] tmp = new int[grades.Length + grade.Length];
            tmp = grades.Concat(grade).ToArray();
            grades = tmp;
        }
        public void Init() 
        {
            bool isInt = false;
            int[] gr;

            Console.WriteLine("Введите студента!");
            Console.Write("Фамилия: ");
            surname = Console.ReadLine();
            Console.Write("Имя: ");
            name = Console.ReadLine();
            Console.Write("Группа: ");
            group = Console.ReadLine();
            do
            {
                Console.Write("Возраст: ");
                isInt = int.TryParse(Console.ReadLine(), out age);
            } while (!isInt);

            Console.Write("Введите оценки: ");
            string strGr = Console.ReadLine();
            string[] strGrArr = strGr.Split(" .,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            gr = new int[strGrArr.Length];
            for (int i = 0; i < strGrArr.Length; i++)
            {
                gr[i] = int.Parse(strGrArr[i]);
            }

            grades = gr?.Where(n => n < 13 && n > 0).ToArray() ?? new int[0];
        }
    }
}
