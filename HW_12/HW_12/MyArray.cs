using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class MyArray : IOutput, IMath, ISort
    {
		static readonly int Size = 5;
		private int[] arr;
		public int[] Arr
		{
			get { return arr; }
			set { arr = value; }
		}
		public MyArray() 
		{
			arr = new int[Size];
			arr[0] = 64;
			arr[1] = 97;
			arr[2] = 14;
			arr[3] = 44;
			arr[4] = 39;
		}
		public MyArray(int[] arr) => Arr = arr;
        public MyArray(MyArray obj)
        {
            int[] tmpArr = new int[obj.Arr.Length];
            for (int i = 0; i < tmpArr.Length; i++)
            {
                tmpArr[i] = obj.Arr[i];
            }
            Arr = tmpArr;
        }
        public void Show()
        {
            foreach (var item in Arr)
            {
                Console.Write(item + " ");
            }
        }
        public void Show(string info)
        {
            Show();
			Console.Write($" {info}");
        }
        public int Max() => Arr.Max();
        public int Min() => Arr.Min();
        public float Avg() => (float)Arr.Average();
        public bool Search(int valueToSearch) => Arr.Contains(valueToSearch);
        public void SortAsc()
        {
            int tmp;
            for (int i = 0; i < Arr.Length; i++)
            {
                for (int j = 0; j < Arr.Length - i - 1; j++)
                {
                    if (Arr[j] > Arr[j + 1])
                    {
                        tmp = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = tmp;
                    }
                }
            }
        }
        public void SortDesc()
        {
            int tmp;
            for (int i = 0; i < Arr.Length; i++)
            {
                for (int j = 0; j < Arr.Length - i - 1; j++)
                {
                    if (Arr[j] < Arr[j + 1])
                    {
                        tmp = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = tmp;
                    }
                }
            }
        }
        public void SortByParam(bool isAsc)
        { 
            if (isAsc) SortAsc();
            else SortDesc();
        }
    }
}
