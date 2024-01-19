using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            // -------------------------- Делегаты ------------------------------

            BankAccount account = new BankAccount(2000);

            //// public AccountStateHandler accountStateHandler;

            //account.accountStateHandler = Show;
            //account.accountStateHandler += ColorShow;
            //account.accountStateHandler += delegate { Console.WriteLine($"Я с вами! Анонимный делегат!"); };
            //account.accountStateHandler += (str) => { Console.WriteLine($"Я с вами! Лямбда выражения!"); };
            //account.Put(500);
            //account.Withdraw(1000);
            //account.Withdraw(3000);

            //account.Put(2500);
            //account.Withdraw(2850);

            //// private AccountStateHandler accountStateHandler;

            account.RegisterHandler(Show);
            account.RegisterHandler(ColorShow);

            account.Put(500);
            account.Withdraw(1000);
            account.Withdraw(3000);

            account.Put(2500);
            account.Withdraw(2850);

            Console.WriteLine();
            account.UnRegisterHandler(ColorShow);
            account.Put(2500);

            account.RegisterHandler((str) => Console.WriteLine($"Я с вами! Лямбда-выражение!"));
            account.RegisterHandler(delegate { Console.WriteLine($"Я с вами! Анонимный делегат!"); });
            account.Put(2500);

#endif

#if false
            // ------------------------------ События -------------------------------------
            /*
                Описать класс TestEvent с двумя свойствами целого типа.
                Событие в классе будет возникать, когда сумма чисел даст в результате 10.
                Реализовать обработку события методами, которые сообщают, 
                что событие произошло(ничего не принимают, ничего не возвращают).
            */

            TestEvent testEvent = new TestEvent();
            testEvent.MySummaEvent += Show;
            testEvent.MySummaEvent += new MyDelegate(ColorShow); // Через конструктор

            testEvent.A = 5;
            testEvent.B = 5;

            // Инициировать событие
            testEvent.OnSumma();
            Console.WriteLine();

            testEvent.MyMultEvent += Show;
            testEvent.OnMult(24);  // 6 * 4 = 24

            Console.WriteLine();

            testEvent.MyMessageEvent += ColorMessageShow;
            testEvent.OnMultMessage(24);

            Console.WriteLine();

            testEvent.MyArgEvent += ColorMessageShow;
            testEvent.OnSub(-2);

            Console.WriteLine();
            testEvent.MyEqualsEvent += ColorMessageShow;
            testEvent.OnMyEqualsEvent();
#endif

#if true
            // ------------------------------ События -------------------------------------
            /*
                Написать программу, в которой по нажатию пользователем клавиши возникает событие.
                Прогрмма должна обработать это событие, сообщив о том, 
                какая клавиша была нажата и сколько всего клавиш было нажато пользователем.
                Для окончания ввода пользователь нажимает символ точка(.)
            */

            KeyEvent keyEvent = new KeyEvent();

            ProcessKey processKey = new ProcessKey();
            CounterKeys counterKeys = new CounterKeys();

            //keyEvent.KeyPress += new KeyEventHandler(processKey.KeyHandler);
            // или
            keyEvent.KeyPress += processKey.KeyHandler;
            keyEvent.KeyPress += counterKeys.KeyHandler;

            Console.WriteLine("Нажмите клавишу");
            char ch;

            do
            {
                ch = Console.ReadKey().KeyChar;
                keyEvent.OnKeyPress(ch);
            } while (ch != '.');

            Console.WriteLine($"Было нажато {counterKeys.Count} клавиш");
#endif

            Console.ReadLine();
        }

        static void ColorMessageShow(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Случилось событие!");
            Console.ResetColor();
        }
        static void ColorMessageShow(object sender, MyEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Случилось событие!\nДанне: {e.value1}, {e.value2}");
            Console.ResetColor();
        }
        static void ColorMessageShow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        static void Show()
        {
            Console.WriteLine("Случилось событие!");
        }
        static void ColorShow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Случилось событие!");
            Console.ResetColor();
        }
        static void Show(string str)
        {
            Console.WriteLine(str);
        }
        static void ColorShow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
