using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_5_Итераторы
{
    internal class Person
    {
        public string Name { get;  }
        public Person(string name) => Name = name;
        public override string ToString() => Name;
    }

    class Company//:IEnumerable<Person>
    {
        Person []staff;

        public Company(Person[] staff)
        {
            this.staff = staff;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < staff.Length; i++)
            {
                yield return staff[i];
            }

            //return staff.Cast<Person>().GetEnumerator();// LINQ

            //return staff.GetEnumerator(); // ошибка

            //throw new NotImplementedException();
        }

        // Именованный итератор
        public IEnumerable<Person> GetEnumerator(int pos1, int pos2)
        {
            for (int i = pos1; i <= pos2; i++)
            {
                if(i==staff.Length)
                {
                    yield break;
                }
                else
                {
                    yield return staff[i];
                }
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //    //throw new NotImplementedException();
        //}

        // реализация IEnumerable:
        //public IEnumerator GetEnumerator()//1
        //{
        //    return staff.GetEnumerator();
        //    //throw new NotImplementedException();
        //}
    }
}
