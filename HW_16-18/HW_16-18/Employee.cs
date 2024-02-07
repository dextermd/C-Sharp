using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class Employee : IEquatable<Employee>
    {
		private string fullname;
		public string Fullname
		{
			get { return fullname; }
			set { fullname = value; }
		}
		private string positon;
		public string Position
		{
			get { return positon; }
			set { positon = value; }
		}

		private double salary;
		public double Salary
		{
			get { return salary; }
			set { salary = value; }
		}

		private string email;
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public Employee()
		{
			Fullname = "No Fullname";
			Position = "No Position";
			Salary = 0.0;
			Email = "No Email";
		}
		public Employee(string fullname, string position, double salary, string email)
        {
            Fullname = fullname;
            Position = position;
            Salary = salary;
            Email = email;
        }
		public Employee(Employee obj)
		{
			Fullname = obj.Fullname;
			Position = obj.Position;
			Salary = obj.Salary;
			Email = obj.Email;
		}
		public override string ToString() 
		{
			return $"\nFullname:	{Fullname}\n" +
				   $"Postion:	{Position}\n" +
				   $"Salary:		{Salary}\n" +
				   $"Email:		{Email}\n";
		}

		public void Add()
		{
			Console.Write("Input Fullname: ");
			Fullname = Console.ReadLine();
            Console.Write("Input Position: ");
            Position = Console.ReadLine();
            Console.Write("Input Salary: ");
            Salary = int.Parse(Console.ReadLine());
            Console.Write("Input Email: ");
            Email = Console.ReadLine();
            Console.WriteLine();
        }
		public void Edit(Employee newObj)
		{
            Fullname = newObj.Fullname;
			Position = newObj.Position;
			Salary = newObj.Salary;
			Email = newObj.Email;
        }
        public void Edit()
        {
            Console.Write("Input New Fullname: ");
            Fullname = Console.ReadLine();
            Console.Write("Input New Position: ");
            Position = Console.ReadLine();
            Console.Write("Input New Salary: ");
            Salary = int.Parse(Console.ReadLine());
            Console.Write("Input New Email: ");
            Email = Console.ReadLine();
            Console.WriteLine();
        }

        public bool Equals(Employee other)
        {
            return fullname.Equals(other.fullname);
        }
    }
}
