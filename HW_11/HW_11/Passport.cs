using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Passport
    {
		private string fullName;
		private DateTime dateOfBirth;
		private string gender;
		private string nationality;
		private string seriesNumber;
		private DateTime dateOfIssue;
		private string residentialAddress;

		public string ResidentialAddress
		{
			get { return residentialAddress; }
			set { residentialAddress = value; }
		}

		public DateTime DateOfIssue
        {
			get { return dateOfIssue; }
			set { dateOfIssue = value; }
		}


		public string SeriesNumber
        {
			get { return seriesNumber; }
			set { seriesNumber = value; }
		}

		public string Nationality
        {
			get { return nationality; }
			set { nationality = value; }
		}


		public string Gender
        {
			get { return gender; }
			set { gender = value; }
		}


		public DateTime DateofBirth
        {
			get { return dateOfBirth; }
			set { dateOfBirth = value; }
		}

		public string FullName
		{
			get { return fullName; }
			set { fullName = value; }
		}
        public Passport() : this(fullName: "No FullName", dateOfBirth: DateTime.MinValue, gender: "No Gender",
			nationality: "No Nationality", seriesNumber: "No Series Number", dateOfIssue: DateTime.MinValue,
			residentialAddress: "No Residential Address")
        { }

        public Passport(string fullName, DateTime dateOfBirth, string gender, string nationality,
                        string seriesNumber, DateTime dateOfIssue, string residentialAddress)
        {
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.nationality = nationality;
            this.seriesNumber = seriesNumber;
            this.dateOfIssue = dateOfIssue;
            this.residentialAddress = residentialAddress;
        }
		public Passport(Passport passport)
		{
			FullName = passport.FullName;
			DateofBirth = passport.DateofBirth;
			Gender = passport.Gender;
			Nationality = passport.Nationality;
			SeriesNumber = passport.SeriesNumber;
			DateOfIssue = passport.DateOfIssue;
			ResidentialAddress = passport.residentialAddress;
		}

        virtual public void Show()
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Фамилия, имя, отчество:			{FullName}");
            Console.WriteLine($"Дата рождения:				{DateofBirth.ToShortDateString()}");
            Console.WriteLine($"Пол:					{Gender}");
            Console.WriteLine($"Национальность:				{Nationality}");
            Console.WriteLine($"Серия и номер паспорта:			{SeriesNumber}");
            Console.WriteLine($"Дата выдачи:				{DateOfIssue.ToShortDateString()}");
            Console.WriteLine($"Регистрация по месту жительства:	{ResidentialAddress}");
			Console.ResetColor();
        }
		virtual public void Init()
		{
			try
			{
                Console.WriteLine($"Введите паспортные данные:");
                Console.Write($"Введите (фамилию, имя, отчество): ");
                FullName = Console.ReadLine();
                Console.Write($"Введите (дату рождения гггг.мм.дд): ");
                DateofBirth = DateTime.Parse(Console.ReadLine());
                Console.Write($"Введите (пол): ");
                Gender = Console.ReadLine();
                Console.Write($"Введите (национальность): ");
                Nationality = Console.ReadLine();
                Console.Write($"Введите (серию и номер паспорта): ");
                SeriesNumber = Console.ReadLine();
                Console.Write($"Введите (дату выдачи гггг.мм.дд): ");
                DateOfIssue = DateTime.Parse(Console.ReadLine());
                Console.Write($"Введите (регистрацию по месту жительства): ");
                ResidentialAddress = Console.ReadLine();
            }
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
		virtual public int GetAge() 
		{
            DateTime today = DateTime.Today;
            int tmpAge = today.Year - DateofBirth.Year;

			return DateofBirth.Date > today.AddYears(-tmpAge) ? tmpAge-- : tmpAge;
        }
        public static implicit operator bool(Passport passport)
		{
			return passport.nationality.ToLower() == "Moldova".ToLower() || passport.nationality.ToLower() == "Republic of Moldova".ToLower();
        }
        public override string ToString()
        {
			return $"\n\x1b[32mФамилия, имя, отчество:			{FullName}\n" +
				   $"Дата рождения:				{DateofBirth.ToShortDateString()}\n" +
				   $"Пол:					{Gender}\n" +
				   $"Национальность:				{Nationality}\n" +
				   $"Серия и номер паспорта:			{SeriesNumber}\n" +
				   $"Дата выдачи:				{DateOfIssue.ToShortDateString()}\n" +
				   $"Регистрация по месту жительства:	{ResidentialAddress}\x1b[0m";
        }
    }
}
