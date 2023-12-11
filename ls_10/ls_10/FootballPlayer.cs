using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_10
{
    internal class FootballPlayer
    {
        public string FullName { get; set; }
        public int Number { get; set; }
        public string Phone { get; private set; }

        public FootballPlayer(string fname, int number, string phone) 
        {
            FullName = fname;
            Number = number;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"\nFullName:      {FullName}\n" +
                   $"Number:        {Number}\n" +
                   $"Phone:         {Phone}\n";
        }
    }
}
