using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if false
            //  Задание 1: Создайте generic класс Стека. Реализуйте стандартные методы и свойства для работы стека:
            //    − pop;
            //    − push;
            //    − peek;
            //    − count.

            StackT<int> stack = new StackT<int>();

            stack.Push(254);
            stack.Push(12);
            stack.Push(23);
            stack.Push(101);
            stack.Show();
            Console.WriteLine("\nPeek " + stack.Peek() + "\n");
            Console.WriteLine($"Count = {stack.GetCount()}");

            stack.Pop();
            Console.WriteLine();
            stack.Show();
            Console.WriteLine("\nPeek " + stack.Peek() + "\n");
            Console.WriteLine($"Count = {stack.GetCount()}");

            stack.Pop();
            Console.WriteLine();
            stack.Show();
            Console.WriteLine();
            Console.WriteLine("\nPeek " + stack.Peek() + "\n");
            Console.WriteLine($"Count = {stack.GetCount()}");

            stack.Pop();
            Console.WriteLine();
            stack.Show();
            Console.WriteLine();
            Console.WriteLine("\nPeek " + stack.Peek() + "\n");
            Console.WriteLine($"Count = {stack.GetCount()}");

            stack.Pop();
            Console.WriteLine();
            stack.Show();
            Console.WriteLine();
            Console.WriteLine("\nPeek " + stack.Peek() + "\n");
            Console.WriteLine($"Count = {stack.GetCount()}");
            stack.Pop();

            Product product = new Product("Pen", 25.35);
            Product product1 = new Product("Notebook", 45.15);
            Product product2 = new Product("Line", 5.10);

            Console.WriteLine(" ----------------------Stack Product------------------------- ");
            StackT<Product> stack2 = new StackT<Product>();
            stack2.Push(product);
            stack2.Push(product1);
            stack2.Push(product2);
            stack2.Show();

            stack2.Pop();
            Console.WriteLine();
            stack2.Show();
            Console.WriteLine($"Count = {stack2.GetCount()}");

#endif

#if false
            //Задание 2: Создайте generic класс Очередь с приоритетами. Реализуйте стандартные методы и
            //свойства для работы очереди с приоритетами.

            QueuePriority<int> queue = new QueuePriority<int>(10);
            queue.Add(63, 0);
            queue.Add(23, 3);
            queue.Add(16, 2);
            queue.Add(33, 9);
            queue.Add(77, 5);

            queue.Show();

            int result;

            bool isExtracted = queue.Extract(out result);
            if (isExtracted)
            {
                Console.WriteLine($"Извлеченный элемент: {result}");
            }else
            {
                Console.WriteLine("Очередь пуста, невозможно извлечь элемент.");
            }

            bool isExtracted2 = queue.Extract(out result);
            if (isExtracted2)
            {
                Console.WriteLine($"Извлеченный элемент: {result}");
            }
            else
            {
                Console.WriteLine("Очередь пуста, невозможно извлечь элемент.");
            }

            queue.Show();
            Console.WriteLine($"Кол-во элементов = {queue.GetCount()}");

            Product product = new Product("Pen", 25.35);
            Product product1 = new Product("Notebook", 45.15);
            Product product2 = new Product("Line", 5.10);

            Console.WriteLine("\n----------------------Stack Product------------------------- \n");
            QueuePriority<Product> queue2 = new QueuePriority<Product>(10);

            queue2.Add(product, 0);
            queue2.Add(product1, 3);
            queue2.Add(product2, 2);

            queue2.Show();
#endif

