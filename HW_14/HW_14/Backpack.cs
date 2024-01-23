using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            contents = new List<Item>();
        }
        public void AddItemHandler(object sender, BackpackEventArgs args)
        {
            Item item = new Item();
            item.name = args.name;
            item.volume = args.volume;

            try
            {
                AddItem(args.name, args.volume);
                Console.WriteLine($"\nДобавили: {args.name} Объем: {args.volume}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public override string ToString()
        {
            string contentsString = string.Join(", ", contents?.Select(item => $"{item?.name} ({item?.volume})") ?? Enumerable.Empty<string>());
            return $"\nColor          : {color}\n" +
                   $"Manufacturer   : {manufacturer}\n" +
                   $"Material       : {material}\n" +
                   $"Weight         : {weight}\n" +
                   $"Volume         : {volume}\n" +
                   $"Contents       : {contentsString}";
        }

        private void AddItem(string itemName, double itemVolume)
        {
            Item item = new Item();
            item.name = itemName;
            item.volume = itemVolume;

            if (volume >= itemVolume)
            {
                contents.Add(item);
                volume -= itemVolume;
            }
            else
            {
                string errorMessage = $"\nПредмет {itemName} с объемом {itemVolume} не помещается в рюкзак с объемом {volume}";
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
