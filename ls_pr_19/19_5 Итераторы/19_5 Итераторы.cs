using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_5_Итераторы
{
    internal class Program
    {
        class Numbers
        {
            int n;
            public Numbers(int n = 1) => this.n = n;

            public IEnumerator<int> GetEnumerator()
            {
                for (int i = 1; i <= n; i++)
                {
                    yield return i * i;
                }
            }
        }
        class WorkDays
        {
            public IEnumerator GetEnumerator()
            {
                yield return "Понедельник";
                yield return "Вторник";
                yield return "Среда";
                yield return "Четверг";
            }
        }
        static void Main(string[] args)
        {

            Person[] people = new Person[]
            {
                new Person("Ivanov"),
                new Person("Petrov"),
                new Person("Sidorov"),
                new Person("Sokolov"),
                new Person("Kotikov"),
                new Person("Dimov"),
                new Person("Kolom"),
                new Person("Kotikov 1"),
                new Person("Kotikov 2"),
            };

            Company company = new Company(people);
            foreach (Person value in company)//GetEnumerator()
            {
                Console.WriteLine(value.Name);
            }
            Console.WriteLine();

            //PrintValues(company);
            Console.WriteLine();
            foreach (Person value in company.GetEnumerator(3,6))//GetEnumerator(3,6))
            {
                Console.WriteLine(value.Name);
            }

            Console.WriteLine();
            Numbers numbers = new Numbers(10);
            foreach (int value in numbers)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            WorkDays workdays = new WorkDays();
            foreach (string value in workdays)
            {
                Console.WriteLine(value);
            }

            Console.Read();
        }
        public static void PrintValues(IEnumerable collection)
        {
            IEnumerator enumerator = collection.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine();
        }
    }
}
