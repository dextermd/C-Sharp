using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class PrimeNumbers : IEnumerable<long>
    {
        public long Min { get; set; }
        public long Max { get; set; }

        public PrimeNumbers() { }
        public PrimeNumbers(long min, long max) { Min = min; Max = max; }

        public IEnumerator<long> GetEnumerator()
        {
            for (long num = Min; num <= Max; num++)
                if (IsPrime(num))
                    yield return num;
        }

        private bool IsPrime(long number)
        {
            if (number <= 1)
                return false;

            for (long i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}
