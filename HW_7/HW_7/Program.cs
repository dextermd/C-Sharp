using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            //Задание 1: Реализуйте класс, описывающий студента.Предусмотреть в нем следующие моменты:
            //    − фамилия,
            //    − имя,
            //    − группа,
            //    − возраст,
            //    − массив оценок по программированию.
            //А также добавить инструменты по работе с перечисленными данными: возможность
            //установки / получения оценок, получение среднего балла, возраста, вывод данных о студенте на
            //экран, ввод данных с клавиатуры.

            Student student = new Student();
            Console.WriteLine(student);

            Console.WriteLine();

            Student student2 = new Student("Dvornicov", "Ruslan", "GP2222", 99, 10,12,8,100,3,5,6,6);
            Console.WriteLine(student2);
            Console.WriteLine($"Grades Average: {student2.GetGradeAverage():F}");

            Console.WriteLine();

            student = student2;
            student.SetGrade(1, 1, 6);
            Console.WriteLine($"Оценки: {student.GetStringGrades()}");
            Console.WriteLine($"Возраст: {student.Age}");
            Console.WriteLine($"Grades Average: {student.GetGradeAverage():F}");

            Console.WriteLine();

            Student studentInit = new Student();
            studentInit.Init();
            Console.WriteLine();
            Console.WriteLine(studentInit);

#endif

#if false
            //Задание 2: На основе класса из Задания 1 реализуйте класс, описывающий студента(версия 2).
            //Предусмотреть в нем следующие моменты:
            //    − фамилия,
            //    − имя,
            //    − дата рождения(тип DateTime),
            //    − наименование Вуза,
            //    − группа,
            //    − массив(зубчатый) оценок по программированию, администрированию и дизайну.

            //А также реализуйте инструменты по работе с перечисленными данными: возможность
            //установки / получения оценок(оценки), получение среднего балла по заданному предмету, вывод
            //данных о студенте на экран, ввод данных с клавиатуры.

            //Реализуйте вычисляемое свойство для определения возраста студента на основе даты его
            //рождения.

            StudentTwo student = new StudentTwo();
            Console.WriteLine(student);

            Console.WriteLine();

            int[][] grades = new int[][]
            {
                new int[] { 5, 8, 7, 100 },
                new int[] { 6, 88,9, 8, 7 },
                new int[] { 200 }
            };
            StudentTwo student2 = new StudentTwo("Dvornicov", "Ruslan", "26.10.1990", "StepIT", grades);
            Console.WriteLine(student2);
            Console.WriteLine($"Лет: {StudentTwo.GetAge()}");
            student2.ShowGrades();

            double[] avg = new double[] { };
            avg = student2.GetGradeAverage();
            for (int i = 0; i < avg.Length; i++)
            {
                Console.Write($"Оценки по {StudentTwo.GetSubjectName(i)}: {avg[i]:F}\n");
            }

            int[][] newGr = new int[][]
            {
                new int[] { 1, 1, 1, 100 },
                new int[] { 1, 88,1,1, 1 },
                new int[] { 200, 1}
            };
            student2.SetGrade(newGr);
            student2.ShowGrades();

            Console.WriteLine();

            StudentTwo student3 = new StudentTwo();
            student3 = student2;
            Console.WriteLine(student3);
            Console.WriteLine($"Оценки по {StudentTwo.GetSubjectName(1)}: {student3.GetAverageBySubject(1)}");

            Console.WriteLine();

            StudentTwo studentInit = new StudentTwo();
            studentInit.Init();
            Console.WriteLine();
            Console.WriteLine(studentInit);
#endif
            Console.ReadLine();
        }
    }
}
