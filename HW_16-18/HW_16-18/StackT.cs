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
            top = -1;
        }

        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty"); 
                return default(T);
            }
            return items[top--];
        }
        public void Push(T item)
        {
            if (top == items.Length - 1)
                Console.WriteLine("Stack is full");
            items[++top] = item;
        }

        public T Peek()
        {
            if (top == -1) { 
                Console.WriteLine("Stack is empty"); 
                return default(T); 
            }
            return items[top];
        }

        public void Show()
        {
            if (top == -1)
                Console.WriteLine("Stack is empty");

            for (int i = top; i >  -1 ; i--)
                Console.WriteLine($"{items[i]}");
        }
        public int GetCount() => top + 1;

    }
}
