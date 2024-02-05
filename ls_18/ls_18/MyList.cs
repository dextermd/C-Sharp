using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_18
{
    internal class MyList<T> : IEnumerable<Node<T>> where T : IComparable<T>
    {
        private Node<T> head;
        public int Count {  get; private set; }

        public void AddBegin(T data)
        {
            Node<T> node = new Node<T>(data);
            if(head == null)
                head = node;
            else
            {
                Node<T> t = head;
                head = node;
                node.Next = t;
            }
            Count++;
        }
        public bool Contains(T data)
        {
            Node<T> t = head;
            while(t != null)
            {
                if(t.Data.Equals(data))
                    return true;
                t = t.Next;
            }
            return false;
        }
        public void AddEnd(T data) 
        {
            Node<T> node = new Node<T>(data);

            if (head == null) 
                head = node;
            else
            {
                Node<T> t = head;
                while (t.Next != null)
                {
                    t = t.Next;
                }
                // Связь
                t.Next = node;
            }
            Count++;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> t = head;
            while (t != null)
            {
                yield return t;
                t = t.Next;
            }
        }

        public void Show() 
        {
            Node<T> t = head;
            while(t != null)
            {
                Console.WriteLine(t.Data + " ");
                t = t.Next; 
            }
            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> t = head;
            while (t.Next != null)
            {
                yield return t.Next;
            }
        }
    }
}
