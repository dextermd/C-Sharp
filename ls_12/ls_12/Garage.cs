using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_12
{
    internal class Garage : IEnumerable
    {
        private Car[] carArray;

        //public Garage() : this(0){ }
        public Garage()
        {
            carArray = new Car[5];
            carArray[0] = new Car("Dacia", 120, 9000);
            carArray[1] = new Car("Volvo", 200, 12000);
            carArray[2] = new Car("Ferrari", 320, 780000);
            carArray[3] = new Car("Porshe", 300, 50000);
            carArray[4] = new Car("Mercedes", 280, 30000);
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
    }
}
