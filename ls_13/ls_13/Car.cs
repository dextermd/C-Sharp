using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    internal class Car: IComparable, ICloneable
    {
		
		// Внутренний класс 
		internal class CarInfo
		{
			public string Number { get; set; }
			public int Year { get; set; }

            public CarInfo()
            {
                Number = "";
                Year = 0000;
            }
            public CarInfo(string number, int year)
            {
                Number = number;
				Year = year;
            }
        }

        // Статическое свойство только для чтения для удобства выбора критерия сортировки
        public static IComparer SortBySpeedDecr
		{
			get { return new SpeedCompareDecr(); }
		}
        // Статическое свойство только для чтения для удобства выбора критерия сортировки
        public static IComparer SortBySpeedIncr
        {
            get { return new SpeedCompareIncr(); }
        }

        public static IComparer SortByYearDecr
        {
            get { return new CarYearCompareDecr(); }
        }
        // Статическое свойство только для чтения для удобства выбора критерия сортировки
        public static IComparer SortByYearIncr
        {
            get { return new CarYearCompareIncr(); }
        }

        private string marka;
		private double speed;
		private decimal price;
		public CarInfo CarInformation { get; set; }

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
		public Car() :this("", 0.0, 0.0M, null){ }

		public Car(string marka, double speed, decimal price, CarInfo carInfo) 
		{
			Marka = marka;
			Speed = speed;
			Price = price;
            CarInformation = carInfo;
		}

		public override string ToString()
		{
			return $"Marka: {Marka}, Speed: {Speed}, Price: {Price:F2}, Номер: {CarInformation.Number}, Год: {CarInformation.Year}";
		}
        public int CompareTo(object obj)
        {
            if (obj is Car)
            {
                return Marka.CompareTo((obj as Car).Marka);
            };

            throw new NotImplementedException();

        }

        public object Clone()
        {
            //throw new NotImplementedException();
            // MemberwiseClone - создает поверхностную копию 
            Car car = MemberwiseClone() as Car;

			// для глубокого копирования ссылочного типа
			CarInfo carInfo = new CarInfo();
			carInfo.Number = CarInformation.Number;
			carInfo.Year = CarInformation.Year;
			car.CarInformation = carInfo;
	
            return car;
        }

		public Car Copy()
		{
			return new Car(this.Marka,Speed,Price, new CarInfo ( CarInformation.Number, CarInformation.Year ));

		}
    }
}
