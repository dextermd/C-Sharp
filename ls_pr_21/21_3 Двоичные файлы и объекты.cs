
//Записать в двоичный файл словарь из задания выше. 
//Прочитать информацию из файла с инициализацией другого словаря.

using _My_Person;

namespace _21_3_Двоичные_файлы_и_объекты
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person firstPerson = new Person("Маркс", 6);
            Console.WriteLine(firstPerson);

            Dictionary<Person, List<string>> travelLog = new Dictionary<Person, List<string>>
            {
                {
                    new Person("Юра", 34),
                    new List<string> {"Италия", "Молдова", "Франция"}
                },
                {
                    new Person("Марина", 30),
                    new List<string> {"Италия", "Молдова", "Франция", "Австралия"}

                },
                {
                    firstPerson,
                    new List<string> {"Италия", "Молдова", "Франция"}
                }
            };
            Console.WriteLine($"Количество элементов: {travelLog.Count}");

            foreach (KeyValuePair<Person, List<string>> myDictionary in travelLog)
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine($"{myDictionary.Key} \nПосетил следующий страны: {string.Join(", ", myDictionary.Value)}");
            }

            string path = @"..\..\..\Travelers.txt";

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (BinaryWriter bw = new BinaryWriter(bufferedStream))
            {
                bw.Write(travelLog.Count); // Размер словаря

                foreach (var person in travelLog)
                {
                    bw.Write(person.Key.Name);
                    bw.Write(person.Key.Age);

                    bw.Write(person.Value.Count);// количество элементов текущего списка
                    foreach (var value in person.Value)
                    {
                        if(value!=null)
                        {
                            bw.Write(value);
                        }
                    }
                }
                Console.WriteLine("\n***Данные словаря записаны в двоичный файл");
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            using (BinaryReader br = new BinaryReader(bufferedStream))
            {
                // Размер словаря
                int size = br.ReadInt32();
                Dictionary<Person, List<string>> travelersFromFile = new Dictionary<Person, List<string>>(size);
                for (int i = 0; i < size; i++)
                {
                    string name = br.ReadString();
                    int age = br.ReadInt32();   
                    Person person = new Person(name,age);

                    int count = br.ReadInt32();// количество элементов текущего списка
                    List<string> list = new List<string>(count);
                    for (int k = 0; k < count; k++)
                    {
                        string value = br.ReadString();
                        list.Add(value);
                    }
                    travelersFromFile.Add(person, list);
                }
                Console.WriteLine("\nСловарь из файла");
                foreach (KeyValuePair<Person, List<string>> myDictionary in travelersFromFile)
                {
                    Console.WriteLine("\n--------------------------------\n");
                    Console.WriteLine($"{myDictionary.Key} \nПосетил следующий страны: {string.Join(", ", myDictionary.Value)}");
                }
                Console.WriteLine($"Количество элементов: {travelersFromFile.Count}");
            }



            Dictionary<int, int> test = new Dictionary<int, int>();
            test.Add(1, 2);
            test.Add(20, 2);
            test.Add(5, 2);
            test.Add(6, 2);
            test.Add(9, 2);
            Console.WriteLine($"\n\nКоличество элементов test: {test.Count}");
           

            Console.Read(); ;
        }
    }
}