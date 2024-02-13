using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_6_Перечилитель
{
    internal class Program
    {
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
            foreach (Person value in company)
            {
                Console.WriteLine(value.Name);
            }
            Console.WriteLine();

            Console.Read();
        }
    }
}
