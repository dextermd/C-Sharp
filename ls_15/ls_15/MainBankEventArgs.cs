using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_15
{
    // Класс для хранения/передачи параметров
    internal class MainBankEventArgs : EventArgs
    {
        public DateTime Date;
        public double CursEuro;
        public double CursDollar;
    }
}
