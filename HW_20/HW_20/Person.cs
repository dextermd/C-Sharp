using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_20
{
    internal class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public bool Equals(Person other)
        {
            if (other == null) return false;

            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}