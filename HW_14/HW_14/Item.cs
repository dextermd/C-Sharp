using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW_14
{
    internal class Item
    {
        public string name { get; set; }
        public double volume { get; set; }

        public event EventHandler<BackpackEventArgs> AddItemEvent;

        public void OnAddItemEvent(string name, double volume)
        {
            BackpackEventArgs args = new BackpackEventArgs();
            if (AddItemEvent != null)
            {
                args.name = name;
                args.volume = volume;
                AddItemEvent(this, args);
            }
        }
        public override string ToString()
        {
            return $"\nItem {name} Volume: {volume}";
        }
    }
}
