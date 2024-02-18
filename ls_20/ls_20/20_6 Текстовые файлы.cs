namespace _20_6_Текстовые_файлы
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            // Вариант 1
            string path = "test.txt";
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path, true);
                sw.WriteLine("Hello!!!!");
            }
            catch (DirectoryNotFoundException exp )
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                if (sw != null)
                {
                    Console.WriteLine("Close");
                    //sw.Close();
                    sw.Dispose();
                }
            }

#endif
            // Вариант 2
            // Запись в файл-----------------------------------
            string path = "test111.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Hello, World !!!");
                    sw.WriteLine(2024);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))//true - дозапись
                {
                    sw.WriteLine("Hello, World !!!");
                    sw.WriteLine(2025);
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            //Чтение из текстового файла----------------------------------------------

            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    ////1 Чтение одной строки
                    //string result = sr.ReadLine();
                    //Console.WriteLine(result);

                    ////2 Чтение всего файла
                    //string allText = sr.ReadToEnd();
                    //Console.WriteLine(allText);

                    // 3 Построчное чтение
                    string line;
                    while((line = sr.ReadLine())!=null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            Console.Read();
        }
    }
}