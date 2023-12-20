using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            //Задание 1: Создайте класс Passport(Паспорт), который будет содержать паспортную
            //информацию о гражданине заданной страны.
            //С помощью механизма наследования, реализуйте класс ForeignPassport(Загранпаспорт)
            //производный от Passport.
            //Напомним, что заграничный паспорт содержит помимо паспортных данных, также данные о
            //визах, номер заграничного паспорта. Каждый из классов должен содержать необходимые
            //методы.
            //Продемонстрируйте работу классов на примерах.
            //Также создайте массив ссылок на базовый класс, которым присваиваются ссылки различных
            //объектов.Организуйте вывод данных, выделяя информацию разным цветом для разного типа
            //паспортов.

            Passport passport = new Passport();
            Console.WriteLine(passport.ToString());
            Console.WriteLine();
            passport.Show();
            Console.WriteLine();
            //passport.Init();
            Console.WriteLine(passport.ToString());
            Passport passport2 = new Passport("Dvornicov Ruslan", 
                                 new DateTime(1990,10,26), "M", "MD", "B000000", 
                                 new DateTime(2000, 12, 22), "Address");

            Console.WriteLine("\n-----------------------------------------------------------------------------\n");

            ForeignPassport fpPassport = new ForeignPassport();
            fpPassport.Show();
            Console.WriteLine();
            Console.WriteLine(fpPassport.ToString());

            ForeignPassport fpPassport2 = new ForeignPassport("Dvornicov Ruslan",
                     new DateTime(1990, 10, 26), "M", "MD", "B000000",
                     new DateTime(2000, 12, 22), "Address", "200234234234", new string[] {"ABF", "DDF", "YYU" });

            Console.WriteLine(fpPassport2.ToString());

            Passport[] ps = new Passport[] { passport, fpPassport, passport2, fpPassport2 };
            Console.WriteLine("\nМассив обьектов **********************************************");
            foreach (var item in ps)
            {
                if (item is ForeignPassport)
                    Console.WriteLine($"\nЗагран паспорт! {(item as ForeignPassport).FPNumber}"); 
                else Console.WriteLine("\nПаспорт!");

                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n-----------------------------------------------------------------------------\n");

            ForeignPassport fpPassportCopy = new ForeignPassport();

            fpPassportCopy = fpPassport2;
            Console.WriteLine(fpPassportCopy.ToString());
#endif

#if false
            //Задание 2: Создайте абстрактный базовый класс «Музыкальный инструмент» и производные
            //классы «Скрипка», «Тромбон», «Укулеле», «Виолончель». С помощью конструктора установить
            //имя каждого музыкального инструмента и его характеристики.
            //Реализуйте для каждого из классов методы:
            //− Sound — издает звук музыкального инструмента(пишем текстом в консоль);
            //− Show — отображает название музыкального инструмента;
            //− Desc — отображает описание музыкального инструмента;
            //− History — отображает историю создания музыкального инструмента.
            //Для проверки определите массив ссылок на абстрактный класс, которым присваиваются адреса
            //различных объектов классов - потомков.Организуйте вывод данных, выделяя информацию
            //разным цветом для разного типа инструментов.
            
            Cello cello = new Cello("Cello", "History Cello");
            Console.WriteLine(cello);

            Ukulele ukulele = new Ukulele("Ukulele", "History Ukulele");
            Console.WriteLine(ukulele);

            Trombone trombone = new Trombone("Trombone", "History Trombone");
            Console.WriteLine(trombone);

            Violin violin = new Violin("Violin", "History Violin");
            Console.WriteLine(violin);

            MusicalInstrument[] instruments = { trombone, ukulele, cello, violin };

            for (int i = 0; i < instruments.Length; i++)
            {
                if (instruments[i] is Cello) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(instruments[i]);
                    Console.ResetColor();
                }else if (instruments[i] is Trombone)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(instruments[i]);
                    Console.ResetColor();
                }
                else if (instruments[i] is Ukulele)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(instruments[i]);
                    Console.ResetColor();
                }
                else if (instruments[i] is Violin)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(instruments[i]);
                    Console.ResetColor();
                }



            }

#endif
            Console.ReadLine();
        }
    }
}
