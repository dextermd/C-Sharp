using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_16
{
    public delegate void ShowOperation<T1, T2>(T1 x, T2 y);
    public class MyClass
    {
        // public delegate void ShowOperation<T1, T2>(T1 x, T2 y);
        public void AddInt(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
        public void SubInt(int x, int y) => Console.WriteLine($"{x} - {y} = {x - y}");
        public void MultInt(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");
        public void MultDouble(double x, double y) => Console.WriteLine($"{x} * {y} = {x * y:F2}");
    }
}
