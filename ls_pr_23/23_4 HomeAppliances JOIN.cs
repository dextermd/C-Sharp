namespace _23_3_Use_LINQ_Соединение
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


            List<Stock> stocks = new List<Stock>
            {
                new Stock("D101B",3),
                new Stock("D102S",10),
                new Stock("D103M",9),
                new Stock("F101B",6),
                new Stock("F102S",0),
                new Stock("F103B",15),
                new Stock("F104P",3),
                new Stock("D104E",0),
                new Stock("D105S",7),
                new Stock("C101M",3),
                new Stock("C102S",21),
                new Stock("C103D",3),
                new Stock("C104M",17),
                new Stock("D106E",5),
                new Stock("D107M",0),
                new Stock("D108S",8),
                new Stock("C105D",14),
                new Stock("C105P",30),
                new Stock("C106S",11),
                new Stock("D108B",2),
                new Stock("F105S",0),
                new Stock("F106M",1),
                new Stock("F107S",11),
                new Stock("F108E",4),
            };

            foreach (HomeAppliances item in appliances)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------------------");

            //Получить остатки на складе по категории (+ сортировка по категории):
            var query = from tovar1 in appliances
                        orderby tovar1.Category
                        join tovar2 in stocks
                        on tovar1.Cod equals tovar2.cod
                        select new
                        {
                            TovarName = tovar1.Category,
                            TovarManuf = tovar1.Manufacturer,
                            TovarQuantity = tovar2.quantity
                        };


            foreach (var item in query)
            {
                Console.WriteLine($"{item.TovarName,-20}{item.TovarManuf,-10}{item.TovarQuantity} ");
            }
            Console.WriteLine("----------------------------------------------------");



            //Получить остатки на складе по категории (+ сортировка по категории)
            //***Также сгруппировать по категории.
            // (***Запрос мы не завершили на занятии)

            var query2 = from tovar1 in appliances
                         orderby tovar1.Category, tovar1.Manufacturer
                         join tovar2 in stocks
                         on tovar1.Cod equals tovar2.cod
                         group new { tovar1.Cod, tovar1.Category, tovar1.Manufacturer, tovar2.quantity } by tovar1.Category
                         into groupedTovars
                         select new
                         {
                             Category = groupedTovars.Key,
                             Tovars = groupedTovars.ToList()
                         };

            foreach (var categoryGroup in query2)
            {
                Console.WriteLine($"Category: {categoryGroup.Category}");

                foreach (var tovar in categoryGroup.Tovars)
                {
                    Console.WriteLine($"\t{tovar.Manufacturer,-15} код:[{tovar.Cod,5}] {tovar.quantity,10}");
                }
                Console.WriteLine();
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
        record Stock(string cod, int quantity);
    }
