using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_5_6
{
    internal class Program
    {
        static public void ShowRectang(in int height, in int length, in char symbol, in string color = "White")
        {
            if (Enum.TryParse(color, true, out ConsoleColor consoleColor))
            {
                Console.ForegroundColor = consoleColor;
            }

            for (int i = 0; i < height; i++)
            {
                Console.Write($"{symbol}");
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"{symbol}");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        static public bool IsPalindrom(in int number)
        {
            string tmp = number.ToString();
            bool pl = false;
            for (int i = 0, j = tmp.Length -1; i < tmp.Length; i++, j--)
            {
                if (tmp[i] == tmp[j]) 
                { 
                    pl = true;
                }
                else
                {
                    pl = false;
                    return false;
                }
            }

            return pl;
        }
        static public void ArrFilter(ref int[] sourceArr, int[] filterArr)
        {
            sourceArr = sourceArr.Except(filterArr).ToArray();
        }

        static void Main(string[] args)
        {
#if false

            //Задание 1: Напишите метод, который отображает прямоугольную рамку из некоторого символа
            //определенным цветом. Метод принимает в качестве параметров: размеры прямоугольника,
            //символ и цвет. Цвет по умолчанию – белый.При вызове продемонстрируйте произвольный
            //порядок передачи параметров, используя именованные параметры.

            ShowRectang(symbol: '#', length: 20, color: "Green", height: 4 );
#endif

#if false
            //Задание 2: Напишите метод, который проверяет является ли переданное число “палиндромом”.
            //Число передаётся в качестве параметра.Если число – палиндром, нужно вернуть из метода true,
            //иначе false.Палиндром — число, которое читается одинаково как справа налево, так и слева
            //направо.Например: 1221 — палиндром; 7854 — не палиндром.

            Console.WriteLine(IsPalindrom(12121));
#endif

#if false
            //Задание 3: Напишите метод, фильтрующий массив на основании переданных параметров.Метод
            //принимает параметры: исходный массив, массив_с_данными_для_фильтрации. Метод
            //возвращает оригинальный массив без элементов, которые есть в массиве для фильтрации.
            //Например:
            //1, 2, 6, -1, 88, 7, 6 — исходный массив;
            //6, 88, 7 — массив для фильтрации;
            //1, 2, -1 — результат работы метода.

            int[] arr1 = { 1, 2, 6, -1, 88, 7, 6 };
            int[] arr2 = { 6, 88, 7 };

            ArrFilter(ref arr1, arr2);

            foreach (var i in arr1)
            {
                Console.Write($"{i} ");
            }
#endif

#if false
            //Задание 4: Создайте класс “Магазин”. Необходимо хранить в полях класса: название магазина,
            //адрес, описание профиля магазина, контактный телефон, контактный e-mail.Реализуйте методы
            //класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы
            //класса.

            Shop shop = new Shop();
            shop.Init();
            Console.WriteLine();
            shop.Show();
#endif

#if false
            //Задание 5: Реализуйте класс “Журнал”. Необходимо хранить в полях класса: название журнала,
            //год основания, описание журнала, контактный телефон, контактный e-mail.Для доступа к
            //закрытым полям класса используйте механизм свойств для полей класса.Продемонстрируйте
            //работу класса на примерах.

            Journal journal = new Journal();
            journal.Name = "test";
            journal.Year = 1968;
            journal.Description = "test test test";
            journal.Phone = "xx-xx-xx";
            journal.Email = "dd@mail.dd";

            Console.WriteLine(journal.Name);
            Console.WriteLine(journal.Year);
            Console.WriteLine(journal.Description);
            Console.WriteLine(journal.Phone);
            Console.WriteLine(journal.Email);
#endif
            Console.ReadLine();
        }
    }
}
