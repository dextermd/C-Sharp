using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
    delegate void KeyEventHandler(object sender, KeyEventAgrs e);
    internal class KeyEvent
    {
        //public event EventHandler<KeyEventAgrs> KeyPress;
        public event KeyEventHandler KeyPress;

        public void OnKeyPress(char k) 
        {
            KeyEventAgrs agrs = new KeyEventAgrs();
            if (KeyPress != null)
            {
                agrs.Key = k;
                KeyPress(this, agrs);
            }
        }
    }
    
}
