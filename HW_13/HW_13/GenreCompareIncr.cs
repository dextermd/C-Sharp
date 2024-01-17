using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class GenreCompareIncr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Book && y is Book)
            {
                return string.Compare((x as Book).BookDetails.Genre, (y as Book).BookDetails.Genre);
            }
            throw new NotImplementedException();
        }
    }
}
