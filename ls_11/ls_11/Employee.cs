using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_11
{
    internal class Employee : Human
    {
		private string companyInfo;
		private double salary;

		public double Salary
		{
			get { return salary; }
			set { salary = value; }
		}

		public string CompanyInfo
        {
			get { return companyInfo; }
			set { companyInfo = value; }
		}

		public Employee() : base() { companyInfo = "No Company"; salary = 0; }
		public Employee(string name, string surname, DateTime dateOfBird,
			string companyInfo, double salary) : base(name, surname, dateOfBird)
		{
			this.companyInfo = companyInfo;
			this.salary = salary;
		}
		public override void Show()
		{
			base.Show();
            Console.WriteLine($"Company:	{companyInfo}");
            Console.WriteLine($"Salary:		{salary:F}");
        }
        public override string ToString()
        {
			return base.ToString() + 
					$"Company:	{companyInfo}\n" +
					$"Salary:		{salary:F}\n";
        }
    }
}
