using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class QueuePriority<T> where T : IComparable<T>
    {
        private T[] w;
        private int[] p;
        private int MaxLength;
        private int Length;

        public QueuePriority(int m)
        {
            MaxLength = m;
            w = new T[MaxLength];
            p = new int[MaxLength];
            Length = 0;
        }

        public void Show()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("\n-----------------------------------\n");
                for (int i = 0; i < Length; i++)
                {
                    Console.WriteLine($"{w[i]} - {p[i]}\n\n");
                }
                Console.WriteLine("\n-----------------------------------\n");
            }
            else
            {
                Console.WriteLine("\nОчередь пуста\n");
            }
        }

        public void Clear() { Length = 0; }
        public bool IsEmpty() => Length == 0;
        public bool IsFull() => Length == MaxLength;
        public int GetCount() => Length;
        public void Add(T c, int pr)
        {
            if (!IsFull())
            {
                int index = 0;
                while (index < Length && pr.CompareTo(p[index]) <= 0)
                {
                    index++;
                }

                for (int i = Length - 1; i >= index; i--)
                {
                    w[i + 1] = w[i];
                    p[i + 1] = p[i];
                }

                w[index] = c;
                p[index] = pr;

                Length++;
            }
        }

        public bool Extract(out T v)
        {
            v = default(T);
            if (!IsEmpty())
            {
                int maxPri = p[0];
                int posMaxPri = 0;

                for (int i = 1; i < Length; i++)
                {
                    if (maxPri.CompareTo(p[i]) < 0)
                    {
                        maxPri = p[i];
                        posMaxPri = i;
                    }
                }

                T temp1 = w[posMaxPri];
                v = temp1;

                for (int i = posMaxPri; i < Length - 1; i++)
                {
                    w[i] = w[i + 1];
                    p[i] = p[i + 1];
                }
                Length--;
                return true;
            }
            return false;
        }
    }
}
