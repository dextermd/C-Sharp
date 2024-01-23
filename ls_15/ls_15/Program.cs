using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if true

            /*
                Описать класс "Нац. Банк", в котором будет метод, генерирующий событие.
                Информация о событиии - это дата и курс валюты.
        
                Описать классы-подписчики:
                    - "Человек"  с характеристиками Имя и телефон. 
                    - "Банк" с характеристиками Наименование и Адрес, курс валют.
                В классах реализовать обработчики события.

                Объявить двух-трех подписчиков на событие, сгенерировать событие.
            */

            // Подписчики на события
            Bank bank1 = new Bank("MAIB", "Ул. Маркса д.5");
            Bank bank2 = new Bank("Victoria", "Ул. 31 Август");
            Bank bank3 = new Bank("MICB", "Ул. Мира д.25");
            Bank bank4 = new Bank("Eximbank", "Ул. Маре д.101");

            Console.WriteLine(bank1);
            Console.WriteLine(bank2);
            Console.WriteLine(bank3);
            Console.WriteLine(bank4);

            Person person1 = new Person("Davnii Evgeniu", "0131354842");
            Person person2 = new Person("Marks", "054684654");
            Person person3 = new Person("Dvornicov Ruslan", "068751173");

            Console.WriteLine("\n-------------------------------------------\n");

            // Обьект, инициирующий событие
            MainBank mainBank = new MainBank();

            // Подписка на событие
            mainBank.BankEvent += bank1.BankHandler;
            mainBank.BankEvent += bank2.BankHandler;
            mainBank.BankEvent += bank3.BankHandler;
            mainBank.BankEvent += bank4.BankHandler;

            mainBank.BankEvent += person1.PersonHandler;
            mainBank.BankEvent += person2.PersonHandler;
            mainBank.BankEvent += person3.PersonHandler;

            mainBank.BankMessageEvent += bank1.BankMessageHandler
                ;
            // Инициирование события
            mainBank.OnBankEvent(DateTime.Now, 19.25, 17.79);

            mainBank.OnBankMessageEvent();

            Console.WriteLine("\n-------------------------------------------\n");

            Console.WriteLine(bank1);
            Console.WriteLine(bank2);
            Console.WriteLine(bank3);
            Console.WriteLine(bank4);

            Console.WriteLine("\n-------------------------------------------\n");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);

#endif

#if false
            /*          
                Описать класс "Выставка", в котором будет метод, генерирующий событие.
                Информация о событиии - это дата, время и тема выставки.

                Описать класс "Подписчик/Человек" с характеристиками Имя и телефон.
                В этом классе реализовать обработчик события.

                Объявить двух-трех подписчиков на событие, сгенерировать событие.
            */

            Subscriber subscriber1 = new Subscriber("Ruslan", "068751173");
            Subscriber subscriber2 = new Subscriber("Lita", "067177991");

            Console.WriteLine(subscriber1);
            Console.WriteLine(subscriber2);

            Console.WriteLine("\n-------------------------------------------\n");

            Exposition exposition = new Exposition();

            exposition.expositionEvent += subscriber1.SubscriberHandler;
            exposition.expositionEvent += subscriber2.SubscriberHandler;

            exposition.OnExpositionEvent(new DateTime(2024, 03, 1, 15, 0, 0), "Кровь");

            Console.WriteLine("\n-------------------------------------------\n");

            Console.WriteLine(subscriber1);
            Console.WriteLine(subscriber2);

            Console.WriteLine("\n-------------------------------------------\n");

#endif

            Console.ReadLine();
        }
    }
}
