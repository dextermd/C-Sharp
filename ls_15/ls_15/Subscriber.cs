using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ls_15
{
    internal class Subscriber
    {
        public string name { get; set; } // автоматическое свойство
        public string phone { get; set; }  // автоматическое свойство

        public Subscriber(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void SubscriberHandler(object sender, ExpositionEventHandlerArgs args)
        {
            Console.WriteLine($"\nПодписчик: {name} Телефон: {phone}\n" +
                              $"Тема выставки: {args.themeOfExposition}\n" +
                              $"Дата выставки: {args.date}\n");
        }
        public override string ToString()
        {
            return $"\nПодписчик: {name} Телефон: {phone}";
        }
    }
}
