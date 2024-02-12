using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class Company : IEnumerable<PersonTwo>
    {
        PersonTwo[] staff;


        public Company(PersonTwo[] staff)
        {
            this.staff = staff;
        }

        //public IEnumerator<PersonTwo> GetEnumerator()
        //{
        //    return new PersonEnumerator(staff);
        //}
        
        public IEnumerator<PersonTwo> GetEnumerator()
        {
            for (int i = 0; i < staff.Length; i++)
            {
                yield return staff[i];
            }

            //return staff.Cast<PersonTwo>().GetEnumerator(); // LINQ
        }

        // Именованный итератор
        public IEnumerator<PersonTwo> GetEnumerator(int pos1, int pos2)
        {
            for (int i = pos1; i <= pos2; i++)
            {
                if (i == staff.Length)
                    yield break;
                else
                    yield return staff[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < staff.Length; i++)
            {
                yield return staff[i];
            }

            //return staff.Cast<PersonTwo>().GetEnumerator(); // LINQ
        }

        /*      // IEnumerable без <>
                public IEnumerator GetEnumerator()
                {
                    return staff.GetEnumerator();
                }
        */
    }
}
