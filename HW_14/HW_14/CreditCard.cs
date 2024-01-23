using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14
{
    delegate void MessageDelegate(string str);
    delegate void CardAgrDelegate(object sender, CardArgs args);
    internal class CreditCard
    {
		private string cardNumber;
		private string fullname;
		private DateTime cardExpiryDate;
		private int pin;
		private decimal creditLimit;
		private decimal balance;

        // События класса
        public event MessageDelegate PinChangedEvent;
        public event MessageDelegate LimitEvent;
        public event MessageDelegate MoneySpent;
        public event CardAgrDelegate TopUpEvent;
        public event CardAgrDelegate SpendingEvent;

        public decimal Balance
		{
			get { return balance; }
			set { balance = value; }
		}
		public decimal CreditLimit
		{
			get { return creditLimit; }
			set { creditLimit = value; }
		}
		public int Pin
		{
			get { return pin; }
			set { pin = value; }
		}
		public DateTime CardExpiryDate
        {
			get { return cardExpiryDate; }
			set { cardExpiryDate = value; }
		}
		public string Fullname
		{
			get { return fullname; }
			set { fullname = value; }
		}
		public string CardNumber
		{
			get { return cardNumber; }
			set { cardNumber = value; }
		}

        public CreditCard(string cardNumber, string fullname, DateTime cardExpiryDate, int pin, decimal creditLimit, decimal balance)
        {
			CardNumber = cardNumber;
			Fullname = fullname;
            CardExpiryDate = cardExpiryDate;
			Pin = pin;
            CreditLimit = creditLimit;
            Balance = balance;       
		}
        public void Spending(decimal sum)
        {
            if (sum <= Balance && sum <= CreditLimit)
            {
                Balance -= sum;

                CardArgs args = new CardArgs();
                if (SpendingEvent != null)
                {
                    args.Summa = sum;
                    args.Balance = Balance;
                    SpendingEvent?.Invoke(this, args);
                }
            }
        }
        public void TopUp(decimal sum)
        {
            if (sum > 0)
            {   
                Balance += sum;
                CardArgs args = new CardArgs();
                if (TopUpEvent != null)
                {
                    args.Summa = sum;
                    args.Balance = Balance;
                    TopUpEvent?.Invoke(this, args);
                }
            }
        }
        public void ChangePin(int newPin)
		    {
			    Pin = newPin;
                if (PinChangedEvent != null)
                    PinChangedEvent?.Invoke($"Pin Changed!");
            }
        }
}
