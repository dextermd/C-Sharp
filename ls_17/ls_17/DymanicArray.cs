using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Задача: Напишите обобщенную коллекцию динамического массива.
    Реализуйте возможность просмотра коллекции при помощи foreach.
    Напишите метод для добавления элемента в конец массива, 
    метод изменения размера(емкости) массива.
    Реализуйте индексатор для доступа к элементам коллекции.

    Напишите методы :
    - Resize для изменения емкости массива
    - Contains для поиска элемента в массиве.
*/

namespace ls_17
{
    internal class DymanicArray<T> : IEnumerable<T>
    {
        private T[] array;
        public int Count { get; private set; } // текущее кол-во элементов
        public int Capacity { get; private set; } // емкость

        public DymanicArray() : this(5) {}

        public DymanicArray(int length)
        {
            array = new T[length];
            Capacity = length;
            Count = 0;
        }
        public void Push(T item)
        {
            if(Count < Capacity)
            {
                array[Count++] = item;
            }
            else throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return ((IEnumerable<T>)array).GetEnumerator();
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //return ((IEnumerable<T>)array).GetEnumerator();
            for(int i = 0; i < Count; i++) 
            {
                yield return array[i];
            }
        }

        public T this[int index] // Перегрузка [] индексатора
        {
            get 
            { 
                if (index >= 0 && index < Count)
                {
                    return array[index];
                } else throw new IndexOutOfRangeException($"Неверный индекс {index}");
            }
            set 
            {
                if (index >= 0 && index < Count)
                {
                    array[index] = value;
                }
                else throw new IndexOutOfRangeException($"Неверный индекс {index}");
                
            }
        }
        public void Resize(int newLength)
        {
/*            T[] newArray = new T[newLength];

            int currCount = newArray.Length < array.Length ? newArray.Length : array.Length;
            for (int i = 0; i < currCount; i++)
            {
                newArray[i] = array[i];
            }
            Capacity = newLength;
            Count = Count < newLength ? Count : Capacity;
            array = newArray;*/

            Array.Resize(ref array, newLength);
            Capacity = newLength;
            Count = Count < newLength ? Count : Capacity;

        }

        public int Contains(T value)
        {
            return Array.FindIndex(array, x => x != null && x.Equals(value));
        }
    }
}
