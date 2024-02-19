using _19_1_Use_Traveler_Person;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_21
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            // Запись в файл в двоичном формате

            string path = "testBinary.txt";

            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                string text = "Hello, World!";
                bw.Write(text);

                int number = 2024;
                bw.Write(number);

                int[] m = { 25, -6, 9, 10, -7, 125, 7, 90 };
                // Запись размера массива
                bw.Write(m.Length);
                foreach (var item in m)
                {
                    bw.Write(item);
                }

                Console.WriteLine("Данные записаны в файл");
            }

            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Console.WriteLine("Данные из файла: ");
                string textFromFile = br.ReadString();
                Console.WriteLine($"{textFromFile}");

                int res = br.ReadInt32();
                Console.WriteLine(res);

                int size = br.ReadInt32();
                int[] resultArr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    resultArr[i] = br.ReadInt32();
                }
                Console.WriteLine("Массив из файла: ");
                foreach (var item in resultArr)
                {
                    Console.Write($"{item} ");
                }
            }
#endif

#if false
            //Объявить и проинициализировать jagget массив (array).
            //Записать в двоичный файл. 
            //Считать из файла в другой массив, вывести на экран.

            int[][] array =
            {
                new int[]{2,6,-12,9,4,89,3},
                new int[]{200,6,5,9},
                new int[]{-4,-9,78,25,3,6,9,100},
            };

            foreach (var row in array)
            {
                foreach (var value in row)
                {
                    Console.Write($"{value, 6}");
                }
                Console.WriteLine();
            }

            string path = "jagget_array_binary.txt";

            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                // Записываем длину массива
                bw.Write(array.Length);

                foreach (int[] row in array)
                {
                    bw.Write(row.Length);
                    foreach (var item in row)
                    {
                        bw.Write(item);
                    }
                }
                //for (int i = 0; i < array.Length; i++)
                //{
                //    bw.Write(array[i].Length);
                //}
                bw.Flush();
                Console.WriteLine("Массив записан в двоичный файл");
            }

            int[][] arrayFromFile = null;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                int row = br.ReadInt32(); // читаем кол-во строк
                arrayFromFile = new int[row][];
                for (int i = 0; i < row; i++)
                {
                    int col = br.ReadInt32();
                    arrayFromFile[i] = new int[col];

                    for (int j = 0; j < col; j++)
                    {
                        arrayFromFile[i][j] = br.ReadInt32();
                    }
                }

                Console.WriteLine("Массив из файла: ");

                foreach (int[] rows in arrayFromFile)
                {
                    foreach (var item in rows)
                    {
                        Console.Write($"{item, 6}");
                    }
                    Console.WriteLine();
                }

            }

            Console.WriteLine("______________________________________");

            foreach (int[] rows in arrayFromFile)
            {
                foreach (var item in rows)
                {
                    Console.Write($"{item,6}");
                }
                Console.WriteLine();
            }
#endif

#if true
            // Двоичные файлы и обьекты

            //Записать в двоичный файл словарь из задания выше. 
            //Прочитать информацию из файла с инициализацией другого словаря.

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

            foreach (KeyValuePair<Person, List<string>> myDictionary in travelLog)
            {
                Console.WriteLine("\n--------------------------------\n");
                Console.WriteLine($"{myDictionary.Key} \nПосетил следующий страны: {string.Join(", ", myDictionary.Value)}");
            }

            Console.WriteLine();

            string path = "travelers.txt";

            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                bw.Write(travelLog.Count); // Размер словаря

                foreach (var person in travelLog)
                {
                    bw.Write(person.Key.Name);
                    bw.Write(person.Key.Age);

                    bw.Write(person.Value.Count); // Кол- во элементов текущего списка
                    foreach (var value in person.Value)
                    {
                        if (value != null)
                        {
                            bw.Write(value);
                        }
                    }

                }
                Console.WriteLine("Данные словаря записаны в двоичный файл");
            }

            Console.WriteLine();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            using (BinaryReader br = new BinaryReader(bs))
            {
                // Размер словаря
                int size = br.ReadInt32();
                Dictionary<Person, List<string>> travelersFromFile = new Dictionary<Person, List<string>>(size);
                for (int i = 0; i < size; i++)
                {
                    string name = br.ReadString();
                    int age = br.ReadInt32();
                    Person person = new Person(name, age);

                    int count = br.ReadInt32();
                    List<string> list = new List<string>(count);
                    for(int j = 0; j < count; j++)
                    {
                        string value = br.ReadString();
                        list.Add(value);
                    }

                    travelersFromFile.Add(person, list);
                }
                Console.WriteLine("Словарь из файла:");
                foreach (KeyValuePair<Person, List<string>> myDictionary in travelersFromFile)
                {
                    Console.WriteLine("\n--------------------------------\n");
                    Console.WriteLine($"{myDictionary.Key} \nПосетил следующий страны: {string.Join(", ", myDictionary.Value)}");
                }
            }
#endif
                Console.Read();
        }
    }
}
