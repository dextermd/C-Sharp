using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    internal class ExpositionEventHandlerArgs : EventArgs
    {
        public DateTime date { get; set; }
        public string themeOfExposition;
    }
}
