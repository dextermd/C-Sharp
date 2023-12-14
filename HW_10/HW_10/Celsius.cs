using ls_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    internal class Celsius
    {
		private double temperature;

		public double Temperature
		{
			get { return temperature; }
            set { temperature = value; }
		}
        public Celsius() : this(0.0) { }
        public Celsius(double temperature)
        {
            Temperature = temperature;
        }
        public static implicit operator Fahrenheit(Celsius obj)
        {
            //Цельсий х 1,8 + 32 = Фаренгейт
            return new Fahrenheit() { Temperature = obj.Temperature * 1.8 + 32 };
        }
        public override string ToString()
        {
            return $"{temperature:F1}";
        }
    }
}
