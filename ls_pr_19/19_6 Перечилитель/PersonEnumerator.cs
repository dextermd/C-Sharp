using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_6_Перечилитель
{
    internal class PersonEnumerator: IEnumerator<Person>
    {
        Person[] people;
        int currentIndex = -1;

        public PersonEnumerator(Person []mas)
        {
            people = mas;
        }
        public Person Current //=> throw new NotImplementedException();
        {
            get { return people[currentIndex]; }
        }

        object IEnumerator.Current //=> throw new NotImplementedException();
        {
            get { return Current; }
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
           currentIndex++;
           return currentIndex < people.Length;
            //throw new NotImplementedException();
        }

        public void Reset()
        {
            currentIndex = -1;
            //throw new NotImplementedException();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return new PersonEnumerator(people);
        }
    }
}
