using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
    internal class ProcessKey
    {
        public void KeyHandler(object sender, KeyEventAgrs e)
        {
            Console.WriteLine($"Нажата клавиша: {e.Key}");
        }
    }
}
