using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Student : Human
    {
		private string vuz;
		private int[] grades;

		public int[] Grades
		{
			get { return grades; }
			set { grades = value; }
		}

		public string Vuz
		{
			get { return vuz; }
			set { vuz = value; }
		}

		public Student(string name, string surname, DateTime dateOfBird, string vuz, int[] grades) : base(name, surname, dateOfBird) 
		{
			Vuz = vuz;
            Grades = grades;
        }

        public Student() : base()
        {
            Vuz = "No Vuz";
        }
        public double avgGrades() => grades.Average();
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Vuz:	        {Vuz}");
            Console.Write($"Grades:	        ");
            foreach (var grade in grades)
            {
                Console.Write($"{grade} ");
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            return base.ToString() +
                $"Vuz:            {Vuz}\n" +
                $"Grades:         {string.Join(",", grades)}\n";
        }

    }
}
