using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class BankCustomer : IEnumerable
    {
        static readonly int Size = 5;
		private CreditCard[] customerCards;

        public BankCustomer() 
        {
            customerCards = new CreditCard[Size];
            customerCards[0] = new CreditCard(
                fullName: "Florence Hughes",
                cardNumber: "4797116430181639"
            );
            customerCards[1] = new CreditCard(
                fullName: "Kelly Gibbs",
                cardNumber: "4005454919884987"
            );
            customerCards[2] = new CreditCard(
                fullName: "Salvador Johnson",
                cardNumber: "4009659227211790"
            );
            customerCards[3] = new CreditCard(
                fullName: "Anne McDonald",
                cardNumber: "4009659654211760"
            );
            customerCards[4] = new CreditCard(
                fullName: "James Gordon",
                cardNumber: "4568123574466542"
            );

        }
        public BankCustomer(CreditCard[] customerCards) 
        {
            this.customerCards = customerCards;
        }
        public IEnumerator GetEnumerator()
        {
            return customerCards.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(customerCards);
        }

    }
}
