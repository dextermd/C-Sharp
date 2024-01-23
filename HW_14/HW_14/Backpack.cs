using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14
{
    internal class Backpack
    {
        public string color { get; set; }
        public string manufacturer { get; set; }
        public string material { get; set; }
        public double weight { get; set; }
        public double volume { get; set; }
        public List<Item> contents { get; set; }

        public event EventHandler<BackpackEventArgs> BackpackAddItemEvent;

        public Backpack()
        {
            color = "No Color";
            manufacturer = "No Manufacturer";
            material = "No Material";
            weight = 0;
            volume = 0;
            contents = new List<Item>();
        }
        public Backpack(string color, string manufacturer, string material, double weight, double volume)
        {
            this.color = color;
            this.manufacturer = manufacturer;
            this.material = material;
            this.weight = weight;
            this.volume = volume;
        }
        public void OnBackpackAddItemEvent(Item item)
        {
            BackpackEventArgs args = new BackpackEventArgs();

            if (BackpackAddItemEvent != null)
            {
                args.name = item.name;
                args.volume = item.volume;

            }
            BackpackAddItemEvent.Invoke(this, args);
        }

        public override string ToString()
        {
            string contentsString = string.Join(", ", contents?.Select(item => $"{item?.name} ({item?.volume})") ?? Enumerable.Empty<string>());
            return $"Color          : {color}\n" +
                   $"Manufacturer   : {manufacturer}\n" +
                   $"Material       : {material}\n" +
                   $"Weight         : {weight}\n" +
                   $"Volume         : {volume}\n" +
                   $"Contents       : {contentsString}";
        }


    }
}
