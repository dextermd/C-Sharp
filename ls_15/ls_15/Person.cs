using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    internal class Person
    {
        public string Name { get; set; } // автоматическое свойство
        public string Phone { get; set; }  // автоматическое свойство
        public Person(string name, string phone) 
        {
            Name = name;
            Phone = phone;
        }
        public void BankMessageHandler(object sender, EventArgs args)
        {
            Console.WriteLine($"Событие произошло");
        }
        public void PersonHandler(object sender, MainBankEventArgs args)
        {
            Console.WriteLine($"\nПодписчик: {Name} Телефон: {Phone} получил курс валют\n" +
                              $"Курс Euro: {args.CursEuro}\n" +
                              $"Курс Dollar: {args.CursDollar}\n");
        }
        public override string ToString()
        {
            return $"\nПодписчик {Name} Телефон: {Phone}";
        }
    }
}
