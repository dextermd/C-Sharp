using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            //Задание 1: Ранее в одном из домашних заданий вы создавали класс «Журнал». Добавьте к уже
            //созданному классу информацию о количестве сотрудников.Выполните перегрузки:
            //        +(для увеличения количества сотрудников на указанную величину),
            //        — (для уменьшения количества сотрудников на указанную величину),
            //        == (проверка на равенство количества сотрудников),
            //        != (проверка на не равенство количества сотрудников),
            //        < и > (сравнение количества сотрудников).

            //Также переопределите методы: Equals() и GetHashCode().
            //Используйте механизм свойств для полей класса. Продемонстрируйте работу методов на
            //примерах.

            Journal journal = new Journal();
            Console.WriteLine(journal);
            journal += 10;
            Console.WriteLine(journal);
            journal -= 5;
            Console.WriteLine(journal);
            Journal journal2 = new Journal();
            Console.WriteLine(journal2);
            journal2 = journal;
            Console.WriteLine(journal2);

            Console.WriteLine(journal == journal2);
            Console.WriteLine(journal != journal2);

            Console.WriteLine();

            Console.WriteLine(journal > journal2);
            Console.WriteLine(journal < journal2);
            journal2 += 50;
            Console.WriteLine(journal > journal2);
            Console.WriteLine(journal < journal2);

            journal2 -= 100;
            Console.WriteLine(journal2);

#endif

#if false
            //Задание 2: Ранее в одном из домашних заданий вы создавали класс «Магазин». Добавьте к уже
            //созданному классу информацию о площади магазина.Выполните перегрузки:
            //        +(для увеличения площади магазина на указанную величину),
            //        — (для уменьшения площади магазина на указанную величину),
            //        == (проверка на равенство площадей магазинов),
            //        != (проверка на не равенство площадей магазинов),
            //        < и > (сравнение площадей магазинов).

            //Также переопределите методы: Equals() и GetHashCode().
            //Используйте механизм свойств для полей класса. Продемонстрируйте работу методов на
            //примерах.

            Shop shop = new Shop();
            Console.WriteLine(shop);
            shop += 10;
            Console.WriteLine(shop);
            shop -= 5;
            Console.WriteLine(shop);
            Shop shop2 = new Shop();
            Console.WriteLine(shop2);
            shop2 = shop;
            Console.WriteLine(shop2);

            Console.WriteLine();

            Console.WriteLine(shop == shop2);
            Console.WriteLine(shop != shop2);

            Console.WriteLine();

            Console.WriteLine(shop > shop2);
            Console.WriteLine(shop < shop2);
            shop2 += 50;
            Console.WriteLine(shop > shop2);
            Console.WriteLine(shop < shop2);

            shop2 -= 100;
            Console.WriteLine(shop2);

#endif

#if false
            //Задание 3: Опишите класс «Кредитная карточка». Вам необходимо хранить информацию о
            //номере карты, ФИО владельца, о сумме денег на карте, CVC, дата завершения работы карты и т.д.
            //Предусмотреть механизмы для инициализации полей класса. Если значение для инициализации
            //неверное, генерируйте исключение.
            //Выполните перегрузку операторов:
            //            +(для увеличения суммы денег на указанную величину),
            //            – (для уменьшения суммы денег на указанную величину),
            //            == и!(проверка на равенство / неравенство CVC кода),
            //            < и > (сравнение суммы денег).

            //Также переопределите методы: Equals() и GetHashCode().
            //Используйте механизм свойств для полей класса. Продемонстрируйте работу методов на
            //примерах.

            CreditCard card = new CreditCard();
            Console.WriteLine(card);

            try
            {
                CreditCard creditCard = new CreditCard("1563 5464 5646 4587", "Dvornicov Ruslan");
                Console.WriteLine(creditCard);
                creditCard += 1000;
                Console.WriteLine(creditCard);
                creditCard -= 250;
                Console.WriteLine(creditCard);
                Console.WriteLine();
                Console.WriteLine(creditCard == "111");
                Console.WriteLine(creditCard != "111");
                Console.WriteLine();
                Console.WriteLine(creditCard > 500);
                Console.WriteLine(creditCard < 500);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

#endif
            Console.ReadLine();
        }
    }
}
