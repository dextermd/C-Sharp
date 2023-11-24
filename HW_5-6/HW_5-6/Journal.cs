using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_6
{
    internal class Journal
    {
        private string name;
        private int year;
        private string description;
        private string phone;
        private string email;

        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Description { get => description; set => description = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
