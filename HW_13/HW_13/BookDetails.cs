using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class BookDetails
    {
		private string publisher;
		private string yearOfPublication;
		private string genre;
		private decimal price;
		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		public string Genre
		{
			get { return genre; }
			set { genre = value; }
		}

		public string YearOfPublication
        {
			get { return yearOfPublication; }
			set { yearOfPublication = value; }
		}

		public string Publisher
        {
			get { return publisher; }
			set { publisher = value; }
		}

		public BookDetails()
		{
			Quantity = 0;
			Price = 0;
			Genre = "No Genre";
			YearOfPublication = "No Publication";
			Publisher = "No Publisher";
        }
		public BookDetails(
			string publisher,
			string yearOfPublication,
			string genre,
            decimal price,
			int quantity
			)
		{
			Publisher = publisher;
			YearOfPublication = yearOfPublication;
			Genre = genre;
			Price = price;
			Quantity = quantity;
		}

	}
}
