using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
	// Класс для подписчиков/слушателей
    internal class Bank
    {
        public double CursEuro { get; set; }
        public double CursDollar { get; set; }

        private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string address;
		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		public Bank(string name, string address)
		{
			Name = name;
			Address = address;
		}
		// Обработчик события (должен по сигнвтуре совпадать с типом делегата класса-издателя)
		public void BankHandler(object sender, MainBankEventArgs args)
		{
			CursEuro = args.CursEuro;
			CursDollar = args.CursDollar;
            Console.WriteLine($"\nБанк: {Name} Адрес: {Address} получил курс на дату: {args.Date}\n" +
							  $"Курс Euro: {args.CursEuro}\n" +
							  $"Курс Dollar: {args.CursDollar}\n");
        }
        public void BankMessageHandler(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Событие произошло!");
        }
        public override string ToString()
		{
			return $"\nБанк {Name} Euro: {CursEuro:F2} Dollar: {CursDollar:F2}";
		}
	}
}
