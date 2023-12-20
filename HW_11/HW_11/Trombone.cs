using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Trombone : MusicalInstrument
    {
        public Trombone() : base() { }
        public Trombone(string name, string descR)
        {
            Name = name;
            DescR = descR;
        }
        public override void Sound() { Console.WriteLine("Trombone sound"); }
        public override void Show() { base.Show(); }
        public override void Desc() { base.Desc(); }
        public override void History() { Console.WriteLine("History of the trombone"); }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
