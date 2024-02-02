using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_17
{
    internal class Product : IComparable<Product>, IEquatable<Product>
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private double price;

		public double Price
		{
			get { return price; }
			set { price = value; }
		}

        public override string ToString()
        {
			return $"{Name}\t{Price}";
        }
		public Product(string name, double price) 
		{
			this.name = name;
			this.price = price;
		}
        public int CompareTo(Product other)
        {
           return price.CompareTo(other.price);
        }

        public bool Equals(Product other)
        {
            return name.Equals(other.name);
        }
    }
}
