using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class SeaTurtle
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Habitat { get; set; }

        public SeaTurtle() { }
        public SeaTurtle(string name, int age, string habitat)
        {
            Name = name;
            Age = age;
            Habitat = habitat;
        }

        public override string ToString()
        {
            return $"{"SeaTurtle", -5}  -> {Name}, {Age}, {Habitat}";
        }
    }
}
