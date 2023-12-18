using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ls_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if true
            // Наследование ***********************************************************************************

            /*
                Реализовать класс Человек, который хранит информацию о человеке:
                имя, фамилия, дата рождения. 
                Описать конструкторы и метод вывода информации на экран.
 
                Реализовать класс Сотрудник, производный от класса Человек.
                Добавить информацию о компании и заработной плате.
                Описать конструкторы и метод вывода информации на экран.
 
                Реализовать класс Студент, производный от класса Человек.
                Добавить информацию о Вузе и об оценках. 
                Реализовать свойство для определения среднего балла.
                Описать конструкторы и метод вывода информации на экран.
 
                Приведение типа: вверх, вниз.
             */

            // Наследование ***********************************************************************************

            Human human = new Human("Ruslan", "Dvornicov", new DateTime(1990, 10,26));
            Console.WriteLine(human);

            Employee employee = new Employee();
            employee.Show();
            Console.WriteLine();
            Console.WriteLine(employee);

            Employee employee2 = new Employee()
            {
                Name = "Marina",
                Surname = "Poplaveti",
                DateOfBird = new DateTime(1993, 2, 16),
                CompanyInfo = "Tesla.md",
                Salary = 25000
            };
            Console.WriteLine(employee2);

            Student student = new Student()
            {
                Name = "Ilon",
                Surname = "Maks",
                DateOfBird = new DateTime(1975, 2, 16),
                Vuz = "ItStep",
                Grades = new int[] { 1, 5, 7, 10, 12 }
            };
            Console.WriteLine(student);
            Console.WriteLine();
            student.Show();
            Console.WriteLine("\n\n------------------------------------------------------------------------------------------\n");

            // ---------------------------------------------------------------------------------------------

            Human[] peoples = new Human[] {human, employee2, student, new Human("Eugeniu", "Davnii", new DateTime(2002,11,18)) };

            Console.WriteLine("Массив обьектов: \n");
            foreach (var people in peoples)
            {
                Console.WriteLine(people);
            }

            // ---------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n------------------------------------------------------------------------------------------\n");

            Human h = student;
            Console.WriteLine(h.Surname); // Приведение вверх
            // Console.WriteLine(h.Vuz); // Ошибка ! - нужно приведение типа (приведение вниз)
            Console.WriteLine("Vuz : " + ((Student)h).Vuz);

            Human t = new Human();
            t = student;
            Console.WriteLine("Vuz : " + ((Student)t).Vuz);

            Student st = (Student)t;
            Console.WriteLine("Vuz : " + st.Vuz);

            //Human tt = new Human();
            //Student st2 = (Student)tt;
            //Console.WriteLine("Vuz : " + st2.Vuz);

            Human ttt = new Student();
            Student st2 = (Student)ttt;
            Console.WriteLine("Vuz : " + st2.Vuz);

            try 
            {
                Human tt = new Human();
                Student st23 = (Student)tt;
                Console.WriteLine("Vuz : " + st23.Vuz);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            //Оператор as:
            //    -Используется для приведения типов.
            //    - Если приведение невозможно, то as возвращает null, а не генерирует исключение.
            //    -Предпочтительно использовать as, когда вы хотите выполнить приведение типа
            //      и готовы обрабатывать null в случае неудачи.

            Human hu = new Employee();
            Employee emp = hu as Employee;

            if (emp != null)
            {
                Console.WriteLine("Приведение удалось");
                Console.WriteLine($"Company: {emp.CompanyInfo}");
            }else
            {
                Console.WriteLine("Приведение не удалось");
            }

            Console.WriteLine();

            //Оператор is проверка:

            Human human1 = new Student();
            if (human1 is Student)
            {
                Console.WriteLine("Представляет тип Student");
                Console.WriteLine((human1 as Student).Vuz);
            }else
            {
                Console.WriteLine("Не является обьектом типа студент");
            }
            Console.WriteLine();

            //Оператор is проверка и создание локальной пересенной:

            Human human2 = new Employee();
            if (human2 is Employee myEmployee)
            {
                Console.WriteLine("Представляет тип Employee");
                Console.WriteLine(myEmployee.Salary);
            }
            else
            {
                Console.WriteLine("Не является обьектом типа Emplayee");
            }

            Console.WriteLine();

            // ---------------------------------------------------------------------------------------------
            Console.WriteLine("\n\n------------------------------------------------------------------------------------------\n");

            Human[] p = new Human[] { human, employee2, student, new Human("Eugeniu", "Davnii", new DateTime(2002, 11, 18)) };

            Console.WriteLine("Массив обьектов: \n");
            foreach (var item in p)
            {
                Console.WriteLine(item);
                if (item is Student) 
                {
                    Console.WriteLine($"Средний балл: {(item as Student).avgGrades()}\n"); 
                }
                if (item is Employee result) 
                {
                    Console.WriteLine($"Заработная плата: {result.Salary}\n");
                }
            }

#endif
            Console.ReadLine();
        }
    }
}
