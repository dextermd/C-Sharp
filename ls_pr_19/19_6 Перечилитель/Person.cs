using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_6_Перечилитель
{
    internal class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
        public override string ToString() => Name;
    }


}
