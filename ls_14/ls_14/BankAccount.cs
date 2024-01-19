using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_14
{
    delegate void AccountStateHandler(string str);
    internal class BankAccount
    {
        /*public*/ AccountStateHandler accountStateHandler;

        int summa; // Переменная для хранения суммы
        public BankAccount(int sum)
        {
            summa = sum;
        }
        // Регистрация
        public void RegisterHandler(AccountStateHandler accountStateHandler)
        {
            if (accountStateHandler != null) 
                this.accountStateHandler += accountStateHandler;
        }
        public void UnRegisterHandler(AccountStateHandler accountStateHandler)
        {
            if (accountStateHandler != null)
                this.accountStateHandler -= accountStateHandler;
        }
        public void Put(int sum) // что-то произошло
        {
            summa += sum;
            //Console.WriteLine($"На счет поступила сумма: {sum}");
            if(accountStateHandler != null)
            {
                accountStateHandler($"На счет поступила сумма: {sum}");
            }
        }
        public void Withdraw(int sum)// что-то произошло
        {
            if (sum <= summa)
            {
                //Console.WriteLine($"Со счета снята сумма: {sum}");
                summa -= sum;
                if (accountStateHandler != null)
                {
                    accountStateHandler($"Со счета снята сумма: {sum}");
                }
            }
            else
            {
                //Console.WriteLine($"На счете недостаточно средств.");
                accountStateHandler?.Invoke($"На счете недостаточно средств.");
            }
        }
    }
}
