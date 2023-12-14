using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    internal class Fahrenheit
    {
        private double temperature;
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public Fahrenheit() : this(0.0) { }
        public Fahrenheit(double temperature)
        {
            Temperature = temperature;
        }
        public static implicit operator Celsius(Fahrenheit obj)
        {
            //(Фаренгейт — 32) : 1,8 = Цельсий
            return new Celsius() { Temperature = (obj.Temperature -32) / 1.8 };
        }
        public override string ToString()
        {
            return $"{temperature:F1}";
        }
    }
}
