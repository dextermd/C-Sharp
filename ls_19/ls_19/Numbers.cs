using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class Numbers
    {
        int n;
        public Numbers(int n = 1) => this.n = n;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i <= n; i++)
            {
                yield return i * i;
            }
        }
    }
}
