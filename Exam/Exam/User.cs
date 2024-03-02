using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }

        public User() { }
        public User(string login, string password, string dateBirth) { }

        public override string ToString()
        {
            return $"Username: {Username}, Password: {Password}, DateOfBirth: {DateOfBirth}";
        }
    }
}
