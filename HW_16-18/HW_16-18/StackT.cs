using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class StackT<T>
    {
        private const int MAX_SIZE = 10;
        private int size;
        private T[] items;
        private int top;

        public StackT(int size = MAX_SIZE)
        {
            this.size = size;
            items = new T[this.size];
        }

        public T Pop()
        {
            if (top > -1) 
                return items[--top];
            else Console.WriteLine("Stack is empty"); return default(T);
        }
        public void Push(T data) { if (top < size) items[top++] = data; }

        public void Peek()
        {
            if (top == 0)
                Console.WriteLine("Stack is empty");

            for (int i = top - 1; i >  -1 ; i--)
                Console.WriteLine($"{items[i]}");
        }
        public int GetCount() => top;

    }
}
