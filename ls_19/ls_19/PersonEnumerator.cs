using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class PersonEnumerator : IEnumerator<PersonTwo>
    {
        PersonTwo[] people;
        int currentIndex = -1;

        public PersonEnumerator(PersonTwo[] arr) 
        {
            people = arr;
        }

        public PersonTwo Current
        {
            get { return people[currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < people.Length;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public IEnumerator<PersonTwo> GetEnumerator()
        {
            return new PersonEnumerator(people);
        }
    }
}
