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
        public void DeleteFile(string path) 
        {
            if (File.Exists(path))
                File.Delete(path); 
        }

        public bool IsFileExist(string path) => File.Exists(path);

        public void Show(string message) { Console.WriteLine(message); }

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
                    Show(message);
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

        public (int, int, int, int) CountValueEvenOddTwoFiveDigit(string path)
        {
            DeleteFile("task_3_five_digit.txt");
            DeleteFile("task_3_even.txt");
            DeleteFile("task_3_two_digit.txt");
            DeleteFile("task_3_odd.txt");
            int even = 0, odd = 0, two_digit = 0, five_digit = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        int count = 0;
                        int num = 0;

                        num = int.Parse(line);
                        if (num % 2 == 0)
                        {
                            even++;
                            WriteToFile("task_3_even.txt", line, true);
                        } else
                        {
                            odd++;
                            WriteToFile("task_3_odd.txt", line, true);
                        }

                        count = GetCountDigit(int.Parse(line));
                        if (count == 2) { 
                            two_digit++;
                            WriteToFile("task_3_two_digit.txt", line, true);
                        }
                        if (count == 5)
                        {
                            five_digit++;
                            WriteToFile("task_3_five_digit.txt", line, true);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return (even, odd, two_digit, five_digit);
        }
        public static int GetCountDigit(int num)
        {
            int result = 0;
            while (num != 0) {
                num = num / 10;
                result++;
            }
            return result;
        }

        public void ReadEvenLineFromFile(string path)
        {
            int num_line = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        num_line++;
                        if (num_line  % 2 == 0) 
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void ReadEvenLineFromFile(string path, string path_write)
        {
            int num_line = 0;
            DeleteFile(path_write);
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        num_line++;
                        if (num_line % 2 == 0)
                        {
                            Console.WriteLine(line);
                            WriteToFile(path_write, line, true);

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
