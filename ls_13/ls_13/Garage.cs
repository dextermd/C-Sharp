using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_13
{
    internal class Garage : IEnumerable
    {
        private Car[] carArray;

        //public Garage() : this(0){ }
        public Garage()
        {
            carArray = new Car[5];
            carArray[4] = new Car("Mercedes", 280, 30000, new Car.CarInfo { Number = "QQW 418", Year = 1960 });
            carArray[2] = new Car("Ferrari", 320, 780000, new Car.CarInfo { Number = "AAS 111", Year = 2000 });
            carArray[3] = new Car("Porshe", 300, 50000, new Car.CarInfo { Number = "FFV 669", Year = 1999 });
            carArray[0] = new Car("Dacia", 120, 9000, new Car.CarInfo { Number = "AFE 963", Year = 2024 });
            carArray[1] = new Car("Volvo", 200, 12000, new Car.CarInfo { Number = "SFV 645", Year = 2017 });

        }
        public Garage(int size) 
        {
            carArray = new Car[size];
        }

        public IEnumerator GetEnumerator()
        {
            return carArray.GetEnumerator();
        }
        public void Sort()
        {
            //Array.Sort(carArray, (x, y) => x.Marka.CompareTo(y.Marka));
            Array.Sort(carArray);
        }
        public void Sort(IComparer compare)
        {
            Array.Sort(carArray, compare);
        }
    }
}
