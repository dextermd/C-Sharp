using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_20
{
    internal class FileManager : IFileOperations
    {
        public void DeleteFile(string path) { File.Delete(path); }

        public bool IsFileExist(string path) => File.Exists(path);

        public string GetMessage(string message) => message;

        public void Message(string message) { Console.WriteLine(message); }

        public void ReadFromFile(string path, string data)
        {
        }

        public void WriteLogToFile(string path, string data, bool append = true)
        {
            DateTime dateTime = DateTime.Now;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine($"[{dateTime}] -> {data}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void WriteToFile(string path, string data, bool append = false)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadLineByLineFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void ReadLineFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string result = sr.ReadLine();
                    Console.WriteLine(result);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void ReadAllFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string allText = sr.ReadToEnd();
                    Console.WriteLine(allText);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void ReplaceWordFromFile(string path, string oldWord, string newWord, string pathLog)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace(oldWord, newWord);
                    string message = $"Замена файла с {oldWord} на {newWord}";
                    WriteLogToFile(pathLog, message);
                    Message(message);
                }

                File.WriteAllLines(path, lines);

                WriteLogToFile(pathLog, "Замена завершена.");
                Console.WriteLine("\nЗамена завершена.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при замене слова: {e.Message}");
            }
        }
    }
}
