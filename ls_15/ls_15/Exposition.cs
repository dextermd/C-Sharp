using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    delegate void ExpositionEventHandler(object sender, ExpositionEventHandlerArgs args);
    internal class Exposition
    {
        public event ExpositionEventHandler expositionEvent;

        public void OnExpositionEvent(DateTime date, string themeOfExposition)
        {
            ExpositionEventHandlerArgs args = new ExpositionEventHandlerArgs();

            if (expositionEvent != null )
            {
                args.date = date;
                args.themeOfExposition = themeOfExposition;

                expositionEvent.Invoke(this, args);
            }
        }
    }
}
