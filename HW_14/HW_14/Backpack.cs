using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14
{
    delegate void BackpackDelegate(object sender, CardArgs args);
    internal class Backpack
    {
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public List<Item> Contents { get; set; }

        public Backpack()
        {
            Color = "No Color";
            Manufacturer = "No Manufacturer";
            Material = "No Material";
            Weight = 0;
            Volume = 0;
        }
        public Backpack(string color, string manufacturer, string material, double weight, double volume, List<Item> list)
        {
            Color = color;
            Manufacturer = manufacturer;
            Material = material;
            Weight = weight;
            Volume = volume;
            Contents = list;
        }

        public override string ToString()
        {
            string contentsString = string.Join(", ", Contents.Select(item => $"{item.Name} ({item.Volume})"));
            return $"Color          : {Color}\n" +
                   $"Manufacturer   : {Manufacturer}\n" +
                   $"Material       : {Material}\n" +
                   $"Weight         : {Weight}\n" +
                   $"Volume         : {Volume}\n" +
                   $"Contents       : {contentsString}";
        }


    }
}
