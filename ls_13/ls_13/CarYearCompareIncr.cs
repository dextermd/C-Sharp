using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    internal class CarYearCompareIncr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Car && y is Car)
            {
                return (int)(x as Car).CarInformation.Year - (int)(y as Car).CarInformation.Year;
            }

            throw new NotImplementedException();
        }
    }
}
