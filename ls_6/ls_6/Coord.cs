using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_6
{
    internal class Coord
    {
        static int Count = 0; // private -  по умолчанию
        private double x;
        private double y;
        private double z;

        public static int MAX = 500;
        public readonly string name = "no name"; // readonly - толко для чтение, но в конструкторах его можно менять.
        public const int MIN = -500; // const - по умолчанию это static

        public Coord()
        {
            x = 0;
            y = 0;
            z = 0;
            Count++;

        }
        public Coord(double _x, double y, double z)
        {
            name = "центр круга"; // readonly - толко для чтение, но в конструкторах его можно менять.
            x = _x;
            this.y = y;
            this.z = z;
            Count++;

        }   

        public void SetX(double _x)
        {
            //this.x = x; 
            if (_x < MAX) x = _x;
            else x = MAX;
        }

        public double GetX()
        {
            return x;
        }

        public void SetY(double y) => this.y = y;
        public double GetY() => y;

        public void SetZ(double z) => this.z = z;
        public double GetZ() => z;

        //public static int GetCount() => Count;
        public static int GetCount() // В статическом методе нет доступа по this
        {
            return Count;
        }

        public Coord(Coord obj)
        {
            this.x = obj.x; 
            this.y = obj.y; 
            this.z = obj.z;
            Count++;
        }
        public Coord Copy()
        {
            //return new Coord(x, y, z);
            return new Coord(this);
        }

        public void Show()
        {
            Console.WriteLine($"[{x:F2}, {y:F2}, {z:F2}]");
        }

        public void Deconstruct(out double x, out double y, out double z)
        {
            x = this.x; y = this.y; z = this.z;
        }

        ~Coord() 
        {
            Console.WriteLine("Деструктор"); 
            
        }
    }
}
