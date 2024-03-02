using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _My_Person
{
    internal class Person :IEquatable<Person>
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age;} set { age = value; } }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person()
        {
            this.age = 0;
            this.name= string.Empty;
        }

        public bool Equals(Person other)
        {
            if(other == null) return false;

            return this.Name == other.Name && this.Age == other.Age;
            
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"Имя: {Name} \nВозраст: {Age}";
        }



    }
}
