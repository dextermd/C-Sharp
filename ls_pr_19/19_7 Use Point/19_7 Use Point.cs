using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_7_Use_Point
{
    internal class Program
    {
        class Point3D:IEnumerable<int>
        {
            public int X { get; set; }
            public int Y{ get; set; }
            public int Z { get; set; }

            public IEnumerator<int> GetEnumerator()
            {
                yield return X;
                yield return Y;
                yield return Z;
                //throw new NotImplementedException();
            }

            public override string ToString()
            {
                return $"[{X}, {Y}, {Z}]";
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
               return GetEnumerator();
                // throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {

            Point3D p = new Point3D() { X = 125, Y=6, Z=-125};

            foreach (var item in p)
            {
                Console.WriteLine($"{item}  ");
            }



            Console.Read();
        }
    }
}
