using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Human
    {
        protected string name;
        protected string surname;
        private DateTime dateOfBird;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime DateOfBird
        {
            get { return dateOfBird; }
            set { dateOfBird = value; }
        }
        public Human() : this("No Name", "No Surname", DateTime.MinValue) { }
        public Human(string name, string surname, DateTime dateOfBird)
        {
            Name = name;
            Surname = surname;
            DateOfBird = dateOfBird;
        }
        virtual public void Show()
        {
            Console.WriteLine($"Name:           {Name}");
            Console.WriteLine($"Surname:        {Surname}");
            Console.WriteLine($"Date Of Bird:   {DateOfBird.ToShortDateString()}");
        }
        public override string ToString()
        {
            return $"Name:           {Name}\n" +
                   $"Surname:        {Surname}\n" +
                   $"Date Of Bird:   {DateOfBird.ToShortDateString()}\n";
        }
    }
}
