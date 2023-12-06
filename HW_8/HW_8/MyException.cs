using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{

    public class MyException : Exception
    {
        public MyException(string message, int num) : base(message) {}

    }
}
