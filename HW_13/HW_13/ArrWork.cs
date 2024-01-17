using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    public delegate int[] ArrWorkDelegate(int[] arr);
    public delegate int ArrCountWorkDelegate(int[] arr);
    internal class ArrWork
    {
        public int[] GetEven(int[] arr) => arr.Where(a => a % 2 == 0).ToArray();
        public int[] GetOdd(int[] arr) => arr.Where(a => a % 2 != 0).ToArray();
        public int GetEvenCount(int[] arr) => arr.Count(a => a % 2 == 0);
        public int GetOddCoun(int[] arr) => arr.Count(a => a % 2 != 0);
        public int[] GetPrime(int[] arr) => arr.Where(a => IsPrime(a)).ToArray();
        public int GetPrimeCount(int[] arr) => arr.Count(a => IsPrime(a));
        public int[] GreaterThanZero(int[] arr) => arr.Where(a => a > 0).ToArray();
        public int GreaterThanZeroCount(int[] arr) => arr.Count(a => a > 0);
        public int[] LessThanZero(int[] arr) => arr.Where(a => a < 0).ToArray();
        public int LessThanZeroCount(int[] arr) => arr.Count(a => a < 0);


        public string Show(int[] arr) => string.Join(", ", arr);

        private static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

    }
}
