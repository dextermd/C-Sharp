namespace _23_9_разность_Пересечение_Объединение
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //----------Разность последовательностей--------Except------------------
            Console.WriteLine("\n---------Разность последовательностей--------------");
            
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            // разность последовательностей

            var resultExp = soft.Except(hard);

            foreach (string s in resultExp)
                Console.WriteLine(s);



            //----------Пересечение последовательностей------Intersect----------------

            Console.WriteLine("\n---------Пересечение последовательностей-----------");

            var resultInr = soft.Intersect(hard);

            foreach (string s in resultInr)
                Console.WriteLine(s);


            //----------Удаление дубликатов---------------Distinct--------------------
            Console.WriteLine("\n---------Удаление дубликатов----------------------");

            string[] softs = { "Microsoft", "Google", "Apple", "Microsoft", "Google" };

            // удаление дублей
            var result = softs.Distinct();

            foreach (string s in result)
                Console.WriteLine(s);



            //----------Объединение последовательностей----------------Union---------
            /*
             Для объединения двух последовательностей используется метод Union. 
            Его результатом является новый набор, в котором имеются элементы, 
            как из первой, так и из второй последовательности. 
            
            Повторяющиеся элементы добавляются в результат только ОДИН раз
             */

            Console.WriteLine("\n---------Объединение последовательностей-----------");
            var resultUn = soft.Union(hard);

            foreach (string s in resultUn)
                Console.WriteLine(s);


            //----------Объединение последовательностей----------------
            //Для простого объединения двух наборов используется метод Concat:
            Console.WriteLine("------------Concat---------------------------------");

            var resultCon = soft.Concat(hard);
            foreach (string s in resultCon)
                Console.WriteLine(s);


            //----------Работа с объектами пользовательских классов------------------

            Console.WriteLine("------------Union  Person--------------------------");

            Person[] students = { new Person("Tom"), new Person("Bob"), new Person("Sam") };
            Person[] employees = { new Person("Tom"), new Person("Bob"), new Person("Mike") };

            // Объединение последовательностей
            var people = students.Union(employees);

            foreach (Person person in people)
                Console.WriteLine(person.Name);

            Console.Read();
        }
    }
    class Person : IEquatable<Person>
    {
        public string Name { get; }
        public Person(string name) => Name = name;

        public override int GetHashCode() => Name.GetHashCode();

        public bool Equals(Person? other)
        {
            return Name == other?.Name;
            //throw new NotImplementedException();
        }
    }
}