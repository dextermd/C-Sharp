using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Car: IComparable
    {
		private string marka;
		private double speed;
		private decimal price;

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}


		public double Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		public string Marka
		{
			get { return marka; }
			set { marka = value; }
		}
		public Car() :this("", 0.0, 0.0M){ }

		public Car(string marka, double speed, decimal price) 
		{
			Marka = marka;
			Speed = speed;
			Price = price;
		}

		public override string ToString()
		{
			return $"Marka: {Marka}, Speed: {Speed}, Price: {Price:F2}";
		}
        public int CompareTo(object obj)
        {
            if (obj is Car)
            {
                return Speed.CompareTo((obj as Car).Speed);
            };

            throw new NotImplementedException();

        }


    }
}
