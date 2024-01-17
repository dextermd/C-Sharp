using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class GenreCompareDecr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Book && y is Book)
            {
                return string.Compare((y as Book).BookDetails.Genre, (x as Book).BookDetails.Genre);
            }
            throw new NotImplementedException();
        }
    }
}
