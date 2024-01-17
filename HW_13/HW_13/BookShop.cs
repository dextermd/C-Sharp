using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class BookShop : IEnumerable
    {
        private Book[] bookArray;

        public BookShop(int size = 5)
        {
            bookArray = new Book[size];

            bookArray[0] = new Book(
                author: "Автор1",
                bookName: "Книга1",
                publisher: "Издательство1",
                yearOfPublication: "2000",
                genre: "Жанр1",
                price: 25.99m,
                quantity: 10
            );

            bookArray[1] = new Book(
                author: "Автор2",
                bookName: "Книга2",
                publisher: "Издательство2",
                yearOfPublication: "2015",
                genre: "Жанр2",
                price: 19.99m,
                quantity: 15
            );

            bookArray[2] = new Book(
                author: "Автор3",
                bookName: "Книга3",
                publisher: "Издательство3",
                yearOfPublication: "1995",
                genre: "Жанр3",
                price: 30.50m,
                quantity: 8
            );

            bookArray[3] = new Book(
                author: "Автор4",
                bookName: "Книга4",
                publisher: "Издательство4",
                yearOfPublication: "2010",
                genre: "Жанр4",
                price: 15.75m,
                quantity: 20
            );

            bookArray[4] = new Book(
                author: "Автор5",
                bookName: "Книга5",
                publisher: "Издательство5",
                yearOfPublication: "2022",
                genre: "Жанр5",
                price: 22.00m,
                quantity: 12
            );
        }

        public IEnumerator GetEnumerator()
        {
            return bookArray.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(bookArray);
        }

        public void Sort(IComparer compare)
        {
            Array.Sort(bookArray, compare);
        }

    }
}
