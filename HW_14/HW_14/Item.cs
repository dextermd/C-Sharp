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

        public Item(string name, double volume)
        {
            this.name = name;
            this.volume = volume;
        }

        public void ItemHandler(object sender, BackpackEventArgs args)
        {
            Console.WriteLine($"Добавлен: {args.name}, обьем: {args.volume}");
        }
        public override string ToString()
        {
            return $"\nItem {name} Volume: {volume}";
        }
    }
}
