using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class AuthorCompareDecr : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Book && y is Book)
            {
                return string.Compare((y as Book).Author, (x as Book).Author);
            }
            throw new NotImplementedException();
        }

    }
}
