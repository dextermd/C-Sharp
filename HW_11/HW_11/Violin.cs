using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Violin : MusicalInstrument
    {
        public Violin() : base() { }
        public Violin(string name, string descR)
        {
            Name = name;
            DescR = descR;
        }
        public override void Sound() { Console.WriteLine("Violin sound"); }
        public override void Show() { base.Show(); }
        public override void Desc() { base.Desc(); }
        public override void History() { Console.WriteLine("History of the violin"); }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
