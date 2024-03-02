namespace Use_HomeAppliances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HomeAppliances> appliances = new List<HomeAppliances>
            {
                new HomeAppliances("D101B","Dishwasher", "BOSCH",   "White", 979.50, 5),
                new HomeAppliances("D102S","Dishwasher", "Samsung", "White", 609.80, 10),
                new HomeAppliances("D103M","Dishwasher", "Miele",   "Silver", 1199.70, 3),
                new HomeAppliances("F101B","Fridge", "BOSCH",   "Silver", 490.50, 15),
                new HomeAppliances("F102S","Fridge", "Samsung",   "White", 399.50, 10),
                new HomeAppliances("F103B","Fridge", "BOSCH",   "Silver", 450.50, 15),
                new HomeAppliances("F104P","Fridge", "Philips",   "Black", 490.50, 15),
                new HomeAppliances("D104E","Dishwasher", "Electrolux", "White", 389.70, 5),
                new HomeAppliances("D105S","Dishwasher", "Samsung",   "Black", 545.50, 4),
                new HomeAppliances("C101M","CoffeeMachine", "Miele",   "Black", 500.50, 3),
                new HomeAppliances("C102S","CoffeeMachine", "Siemens",   "Silver", 470.50, 8),
                new HomeAppliances("C103D","CoffeeMachine", "Delonghi",   "Black", 510.80, 5),
                new HomeAppliances("C104M","CoffeeMachine", "Miele",   "White", 600.10, 9),
                new HomeAppliances("D106E","Dishwasher", "Electrolux",   "Black", 410.50, 5),
                new HomeAppliances("D107M","Dishwasher", "Miele",   "White", 1000.50, 5),
                new HomeAppliances("D108S","Dishwasher", "Siemens",   "Silver", 600.8, 5),
                new HomeAppliances("C105D","CoffeeMachine", "Delonghi",   "White", 480.50, 5),
                new HomeAppliances("C105P","CoffeeMachine", "Philips",   "Black", 430.50, 5),
                new HomeAppliances("C106S","CoffeeMachine", "Siemens",   "Silver", 410.50, 3),
                new HomeAppliances("D108B","Dishwasher", "BOSCH",   "Blue",785.5, 5),
                new HomeAppliances("F105S","Fridge", "Siemens",   "Silver", 600.50, 5),
                new HomeAppliances("F106M","Fridge", "Miele",   "Black", 1000.50, 7),
                new HomeAppliances("F107S","Fridge", "Samsung",   "Black", 410.50, 9),
                new HomeAppliances("F108E","Fridge", "Electrolux",   "White", 410.50, 3),
            };

            foreach (HomeAppliances item in appliances)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------------------");

            /*
            Есть список бытовой техники. 
                1. Выбрать товар по категории
                2. Выбрать товар по категории и отсортировать по производителю
                3. Выбрать товар по категории и определенному производителю c 
                  сортировкой по цене в порядке возрастания
             */


            // 1. Выбрать товар по категории
            string key = "CoffeeMachine";

            /*var*/IEnumerable<HomeAppliances> query = from tovar in appliances
                        where tovar.category == key
                        select tovar;

            Console.WriteLine($"Выбран товар по категории: {key}");

            foreach (var item in query)
            {
                //Console.WriteLine(item);
                Console.WriteLine($"\t{item.manufacturer,-15} {item.price,10:F2}");
            }
            Console.WriteLine();


            //2. Выбрать товар по категории и отсортировать по производителю
            var query2 = from tovar in appliances
                         orderby tovar.manufacturer
                         where tovar.category == key
                         select tovar;

            Console.WriteLine($"Выбран товар по категории и отсортирован по производителю: {key}");

            foreach (var item in query2)
            {
                //Console.WriteLine(item);
                Console.WriteLine($"\t{item.manufacturer,-15} {item.price,10:F2}");
            }
            Console.WriteLine();


            //3.Выбрать товар по категории и определенному производителю c
            //    сортировкой по цене в порядке возрастания

            var query3 = from tovar in appliances
                         orderby tovar.manufacturer /*descending*/, tovar.price descending
                         where tovar.category == key
                         select tovar;
            
            Console.WriteLine($"\nВыбран товар по категории и отсортирован по производителю: {key}");

            foreach (var item in query3)
            {
                //Console.WriteLine(item);
                Console.WriteLine($"\t{item.manufacturer,-15} {item.price,10:F2}");
            }

            Console.Read();
        }
    }
    record HomeAppliances(string cod, string category, string manufacturer, string color, double price, int inStock)
    {
        public override string ToString()
        {
            return $"{this.manufacturer,-15}{this.category,-15}{color,-8}{price,10:F2}{inStock,6}";
        }
    }
}