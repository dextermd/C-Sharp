using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ls_8
{
    public static class PointExtension
    {
        public static double Distance(this Point a, Point b) 
        {
            //return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)); // using static System.Math;
            return Sqrt(Pow(b.X - a.X, 2) + Pow(b.Y - a.Y, 2));
        }

        
    }
}
