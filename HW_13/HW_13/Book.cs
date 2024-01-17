using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class Book : IComparable, ICloneable
    {
		private string author;
		private string bookName;
		private BookDetails bookDetails;
        public BookDetails BookDetails
        {
            get { return bookDetails; }
            set { bookDetails = value; }
        }
        public string BookName
		{
			get { return bookName; }
			set { bookName = value; }
		}

		public string Author
		{
			get { return author; }
			set { author = value; }
		}

		public Book()
		{
			Author = "No Author";
			BookName = "No BookName";
			BookDetails = new BookDetails();
		}
		public Book(
			string author,
			string bookName,
			string publisher,
            string yearOfPublication,
            string genre,
            decimal price,
            int quantity
			)
        {
            Author = author;
            BookName = bookName;
			BookDetails = new BookDetails(
				publisher: publisher,
				yearOfPublication: yearOfPublication,
				genre: genre,
				price: price,
				quantity: quantity
				);
        }
        public override string ToString()
        {
			return $"\nAuthor		: {Author}\n" +
				   $"Book name	: {BookName}\n" +
				   $"Publisher	: {BookDetails.Publisher}\n" +
				   $"Year of pub	: {BookDetails.YearOfPublication}\n" +
				   $"Genre		: {BookDetails.Genre}\n" +
				   $"Price		: {BookDetails.Price}\n" +
				   $"Quantity	: {BookDetails.Quantity}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Book)
            {
                return Author.CompareTo((obj as Book).Author);
            };

            throw new NotImplementedException();
        }

        public object Clone()
        {
            Book book = MemberwiseClone() as Book;

            BookDetails bookDetails = new BookDetails();
            bookDetails.Publisher = BookDetails.Publisher;
            bookDetails.YearOfPublication = BookDetails.YearOfPublication;
            bookDetails.Genre = BookDetails.Genre;
            bookDetails.Price = BookDetails.Price;
            bookDetails.Quantity = BookDetails.Quantity;

            book.BookDetails = bookDetails;

            return book;
        }
    }
}
