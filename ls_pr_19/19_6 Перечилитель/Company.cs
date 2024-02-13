using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_6_Перечилитель
{
    internal class Company
    {
        Person[] staff;
        public Company(Person [] staff)
        {
            this.staff = staff;
        }
        public IEnumerator<Person> GetEnumerator()
        {
            return new PersonEnumerator(staff);
        }
    }
}
