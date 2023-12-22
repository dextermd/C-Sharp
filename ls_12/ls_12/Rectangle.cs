using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Rectangle:Shape, IArea, IPerimeter, IPointy
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public byte Points => 4;

        public Rectangle(string name="Прямоугольник", double height=1.0, double width = 1.0):base(name)
        {
            Height = height;
            Width = width;                
        }

        public override void Draw()
        {
            Console.WriteLine("Рисуем Прямоугольник");
        }
        public override string ToString()
        {
            return base.ToString()+$" Height: {Height} Width: {Width}";
        }

        public double Area()
        {
            return Height * Width;
        }

        public double Perimeter()
        {
            return Width * Height;
        }
    }
}