#if false
            //  Задание 3: Создайте приложение для учёта сотрудников.Необходимо хранить следующую
            //  информацию:
            //    − ФИО
            //    − Должность
            //    − Заработная плата
            //    − Рабочий email
            //  Для хранения данных сотрудников используйте класс List<T>.Приложение должно предоставлять такую
            //  функциональность:
            //    − Добавление сотрудников
            //    − Удаление сотрудников
            //    − Изменение информации о сотрудниках
            //    − Поиск сотрудников по параметрам
            //    − Сортировка сотрудников по параметрам
            //  Для удобства использования создайте пользовательское меню. Организуйте возможность тестирования
            //  работы программы на уже готовом списке сотрудников

            Employee employee1 = new Employee();
            employee1.Fullname = "John Doe";
            employee1.Position = "Manager";
            employee1.Salary = 50000.0;
            employee1.Email = "john.doe@example.com";

            Employee employee2 = new Employee();
            employee2.Fullname = "Jane Smith";
            employee2.Position = "Developer";
            employee2.Salary = 60000.0;
            employee2.Email = "jane.smith@example.com";

            Employee employee3 = new Employee();
            employee3.Fullname = "Michael Johnson";
            employee3.Position = "Analyst";
            employee3.Salary = 55000.0;
            employee3.Email = "michael.johnson@example.com";

            Employee employee4 = new Employee();
            employee4.Fullname = "Emily Brown";
            employee4.Position = "Designer";
            employee4.Salary = 52000.0;
            employee4.Email = "emily.brown@example.com";

            Employee employee5 = new Employee();
            employee5.Fullname = "David Wilson";
            employee5.Position = "Engineer";
            employee5.Salary = 63000.0;
            employee5.Email = "david.wilson@example.com";

            Employee employee6 = new Employee();
            employee6.Fullname = "Emma Garcia";
            employee6.Position = "Project Manager";
            employee6.Salary = 70000.0;
            employee6.Email = "emma.garcia@example.com";

            Employee employee7 = new Employee();
            employee7.Fullname = "Christopher Martinez";
            employee7.Position = "Team Lead";
            employee7.Salary = 75000.0;
            employee7.Email = "christopher.martinez@example.com";

            Employee employee8 = new Employee();
            employee8.Fullname = "Olivia Lopez";
            employee8.Position = "Marketing Specialist";
            employee8.Salary = 58000.0;
            employee8.Email = "olivia.lopez@example.com";

            Employee employee9 = new Employee();
            employee9.Fullname = "Daniel Lee";
            employee9.Position = "Sales Representative";
            employee9.Salary = 54000.0;
            employee9.Email = "daniel.lee@example.com";

            Employee employee10 = new Employee();
            employee10.Fullname = "Sophia Taylor";
            employee10.Position = "HR Manager";
            employee10.Salary = 67000.0;
            employee10.Email = "sophia.taylor@example.com";

            EmployeeManagement emp = new EmployeeManagement(
                employee1,employee2, employee3, 
                employee4,employee5,employee6,
                employee7,employee8,employee9, employee10
            );

            int menu = -1;
            do
            {
                Console.WriteLine("\n---------MENU--------\n");
                Console.WriteLine("1. Show employee");
                Console.WriteLine("2. Delete employee");
                Console.WriteLine("3. Edit employee");
                Console.WriteLine("4. Search employee");
                Console.WriteLine("5. Sort employee");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Input: ");
                menu = int.Parse(Console.ReadLine());
                int id;
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        emp.Show();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n---------DELETE--------");
                        Console.WriteLine("Input Employee ID for deleting");
                        Console.WriteLine("-----------------------\n");
                        Console.Write($"ID: ");
                        id = int.Parse(Console.ReadLine());
                        emp.RemoveByID(id -1);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n---------EDIT--------");
                        Console.WriteLine("Input Employee ID for editing");
                        Console.WriteLine("-----------------------\n");
                        Console.Write($"ID: ");
                        id = int.Parse(Console.ReadLine());
                        emp.Edit(id - 1);
                        break;
                    case 4:
                        Console.Clear();
                        emp.ShowSearchMenu();
                        break;
                    case 5:
                        Console.Clear();
                        emp.ShowSortMenu();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        break;



                }
            } while (menu != 0);

#endif

            Console.ReadLine();
        }
    }
}
