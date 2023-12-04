using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_5_Получение_доп.инф
{
    internal class Program
    {
        static int MyDividing(int x, int y)
        {
            if (y == 0)
            {
                // Создаем локальную переменную для получения
                // свойства HelpLink
                //Exception myException = new Exception("деление на ноль");

                Exception myException = new DivideByZeroException("деление на ноль");
                myException.HelpLink = "https://learn.microsoft.com/ru-ru/dotnet/api/system.dividebyzeroexception?view=net-7.0";

                // Вставка специальных дополнительных данных
                // имеющих отношение к ошибке
                myException.Data.Add("Время возникновения: ", DateTime.Now);
                myException.Data.Add("Причина: ", "Некорректное значение");
                throw myException;
            }
            return x / y;
        }
        static void Main(string[] args)
        {
            int a = 5, b = 0;
            try
            {
                int result = MyDividing(a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"\nStackTrace:\n {ex.StackTrace}");
                Console.WriteLine($"\nTargetSite:\n {ex.TargetSite}");
                Console.WriteLine($"\nSource:\n {ex.Source}");


                // Проверка наличия данных
                if (ex.Data.Count > 0)
                {
                    Console.WriteLine("\n\nДополнительные данные:");

                    foreach (System.Collections.DictionaryEntry entry in ex.Data)
                    {
                        Console.WriteLine($"{entry.Key}: {entry.Value}");
                    }
                }

                Console.WriteLine($"HelpLink: {ex.HelpLink}");
            }
            Console.ReadLine();
        }
    }
}
