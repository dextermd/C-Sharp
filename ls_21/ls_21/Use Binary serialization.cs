using System.Runtime.Serialization.Formatters.Binary;

namespace Use_Binary_serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Сериализация представляет процесс преобразования какого-либо объекта в поток байтов.

            //Бинарная сериализация. BinaryFormatter
            //using System.Runtime.Serialization.Formatters.Binary;

            // объект для сериализации
            Person person = new Person("Ivanov", 2000, "MD123456");
            Console.WriteLine("Объект создан");

            //using System.Runtime.Serialization.Formatters.Binary;
            // Для бинарной сериализации применяется класс BinaryFormatter
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();


            //using System.IO;
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people_ser.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);

                Console.WriteLine("Объект сериализован");
            }


            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("people_ser.bin", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} --- Год рождения: {newPerson.Year}\n{newPerson.accNumber}");
            }


            // Массив объектов-----------------------------------------

            //Person person1 = new Person("Tom", 2000);
            //Person person2 = new Person("Bill", 1998);
            //// массив для сериализации
            //Person[] people = new Person[] { person1, person2 };

            ///*BinaryFormatter*/
            //formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream("people_mas_ser.dat", FileMode.OpenOrCreate))
            //{
            //    // сериализуем весь массив people
            //    formatter.Serialize(fs, people);

            //    Console.WriteLine("Объект сериализован");
            //}

            //// десериализация
            //using (FileStream fs = new FileStream("people_mas_ser.dat", FileMode.OpenOrCreate))
            //{
            //    Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);

            //    foreach (Person p in deserilizePeople)
            //    {
            //        Console.WriteLine($"Имя: {p.Name} --- Год рождения: {p.Year}");
            //    }
            //}

            Console.Read();
        }
    }

   [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }

        //[NonSerialized]
        public string accNumber;

        public Person(string name, int year, string acc)
        {
            Name = name;
            Year = year;
            accNumber = acc;
        }
    }
}