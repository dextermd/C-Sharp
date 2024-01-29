using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_16
{
    internal class PointT<T> //where T : struct  // class - ошибки на этапе компиляции
    {
        private T x;
        private T y;
        public PointT()
        {
            this.x = default(T);
            this.y = default(T);
        }

        public PointT(T xVal, T yVal)
        {
            x = xVal;
            y = yVal;
        }

        // свойства
        public T X
        {
            get { return x; }
            set { x = value; }
        }

        public T Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return $"[{x} ; {y}]";
        }

        public void ResetPointT()
        {
            x = default(T);
            //default - ключевое слово перегружено для задания нулевого значения для соответствующего типа
            y = default(T);
        }

        public static PointT<T> operator+(PointT<T>p1, PointT<T> p2)
        {
            T resX = (dynamic)p1.X + p2.X; 
            T resY = (dynamic)p1.Y + p2.Y;
            return new PointT<T>(resX, resY);
        }
       
    }
}

