using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_10
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
        public static Point operator ++(Point a)
        {
            return new Point() { X = a.X + 1, Y = a.Y + 1}; 
        }
        public static Point operator --(Point a)
        {
            return new Point() { X = a.X - 1, Y = a.Y - 1 };
        }
        public static Point operator -(Point a)
        {
            return new Point() { X = -a.x , Y = -a.y };
        }
        public static Point operator +(Point a)
        {
            return new Point() { X = +a.x, Y = +a.y };
        }
        public static Point operator+(Point a,  Point b)
        {
            return new Point() { X = a.X + b.X, Y = a.Y + b.Y };
        }
        public static Point operator +(Point a, int b)
        {
            return new Point() { X = a.X + b, Y = a.Y + b };
        }
        public static Point operator +(int a, Point b)
        {
            return new Point() { X = a + b.X, Y = a + b.Y };
        }
        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }
        public override bool Equals(object obj)
        {
            //return obj is Point && Equals((Point)obj);
            return obj.ToString() == this.ToString();

            //Point point = (Point)obj;
            //return point.X == this.X && point.Y == this.Y;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator >(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) > Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
            //return (a.X + a.Y) > (b.X + b.Y);
        }
        public static bool operator <(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X, 2) + Math.Pow(a.Y, 2)) < Math.Sqrt(Math.Pow(b.X, 2) + Math.Pow(b.Y, 2));
            //return (a.X + a.Y) < (b.X + b.Y);
        }

        public static bool operator true(Point p)
        {
            if ((p.X < 0 || p.Y < 0 ) || (p.X > 0 || p.Y > 0))
                return true;
            return false;
        }
        public static bool operator false(Point p)
        {
            return p.X == 0 && p.Y == 0 ? true : false;
        }
        public static Point operator&(Point a, Point b)
        {
            if (a.X != 0 || b.X == 0 || a.Y == 0 || b.Y == 0)
                return a;
            return new Point();
        }
        public static Point operator |(Point a, Point b)
        {
            if (a.X != 0 && b.X == 0 && a.Y == 0 && b.Y == 0)
                return b;
            return new Point();
        }
        public static implicit operator int(Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator Point(string str)
        {
            string[] parts = str.Split(';', ',', ':', '_');
            return new Point()
            {
                X = int.Parse(parts[0]),
                Y = int.Parse(parts[1])
            };
        }
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x; 
                    case 1: return y;
                    default: throw new IndexOutOfRangeException($"Несуществующий индекс {index}");

                }
            }
            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    default: throw new IndexOutOfRangeException($"Несуществующий индекс {index}");

                }
            }
        }
    }
}
