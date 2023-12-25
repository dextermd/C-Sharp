using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class CardException : ApplicationException
    {
        public string message;
        private string cardNumber; 
        public DateTime DateException { get; }
        public CardException(string message, string cardNumber)
        {
            this.message = message;
            CardNumber = cardNumber;
            DateException = DateTime.Now;
        }

        public override string Message
        {
            get {
                string color = "31";
                return $"\x1b[{color}m[{DateException}] - Ошибка: ({message})\x1b[0m";

            }
        }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }

    }
}
