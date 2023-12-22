using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Triangle : Shape, IPointy
    {
        public double Side { get; set; }
        public double Height { get; set; }

        public byte Points => 3;

        public Triangle(string name, double side, double height):base(name)
        {
            Side = side;
            Height = height;    
        }

        public override void Draw()
        {
            Console.WriteLine("Рисуем Треугольник");
        }
        public override string ToString()
        {
            return base.ToString() + $"  Side: {Side}  Height: {Height}";
        }

    }
}
