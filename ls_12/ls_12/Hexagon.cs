using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Hexagon : Shape, IPointy, IDraw3D, IColorDraw
    {
        public double Side { get; set; }

        public byte Points => 6;

        public Hexagon(string name="Hexagon", double side = 1.0) : base(name) => Side = side;
        public override void Draw()
        {
            Console.WriteLine("Рисуем шестиугольник");
        }
        void IDraw3D.Draw() 
        {
            Console.WriteLine("Рисуем шестиугольник 3D");
        }
        void IColorDraw.Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Рисуем шестиугольник в цвете");
            Console.ResetColor();
        }
        public override string ToString()
        {
            return base.ToString() + $" Side: {Side}";
        }
    }
}
