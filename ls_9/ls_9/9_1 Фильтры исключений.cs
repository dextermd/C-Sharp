using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 Обсудить:
- студент
- задача на исключение
 */

namespace ls_9
{
    internal class Program_ex
    {
        static int DivitionNumbers(int n1, int n2)
        {
            int result;
            try
            {
                result = n1 / n2;
            }
            catch (DivideByZeroException e)
            {
                throw new ArgumentException("Проверка фильтра исключения.", e); // повторный выброс исключения
            }
            return result;
        }
        static void Main_ex(string[] args)
        {
#if false
            int n1, n2 = 1;
            int r = 0;
            try
            {
                Console.WriteLine("Введи два числа: ");
                n1 = int.Parse(Console.ReadLine());
                n2 = int.Parse(Console.ReadLine());
                // 1 вариант
                r = n1 / n2;
                Console.WriteLine("{0} / {1} = {2}", n1, n2, r);
                r = n2 / n1;
                Console.WriteLine("{0} / {1} = {2}", n2, n1, r);

                //2
                //r = DivitionNumbers(n1, n2);
            }
            catch (DivideByZeroException e) when (n2 == 0)  // на блок catch добавлен фильтр
            {
                Console.WriteLine("Ошибка: " + e.Message);

            }
            catch (DivideByZeroException e)   //при n1 = 0
            {
                Console.WriteLine("Ошибка 'n1' = 0 : " + e.Message);
                n1 = 1;
                Console.WriteLine($"n1 = {n1}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OverflowException: " + e.Message);
            }
            catch (FormatException e) //  Если ввести текст, например, то внутренний не сработает / FormatNumberException -  наследник Exception
            {
                Console.WriteLine("FormatException: " + e.Message);
            }

            // InnerException
            catch (ArgumentException e) when (e.InnerException != null)  // на блок catch добавлен фильтр
            {
                Console.WriteLine("Ошибка: " + e.Message);
                Console.WriteLine("Ошибка InnerException: " + e.InnerException.Message);

                Console.WriteLine($"\nМетод: {e.TargetSite}");
                Console.WriteLine($"\nТрассировка стека:\n {e.StackTrace}");

            }

#endif

            Console.ReadLine();
        }
    }
}
