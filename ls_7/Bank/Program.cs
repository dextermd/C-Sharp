using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            //Реализовать класс, описывающий банковские филиалы(БАНК).
            //Статическое поле будет содержать бонус в процентах для оформления депозитов.
            //А текущий баланс у каждого филиала будет свой.

            //Характеристики:
            //    - текущий баланс
            //    - статическое поле бонус
            //    - конструктор
            //    - методы set / get   или свойства
            //    - статический конструктор для иниц.стат.поля
            //    - метод для расчета процента

            Bank bank = new Bank(1000000);
            Console.WriteLine($"Текущий баланс: {bank.CurrentBalance:C}");
            Console.WriteLine("Бонус: {0:P}", Bank.GetBonus());
            double depozit = 50000;
            Console.WriteLine("Ваш доход: {0} по сумме вклада {1}", bank.GetPercents(depozit), depozit);

            Console.WriteLine();

            Bank bank2 = new Bank(56000000);
            Console.WriteLine($"Текущий баланс: {bank2.CurrentBalance:C}");
            Console.WriteLine("Бонус: {0:P}", Bank.GetBonus());

            Console.WriteLine();

            // Статический конструктор----------------------------------------

            //- нет модификатора доступа
            //- только один в классе
            //- не может принимать параметры
            //- выполняется всегда только один раз за всю работу программы,
            //  как только было взаимодействие с классом
            //- не можем в нем обращаться к нестатическим членам класса
            //- для инициализации статических полей, свойств (readonly в том числе)
            //  если на момент написания кода у нас этих данных нет
            //  (например считыаются из файла)

#endif
            Console.ReadLine();
        }
    }
}
