using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class BookNameCompareIncr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Book && y is Book)
            {
                return string.Compare((x as Book).BookName, (y as Book).BookName);
            }
            throw new NotImplementedException();
        }
    }
}
