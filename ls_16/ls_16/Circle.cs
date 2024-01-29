using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_16
{
    internal class Circle : IShapeArea<Circle>
    {
        public double Radius { get; set; }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
