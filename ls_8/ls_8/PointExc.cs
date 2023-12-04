using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_8
{
    internal class PointExc : ApplicationException
    {
        // 1 Вариант -------------------------------------------------------------------------------------

        //private string message;
        //public int XErr { get; private set; }
        //public int YErr { get; private set; }
        //public DateTime DateException { get;}

        //public PointExc(string message, int x, int y) 
        //{
        //    XErr = x;
        //    YErr = y;
        //    this.message = message;
        //    DateException = DateTime.Now;
        //}
        //public override string Message 
        //{ 
        //    get { return $"Отрицательное значение координаты!"; } 
        //}  

        // 2 Вариант --------------------------------------------------------------------------------------

        public int XErr { get; private set; }
        public int YErr { get; private set; }
        public DateTime DateException { get; }
        public PointExc(string message, int x, int y) : base(message)
        {
            XErr = x;
            YErr = y;
            DateException = DateTime.Now;
        }
        public override string Message
        {
            get { return $"Отрицательное значение координаты!"; }
        }

        // 3 Вариант --------------------------------------------------------------------------------------

    }
}
