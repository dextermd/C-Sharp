﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_20
{
    public /*record*/ class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
        }
        public void Deconstruct(out string name, out int age) => (name, age) = (Name, Age);
    }
}
