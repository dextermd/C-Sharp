using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class PersonTwo
    {
        public string Name {  get; set; }

        public PersonTwo(string name) => Name = name;
        public override string ToString() => Name;
    }
}
