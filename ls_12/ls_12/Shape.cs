using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal abstract class Shape
    {
        public string Name { get; set; }
        public Shape() : this("no name") { }
        public Shape(string name )
        {
            Name = name;
        }
        public abstract void  Draw();

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
