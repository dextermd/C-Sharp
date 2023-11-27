using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_7
{
    internal class Rectangle
    {
        public int Perimetr {
            get
            {
                return 2 * (width + height);
            }
        }

        public int Square { get => width * height; }

        private int height;
        public int Height
        {
            get { return height; }
            set {
                if (value < 0) 
                {
                    throw new ArgumentException($"Отрицательное значение высоты: {nameof(value)} {value}");
                }
                height = value;
                
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public Rectangle(int height = 1, int width = 1) 
        { 
            this.Height = height;
            this.Width = width;
        }

        public Rectangle(Rectangle obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} Нулевая сылка!");
            }
            width = obj.Width;
            height = obj.Height;
        }

        public override string ToString()
        {
            return $"Высота: {height} Ширина: {width}";
        }
        
    }
}
