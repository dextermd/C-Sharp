namespace Проверка_наличия
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if true
            //--------------------All-------------------------------------------------
            //Метод All() проверяет, соответствуют ли все элементы условию.
            //Если все элементы соответствуют условию, то возвращается true.

            string[] people = { "Tom", "Tim", "Bob", "Sam" };

            // проверяем, все ли элементы имеют длину в 3 символа
            bool allHas3Chars = people.All(s => s.Length == 3);  // true
            Console.WriteLine(allHas3Chars);

            // проверяем, все ли строки начинаются на T
            bool allStartsWithT = people.All(s => s.StartsWith("T")); // false
            Console.WriteLine(allStartsWithT);
#endif

            //-----------------------Any----------------------------------------------
#if false
            //Метод Any() действует подобным образом, только возвращает true,
            //если хотя бы один элемент коллекции определенному условию.

            string[] people = { "Tom", "Tim", "Bob", "Sam" };

            // проверяем, все ли элементы имеют длину больше 3 символов
            bool allHasMore3Chars = people.Any(s => s.Length > 3);     // false
            Console.WriteLine(allHasMore3Chars);

            // проверяем, все ли строки начинаются на T
            bool allStartsWithT = people.Any(s => s.StartsWith("T"));   // true
            Console.WriteLine(allStartsWithT);
#endif

            //--------------------------Contains-------------------------------------------
#if false

            //Метод Contains() возвращает true, если коллекция содержит определенный элемент.

            string[] people = { "Tom", "Tim", "Bob", "Sam" };

            // проверяем, есть ли строка Tom
            bool hasTom = people.Contains("Tom");     // true
            Console.WriteLine(hasTom);

            // проверяем, есть ли строка Mike
            bool hasMike = people.Contains("Mike");     // false
            Console.WriteLine(hasMike);

#endif

#if false
            //-------------------Contains---------------Equals----------------------------

            /*
             Для сравнения объектов применяется реализация метода Equals. 
             Соответственно если мы работаем с объектами своих типов, 
             то надо реализовать данный метод             
             */

            Person[] people = { new Person("Tom"), new Person("Sam"), new Person("Bob") };

            var tom = new Person("Tom");
            var mike = new Person("Mike");

            // проверяем, есть ли Tom
            bool hasTom = people.Contains(tom);     // true
            Console.WriteLine(hasTom);

            // проверяем, есть ли строка Mike
            bool hasMike = people.Contains(mike);     // false
            Console.WriteLine(hasMike);
#endif

#if false

            //--------------------------First-------------------------------------------
            //Метод First() возвращает первый элемент последовательности

            string[] people = { "Tom", "Bob", "Tim", "Kate", "Sam" };

            // проверяем, есть ли строка Tom
            var first = people.First();  // Tom
            Console.WriteLine(first);

            //В метод First можно передать метод, который представляет условие:
            // первая строка, длина которой равна 4 символам

            var firstWith4Chars = people.First(s => s.Length == 4);  // Kate
            Console.WriteLine(firstWith4Chars);

            //Если коллекция пуста или в коллекции нет элементов,
            //который соответствуют условию, то будет сгенерировано исключение.

#endif

#if false

            //--------------------------FirstOrDefault-------------------------------------------
            //Метод FirstOrDefault() также возвращает первый элемент и также может принимать условие,
            //только если коллекция пуста или в коллекции не окажется элементов,
            //которые соответствуют условию, то метод возвращает значение по умолчанию

            string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

            // первый элемент
            var first = people.FirstOrDefault();  // Tom
            Console.WriteLine(first);

            // первая строка, длина которой равна 4 символам
            var firstWith4Chars = people.FirstOrDefault(s => s.Length == 4);  // Kate
            Console.WriteLine(firstWith4Chars);

            // первый элемент из пустой коллекции
            var firstOrDefault = new string[] { }.FirstOrDefault();
            Console.WriteLine(firstOrDefault);  // null

#endif

#if false

            //--------------------------Last и LastOrDefault----------------------------------
            /*
             Метод Last() аналогичен по работе методу First, только возвращает последний элемент. 
             Если коллекция не содержит элемент, который соответствуют условию, 
             или вообще пуста, то метод генерирует исключение.
             */

            string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

            string last = people.Last();
            Console.WriteLine(last); // Sam

            string lastWith4Chars = people.Last(s => s.Length == 4);
            Console.WriteLine(lastWith4Chars); // Mike
            Console.WriteLine();
#endif

#if false

            /*
             Метод LastOrDefault() возвращает последний элемент или значение по умолчанию, 
            если коллекция не содержит элемент, который соответствуют условию, или вообще пуста:
             */
            string[] people = { "Tom", "Bob", "Kate", "Tim", "Mike", "Sam" };

            string? last = people.LastOrDefault();
            Console.WriteLine(last); // Sam

            string? lastWith4Chars = people.LastOrDefault(s => s.Length == 4);
            Console.WriteLine(lastWith4Chars); // Mike

            string? lastWith5Chars = people.LastOrDefault(s => s.Length == 5);
            Console.WriteLine(lastWith5Chars); // null

            string? lastWith5CharsOrDefault = people.LastOrDefault(s => s.Length == 5, "Undefined");
            Console.WriteLine(lastWith5CharsOrDefault); // Undefined

            // первый элемент из пустой коллекции строк
            string? lastOrDefault = new string[] { }.LastOrDefault("hello");
            Console.WriteLine(lastOrDefault);  // hello

#endif

            Console.Read();
        }
    }

    class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;

        public override bool Equals(object? obj)
        {
            if (obj is Person person) return Name == person.Name;
            return false;
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
}