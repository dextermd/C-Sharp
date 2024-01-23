using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //Задание 1: Создайте класс «Кредитная карточка». Класс должен содержать:
            //    − Номер карты;
            //    − ФИО владельца;
            //    − Срок действия карты;
            //    − PIN;
            //    − Кредитный лимит;
            //    − Сумма денег.

            //    При возникновении каждой из ситуаций(событии) должны происходить соответствующие
            //    изменения с объектом «Кредитная карточка» и на экран выводится соответствующее
            //    сообщение.Например: На счет поступило: 20000 L Сумма на счете: 450000 L

            CreditCard myCard = new CreditCard("1234-5678-9012-3456", "John Doe", DateTime.Now.AddYears(3), 1547, 5000, 4000);
            myCard.PinChangedEvent += HandlePinChanged;
            myCard.TopUpEvent += HandleTopUp;
            myCard.SpendingEvent += HandleSpending;

            myCard.ChangePin(1234);
            myCard.TopUp(20);
            myCard.Spending(2000);

#endif

#if true
            //Задание 2: Создайте класс «Рюкзак». Характеристики рюкзака:
            //    − Цвет рюкзака;
            //    − Фирма производитель;
            //    − Ткань рюкзака;
            //    − Вес рюкзака;
            //    − Объём рюкзака;
            //    − Содержимое рюкзака(список объектов, у каждого объекта кроме названия нужно
            //    учитывать занимаемый объём).

            //Создайте событие для добавления объекта в рюкзак.
            //Реализуйте метод в качестве обработчика события добавления объекта.
            //Если при попытке добавления может быть превышен объём рюкзака, нужно генерировать исключение.

            Item item1 = new Item("ItemOne", 2);
            Item item2 = new Item("ItemTwo", 7);
            List<Item> list = new List<Item>();
            list.Add(item1);
            list.Add(item2);
            Backpack myBackpack = new Backpack("Blue", "BrandX", "Canvas", 1.5, 20, list);

            Console.WriteLine(myBackpack);
#endif
            Console.ReadLine();
        }
        static void HandlePinChanged(string message)
        {
            Console.WriteLine(message);
        }
        static void HandleTopUp(object sender, CardArgs args)
        {
            Console.WriteLine($"На счет поступило: {args.Summa} L. Сумма на счете:{args.Balance} L");
        }
        static void HandleSpending(object sender, CardArgs args)
        {
            Console.WriteLine($"Со счета списано: {args.Summa} L. Сумма на счете:{args.Balance} L");
        }
    }
}
