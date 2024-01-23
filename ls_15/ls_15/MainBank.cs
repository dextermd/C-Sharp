using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    // .NET совместимий делегат с передачей параметров
    //delegate void MainBankEventHandler(object sender, MainBankEventArgs args);

    // Класс, инициирующий событие
    internal class MainBank
    {
        //public event MainBankEventHandler BankEvent;
        public event EventHandler<MainBankEventArgs> BankEvent;
        public event EventHandler BankMessageEvent;

        // Метод в котором инициируется событие
        public void OnBankEvent(DateTime date, double cursEuro, double cursDollar) 
        {
            MainBankEventArgs args = new MainBankEventArgs();

            if (BankEvent != null )
            {
                args.Date = date;
                args.CursEuro = cursEuro;
                args.CursDollar = cursDollar;

                BankEvent.Invoke(this, args);
            }
        }

        public void OnBankMessageEvent()
        {
            BankMessageEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
