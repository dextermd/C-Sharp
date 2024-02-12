using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class Point3D : IEnumerable<int>
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
