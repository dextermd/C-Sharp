using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Ukulele : MusicalInstrument
    {
        public Ukulele() : base() { }
        public Ukulele(string name, string descR)
        {
            Name = name;
            DescR = descR;
        }
        public override void Sound() { Console.WriteLine("Ukulele sound"); }
        public override void Show() { base.Show(); }
        public override void Desc() { base.Desc(); }
        public override void History() { Console.WriteLine("History of the ukulele"); }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
