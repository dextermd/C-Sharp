using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class PriceCompareIncr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Book && y is Book)
            {
                return (int)(x as Book).BookDetails.Price - (int)(y as Book).BookDetails.Price;
            }
            throw new NotImplementedException();
        }
    }
}
