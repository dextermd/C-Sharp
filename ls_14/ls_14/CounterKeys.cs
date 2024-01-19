using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
    internal class CounterKeys
    {
        public int Count = 0;
        public void KeyHandler(object sender, KeyEventAgrs e)
        {
            Count++;
        }
    }
}
