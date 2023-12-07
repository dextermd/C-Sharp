using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{

    public class MyException : ApplicationException
    {
        public int Num { get; private set; }
        public MyException(string message, int num) : base(message) 
        {
            Num = num;
        }

        public override string Message
        {
            get { return $"Ошибка: {Num} - Отрицательное значение координаты!"; }
        }

    }


}
