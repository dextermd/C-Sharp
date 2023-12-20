using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class ForeignPassport : Passport
    {
		private string fPNumber;
		private string[] visas;

		public string[] Visas
        {
			get { return visas; }
			set { visas = value; }
		}

		public string FPNumber
        {
			get { return fPNumber; }
			set { fPNumber = value; }
		}
		
		public ForeignPassport() : base()
		{
			FPNumber = "No Number";
		}
		public ForeignPassport(string fullName, DateTime dateOfBirth, string gender, string nationality,
							   string seriesNumber, DateTime dateOfIssue, string residentialAddress,
							   string fPNumber,  string[] visas) : base(fullName, dateOfBirth, gender, nationality, seriesNumber, dateOfIssue, residentialAddress)
		{
            string[] tmpVisas = new string[visas.Length];

            FPNumber = fPNumber;
            for (int i = 0; i < tmpVisas.Length; i++)
            {
                tmpVisas[i] = visas[i];
            }
            Visas = tmpVisas;
        }

		public ForeignPassport(ForeignPassport obj) : base(obj)
		{
			string[] tmpVisas = new string[obj.visas.Length];
			FPNumber = obj.FPNumber;

			for (int i = 0; i < tmpVisas.Length; i++)
			{
				tmpVisas[i] = obj.visas[i];
            }
			Visas = tmpVisas;

		}
        public new void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Фамилия, имя, отчество:			{FullName}");
            Console.WriteLine($"Дата рождения:				{DateofBirth.ToShortDateString()}");
            Console.WriteLine($"Пол:					{Gender}");
            Console.WriteLine($"Национальность:				{Nationality}");
            Console.WriteLine($"Серия и номер паспорта:			{SeriesNumber}");
            Console.WriteLine($"Дата выдачи:				{DateOfIssue.ToShortDateString()}");
            Console.WriteLine($"Регистрация по месту жительства:	{ResidentialAddress}");
            Console.WriteLine($"Номер заграничного паспорта:		{FPNumber}");
            Console.Write($"Визы:					");
			if ( Visas != null )
			{
                foreach (var visa in Visas)
                {
                    Console.Write($"{visa},");
                }
            }else Console.Write("NULL");

			Console.ResetColor();
        }
        public override void Init()
        {
            base.Init();
            try
            {
                Console.Write($"Введите (номер заграничного паспорта): ");
                FPNumber = Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public override int GetAge() => base.GetAge();
        public override string ToString()
        {
            return $"\n\x1b[31mФамилия, имя, отчество:			{FullName}\n" +
                   $"Дата рождения:				{DateofBirth.ToShortDateString()}\n" +
                   $"Пол:					{Gender}\n" +
                   $"Национальность:				{Nationality}\n" +
                   $"Серия и номер паспорта:			{SeriesNumber}\n" +
                   $"Дата выдачи:				{DateOfIssue.ToShortDateString()}\n" +
                   $"Регистрация по месту жительства:	{ResidentialAddress}\n" +
                   $"Номер заграничного паспорта:		{FPNumber}\n" +
                   $"Визы:					{(Visas != null ? string.Join(", ", Visas) : "NULL")}\x1b[0m";
        }

    }
}

// \x1b[0m";