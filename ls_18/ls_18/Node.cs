using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ls_18
{
    internal class Node<T> : IComparable<Node<T>>, IEquatable<Node<T>> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set;}

        public Node(T data)
        { 
            this.Data = data;
            Next = null;
        }

        public override string ToString()
        {
            return $"{Data}";
        }

        public int CompareTo(Node<T> other)
        {
            return Data.CompareTo(other.Data);
        }

        public bool Equals(Node<T> other)
        {
            if (other == null)
                return false;

            return Data.Equals(other.Data);
        }
    }
}
