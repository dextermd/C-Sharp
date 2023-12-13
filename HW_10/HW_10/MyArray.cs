using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ls_10
{
    internal class MyArray
    {
        private int[] arr;

        public MyArray() : this(0) { }
        public MyArray(int num)
        {
            arr = new int[num];
        }
        public MyArray(params object[] parameters)
        {
            int size = parameters.Length;
            arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = (int)parameters[i];
            }
        }
        public void Show()
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > arr.Length)
                {
                    throw new ArgumentException("Error index");
                }
                return arr[index];
            }
            set
            {
                if (index < 0 || index > arr.Length)
                {
                    throw new ArgumentException("Error index");
                }
                arr[index] = value;
            }
        }  
        public static MyArray operator +(MyArray objLeft, MyArray objRight)
        {
            return new MyArray() { arr = objLeft.arr.Concat(objRight.arr).ToArray() };
        }
    }
}
