using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_16
{
    public delegate T MathOperation<T>(T x, T y);
    public class TestClass
    {
        // public delegate T MathOperation<T>(T x, T y);
        public int AddInt(int x, int y) => x + y;
        public int SubInt(int x, int y) => x - y;
        public int MultInt(int x, int y) => x * y;
        public double AddDouble(double x, double y) => x + y;
        public double MultDouble(double x, double y) => x * y;
        public static char AddChar(char x, char y) => (char)(x + y);
        public double Average(int x, int y) => (x + y) / 2.0; // подходит только для Func в данном случае
    }
}
