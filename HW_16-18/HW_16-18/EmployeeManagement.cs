using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class EmployeeManagement : IEnumerable<Employee>
    {
        public List<Employee> EmployeeList;

        public EmployeeManagement() {}
        public EmployeeManagement(List<Employee> employeeList)
        {
            EmployeeList = employeeList;
        }
        public EmployeeManagement(params Employee[] employees)
        {
            EmployeeList = new List<Employee>();

            if (employees != null)
            {
                foreach (Employee employee in employees)
                {
                    EmployeeList.Add(employee);
                }
            }
        }
        public void Add(Employee employee)
        {
            EmployeeList.Add(employee);
        }
        public void AddByParameters(string fullname, string position, double salary, string email)
        {
            Employee employee = new Employee(fullname, position, salary, email);
            EmployeeList.Add(employee);
        }
        public void RemoveByID(int id)
        {
            Employee employee = EmployeeList[id];
            EmployeeList.Remove(employee);
        }

        public void Edit(int id)
        {
            Employee selectEmp = EmployeeList[id];
            selectEmp.Edit();
        }
        public void Show(List<Employee> list)
        {
            Console.WriteLine("Вы нашли:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        public void Show()
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                Console.Write($"ID:             {i + 1}");
                Console.WriteLine(EmployeeList[i]);
            }
        }
        public IEnumerator<Employee> GetEnumerator()
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                yield return EmployeeList[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                yield return EmployeeList[i];
            }
        }
        public void ShowSearchMenu()
        {
            int menu;
            List<Employee> listTmp = new List<Employee>();
            string tmp;
            int summa;
            do
            {
                Console.WriteLine("\n---------SEARCH--------\n");
                Console.WriteLine("1. Search by fullname");
                Console.WriteLine("2. Search by position");
                Console.WriteLine("3. Search by salary");
                Console.WriteLine("4. Search by email");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Input: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n---------SEARCH BY FULLNAME--------");
                        Console.WriteLine("Input Fullname for search");
                        Console.WriteLine("-----------------------------------\n");
                        Console.Write($"Input: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < EmployeeList.Count; i++)
                        {
                            if (EmployeeList[i].Fullname.Equals(tmp))
                            {
                                listTmp.Add(EmployeeList[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n---------SEARCH BY POSITION--------");
                        Console.WriteLine("Input Position for search");
                        Console.WriteLine("-----------------------------------\n");
                        Console.Write($"Input: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < EmployeeList.Count; i++)
                        {
                            if (EmployeeList[i].Position.Equals(tmp))
                            {
                                listTmp.Add(EmployeeList[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n---------SEARCH BY SALARY--------");
                        Console.WriteLine("Input Salary for search");
                        Console.WriteLine("---------------------------------\n");
                        Console.Write($"Input: ");
                        summa = int.Parse(Console.ReadLine());
                        for (int i = 0; i < EmployeeList.Count; i++)
                        {
                            if (EmployeeList[i].Salary.Equals(summa))
                            {
                                listTmp.Add(EmployeeList[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n---------SEARCH BY EMAIL--------");
                        Console.WriteLine("Input Email for search");
                        Console.WriteLine("--------------------------------\n");
                        Console.Write($"Input: ");
                        tmp = Console.ReadLine();
                        for (int i = 0; i < EmployeeList.Count; i++)
                        {
                            if (EmployeeList[i].Email.Equals(tmp))
                            {
                                listTmp.Add(EmployeeList[i]);
                            }
                        }
                        Show(listTmp);
                        listTmp.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }

        public void ShowSortMenu()
        {
            int menu;
            do
            {
                Console.WriteLine("\n---------SORT--------\n");
                Console.WriteLine("1. Sort by fullname");
                Console.WriteLine("2. Sort by position");
                Console.WriteLine("3. Sort by salary");
                Console.WriteLine("4. Sort by email");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\n---------------------\n");
                Console.Write($"Input: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n---------SORT BY FULLNAME--------");
                        Console.WriteLine("---------------------------------\n");
                        EmployeeList.Sort((x, y) => x.Fullname.CompareTo(y.Fullname));
                        Show();
                        menu = 0;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n---------SORT BY POSITION--------");
                        Console.WriteLine("---------------------------------\n");
                        EmployeeList.Sort((x, y) => x.Position.CompareTo(y.Position));
                        Show();
                        menu = 0;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n---------SORT BY SALARY--------");
                        Console.WriteLine("-------------------------------\n");
                        EmployeeList.Sort((x, y) => x.Salary.CompareTo(y.Salary));
                        Show();
                        menu = 0;
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n---------SORT BY EMAIL--------");
                        Console.WriteLine("------------------------------\n");
                        EmployeeList.Sort((x, y) => x.Email.CompareTo(y.Email));
                        Show();
                        menu = 0;
                        break;
                    case 0:
                        Console.Clear();
                        break;
                }
            } while (menu != 0);
        }
    }
}
