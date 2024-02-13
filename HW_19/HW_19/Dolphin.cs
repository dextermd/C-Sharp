using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class Dolphin
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Dolphin() { }
        public Dolphin(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString() 
        {
            return $"{"Dolphin", -9}  -> {Name}, {Age}, {Gender}";
        }
    }
}
