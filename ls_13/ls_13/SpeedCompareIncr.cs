using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    internal class SpeedCompareIncr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Car && y is Car)
            {
                return (int)(x as Car).Speed - (int)(y as Car).Speed;
            }

            throw new NotImplementedException();
        }
    }
}
