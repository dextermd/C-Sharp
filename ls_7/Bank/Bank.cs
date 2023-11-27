using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Характеристики:
//    - текущий баланс
//    - статическое поле бонус
//    - конструктор
//    - методы set / get   или свойства
//    - статический конструктор для иниц.стат.поля
//    - метод для расчета процента

namespace Bank
{
    internal class Bank
    {
		private double currentBalance;
		private static readonly double bonus;

		public double CurrentBalance
        {
			get { return currentBalance; }
			private set { currentBalance = value; }
		}

		public Bank(double currentBalance = 0) 
		{
            Console.WriteLine("Конструктор");
            this.currentBalance = currentBalance;
		}
		static Bank() 
		{
            Console.WriteLine("Статический Конструктор");
			bonus = 4.5;
        }
		public static double GetBonus() => bonus / 100;

		public double GetPercents(double summa) 
		{ 
			if (summa < currentBalance) 
			{
				double percent = summa * bonus / 100;
				currentBalance -= percent;
				return percent;
			}
			return -1;
		}

	}
}
