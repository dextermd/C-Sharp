using System;

namespace ls_23
{

    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            Person[] people = {
                new Person("Alex", "Microsoft"), new Person("Tudor", "Google"),
                new Person("Boris", "JetBrains"), new Person("Elena", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Timur", "Microsoft")
            };

            var query = from person in people
                        group person by person.Company;

            // или

            var query2 = people.GroupBy(person => person.Company);

            foreach (IGrouping<string, Person> company in query)
            {
                Console.WriteLine($"\t\"{company.Key}\"");
                foreach (var person in company)
                {
                    Console.WriteLine($"{person.Name}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------------");

            //------------------------------------------------------
            //Сделать запрос и создать из группы новый объект:
            //количество Person в компании(Наименование и Количество)


            /*
             Результат:
                Microsoft : 3
                Google : 1
                JetBrains : 2
 
             */

            var query3 = from person in people
                         group person by person.Company
                         into g
                         select new
                         {
                             Name = g.Key,
                             Count = g.Count()
                         };

            // или

            var query4 = people.GroupBy(person => person.Company)
                               .Select(g => new
                               {
                                   Name = g.Key,
                                   Count = g.Count()
                               });

            foreach (var company in query4)
            {
                Console.WriteLine($"{company.Name} - {company.Count}");
            }
#endif

#if false
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

            // Сделать завпрос по производителю(групировка)

            var query = from tovar in appliances
                        group tovar by tovar.Manufacturer;

            foreach (var manufactirer in query)
            {
                Console.WriteLine($"{manufactirer.Key}");
                foreach (var item in manufactirer)
                {
                    //Console.WriteLine($"\t{item}");
                    Console.WriteLine($"\t{item.Category, -15}{item.Color, -8}{item.Price, -10:F2}{item.Cod, -5}");


                }
            }

            Console.WriteLine("---------------------------------------------------");

            // Сделать запрос по категории с сортировкой по производителю(группировка)

            var query2 = from tovar in appliances
                         orderby tovar.Manufacturer
                         group tovar by tovar.Category;

            foreach (IGrouping<string, HomeAppliances> manufactirer in query2)
            {
                Console.WriteLine($"{manufactirer.Key}");
                foreach (var item in manufactirer)
                {
                    Console.WriteLine($"\t{item}");
                    //Console.WriteLine($"\t{item.Category,-15}{item.Color,-8}{item.Price,-10:F2}{item.Cod,-5}");
                }
            }

#endif

#if false
            Person[] people = {
                new Person("Alex", "Microsoft"), new Person("Tudor", "Google"),
                new Person("Boris", "JetBrains"), new Person("Elena", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Timur", "Microsoft")
            };

           Company[] companies =
           {
               new Company("Microsoft", "C#"),
               new Company("Google", "Go"),
               new Company("Oracle", "Java")
           };

            // Cоединение по компаниям
            var empls = from p in people
                        join c in companies
                        on p.Company equals c.Title
                        select new
                        {
                            Name = p.Name,
                            Company = p.Company,
                            Lang = c.Language
                        };

            // или

            var query = people.Join(
                companies,
                p => p.Company,
                comp => comp.Title,
                (p, comp) => new
                {
                    Name = p.Name,
                    Company = p.Company,
                    Lang = comp.Language
                });

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} - {item.Company}({item.Lang})");
            }
#endif

#if false
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

            // Получить остатки на складе по категории ( + сортировка по категории)

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
                Console.WriteLine($"{item.TovarName, -20} {item.TovarManuf, -10} {item.TovarQuantity}");
            }
#endif

#if false
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("БАЗОВАЯ ИНФОРМАЦИЯ О СИСТЕМЕ:\n-----------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Операционная система: {Environment.OSVersion}" +
                $"\nВерсия .NET Framework: {Environment.Version}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИНФОРМАЦИЯ О СБОРКЕ МУСОРА:\n---------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Количество байт в куче: {GC.GetTotalMemory(false)} " +
                $"\nМаксимальное количество поддерживаемых поколений объектов: {GC.MaxGeneration + 1}");

            UserInfo user1 = new UserInfo("Alex", 26);
            Console.WriteLine($"\nПоколение объекта user1:  {GC.GetGeneration(user1)}");

            for (int i = 0; i < 50000; i++)
            {
                UserInfo user = new UserInfo("Kate", 27);
            }

            // Намеренно вызовем сборку мусора
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("\nсборка мусора ...\n");

            Console.WriteLine("Поколение объекта user1(после работы GC): " + GC.GetGeneration(user1));
#endif

#if false
            Console.WriteLine("Нажмите Enter для создания объектов...");
            Console.ReadLine();
            Test();

            Person[] obj = new Person[50];
            for (int i = 0; i < 50; i++)
                obj[i] = new Person(i + 1);

            // Посмотреть ildasm

            // Явный вызов сборщика мусора
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Объекты созданы. Нажмите Enter для завершения программы...");
#endif

            Console.Read();
        }
        public static void Test()
        {
            Person tom = new Person(111);
        }
    }
    class Person
    {
        public int Id { get; }
        public Person(int id) => Id = id;
        ~Person()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Объект {Id} уничтожен");
            Thread.Sleep(200);
        }
    }
    class UserInfo
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public UserInfo(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
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
    record class Company(string Title, string Language);
    record class Person(string Name, string Company);

}
