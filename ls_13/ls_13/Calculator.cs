using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    public delegate double CalcDelegate(double x, double y); // обьявление делегата 
    internal class Calculator
    {
        public double Add(double x, double y)
        {
            //Console.WriteLine($"{x} + {y} = {x+y}");
            return x + y;
        }

        public static double Sub(double x, double y) //static
        {
            //Console.WriteLine($"{x} - {y} = {x - y}");
            return x - y;
        }

        public double Mult(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            throw new DivideByZeroException();
        }
    }
}

