using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_8
{
    public class Point
    {
        private int x; // Поле
        public int X  // Свойство
        {
            get { return x; }
            set { x = value; }
        }
        private int y; //Поле
        public int Y  // Свойство
        {
            get { return y; }
            set { y = value; }
        }
        public Point() : this(1, 1) { } // Делегирующий конструктор без параметров Point()

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string Name { get; private set; }

        public Point(Point obj)
        {
            x = obj.x;
            y = obj.y;
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"[{X};{Y}]";
        }

    }
}
