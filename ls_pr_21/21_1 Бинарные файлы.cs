//using System.IO;

namespace _21_1_Бинарные_файлы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\testBinFile.txt";

            using(BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                string text = "Hello, World!";
                bw.Write(text);

                int number = 2024;
                bw.Write(number);

                int[] m = { 25, -6, 9, 10, -7, 125, 7, 90 };
                // Запись размера массива
                bw.Write(m.Length);
                foreach(int i in m)
                {
                    bw.Write(i);
                }

                Console.WriteLine("Данные записаны в файл");

            }

            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Console.WriteLine("Данные из файла:");
                string textFromFile=br.ReadString();
                Console.WriteLine($"{textFromFile}");

                int res = br.ReadInt32();
                Console.WriteLine(res);

                int size = br.ReadInt32();
                int[]resultMas = new int[size];
                for(int i = 0; i < size; i++)
                {
                    resultMas[i] = br.ReadInt32();
                }
                Console.WriteLine("Массив из файла:");
                foreach (var item in resultMas)
                {
                    Console.Write($"{item}   ");
                }
            }

            Console.Read();
        }
    }
}