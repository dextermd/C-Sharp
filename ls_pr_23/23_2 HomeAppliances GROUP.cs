namespace _23_1_Use_LLINQ
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

            //Сделать запрос по производителю(группировка)

            var query = from tovar in appliances
                        group tovar by tovar.Manufacturer;

            foreach (/*var*/IGrouping<string, HomeAppliances> manufactirer in query)
            {
                Console.WriteLine($"{manufactirer.Key}");
                foreach (var item in manufactirer)
                {
                    // Console.WriteLine($"\t{item}");
                    Console.WriteLine($"\t{item.Category,-15}{item.Color,-8}{item.Price,10:F2}{item.InStock,6}");
                }
            }
            Console.WriteLine("-------------------------------------------");
            //------------------------------------------------------------------
            //Сделать запрос по категории с сортировкой по производителю(группировка)

            var query2 = from tovar in appliances
                         orderby tovar.Manufacturer
                         group tovar by tovar.Category;

            foreach (/*var*/IGrouping<string, HomeAppliances> manufactirer in query2)
            {
                Console.WriteLine($"{manufactirer.Key}");
                foreach (var item in manufactirer)
                {
                    Console.WriteLine($"\t{item}");
                    //Console.WriteLine($"\t{item.Category,-15}{item.Color,-8}{item.Price,10:F2}{item.InStock,6}");
                }
            }

            //----------------------------------------------------------------------------
            Console.WriteLine("===============================================");
            

	    // На занятии не рассматривали:
            // Сделать запрос на группировку по категории с сортировкой по производителю,
            // с отделением производителей в  каждой категории

            var result = from tovar in appliances
                         orderby tovar.Category, tovar.Manufacturer
                         group tovar by tovar.Category into categoryGroup
                         select new
                         {
                             Category = categoryGroup.Key,
                             Items = from item in categoryGroup
                                      group item by item.Manufacturer into manufacturerGroup
                                      select new
                                      {
                                          Manufacturer = manufacturerGroup.Key,
                                          Products = manufacturerGroup.ToList()
                                      }
                         };

            foreach (var group in result)
            {
                Console.WriteLine($"{group.Category}:");

                foreach (var manufacturerGroup in group.Items)
                {
                    Console.WriteLine($"\t{manufacturerGroup.Manufacturer}:");

                    foreach (var item in manufacturerGroup.Products)
                    {
                        Console.WriteLine($"\t\t\t{item.Color}\t{item.Price}\t{item.InStock}");
                    }
                }

                Console.WriteLine("---------------------");
            }

            Console.Read();
            }
        }
        record HomeAppliances(string Cod, string Category, string Manufacturer, string Color, double Price, int InStock)
        {
            public override string ToString()
            {
                return $"{this.Manufacturer,-15}{this.Category,-15}{Color,-8}{Price,10:F2}{InStock,6}";
            }
        }
    } 
