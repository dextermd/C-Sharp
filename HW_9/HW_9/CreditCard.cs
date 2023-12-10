using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    internal class CreditCard
    {
        private string cardNumber;
        private string fullName;
        private decimal balance;
        private string cvc;
        private ExpirationDate expirationDate;

        public string CardNumber 
        { 
            get => cardNumber; 
            private set
            {
                cardNumber = value;
                cardNumber = cardNumber.Replace(" ", "");

                if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
                    throw new CardException($"Номер карты должен содержать ровно 16 цифр.", cardNumber); ;
            }   
        }
        public decimal Balance { get => balance; set => balance = value; }

        private struct ExpirationDate
        {
            public int Month {  get;}
            public int Year { get;}
            public ExpirationDate(int month, int year)
            {
                Month = month;
                Year = year;
            }
        }
        public CreditCard() 
        {
            cardNumber = "XXXXXXXXXXXXXXXX";
            fullName = "No Name";
            balance = 0;
            cvc = "XXX";  
        }
        public CreditCard(string cardNumber, string fullName)
        {
            CardNumber = cardNumber;
            this.fullName = fullName;
            balance = 0;
            cvc = new Random().Next(1, 999).ToString("D3");
            expirationDate = new ExpirationDate(DateTime.Now.Month, DateTime.Now.Year + 5);

        }
        public void SetExpirationDate(int month, int year) 
            => expirationDate = new ExpirationDate(month, year);
        public override string ToString()
        {
            return $"\nCard Number:           {CardNumberFormatter(cardNumber)}\n" +
                   $"Full Name:             {fullName}\n" +
                   $"Balance:               {balance:F}\n" +
                   $"CVC:                   {cvc}\n" +
                   $"Expiration Date:       {expirationDate.Month}/{expirationDate.Year}\n";
        }
        private static string CardNumberFormatter(string cardNumber)
        {
            StringBuilder formattedCardNumber = new StringBuilder();
            for (int i = 0; i < cardNumber.Length; i++) 
            {
                if (i > 0 && i % 4 == 0) 
                {
                    formattedCardNumber.Append(' ');
                }
                formattedCardNumber.Append(cardNumber[i]);
            }
            return formattedCardNumber.ToString();
        }
        public static CreditCard operator +(CreditCard card, decimal summa)
        {
            return new CreditCard() 
            {
                CardNumber = card.cardNumber,
                fullName = card.fullName,
                Balance = card.balance + summa,
                cvc = card.cvc,
                expirationDate = card.expirationDate,
            };
        }
        public static CreditCard operator -(CreditCard card, decimal summa)
        {
            return new CreditCard() 
            {
                CardNumber = card.cardNumber,
                fullName = card.fullName,
                Balance = card.balance - summa,
                cvc = card.cvc,
                expirationDate = card.expirationDate,
            };
        }
        public static bool operator ==(CreditCard card, string code)
        {
            return card.cvc == code;
        }
        public static bool operator !=(CreditCard card, string code)
        {
            return card.cvc != code;
        }
        public static bool operator <(CreditCard card, int summa)
        {
            return card.balance < summa;
        }
        public static bool operator >(CreditCard card, int summa)
        {
            return card.balance > summa;
        }
        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
