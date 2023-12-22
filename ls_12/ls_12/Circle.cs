using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ls_12
{
    internal class Circle : Shape, IArea, IPerimeter
    {
        public double Radius { get; set; }

        public Circle(string name="Circle", double radius = 0.0) : base(name) => Radius = radius;

        public override void Draw()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Рисуем круг");
        }
        public override string ToString()
        {
            return base.ToString() + $"  Radius: {Radius}";
        }
        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
