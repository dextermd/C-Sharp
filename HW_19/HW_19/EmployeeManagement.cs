using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_19
{
    internal class EmployeeManagement : IEnumerable
    {
        private Dictionary<string, string> employee = new Dictionary<string, string>();
        public EmployeeManagement() { }
        
        public void AddEmployee(string key, string value) { employee[key] = value; }
        public void RemoveEmployee(string key) {  employee.Remove(key); }
        public void GetEmployee(string key) 
        {
            if (employee.ContainsKey(key))
                Console.WriteLine(employee[key]);
            else Console.WriteLine("Такого ключа нету");
        }
        
        public void EditEmployee(string key, string newKey, string password)
        {
            if (!employee.ContainsKey(key))
                Console.WriteLine("Такого ключа нету");
            else
            {
                employee.Remove(key);
                employee.Add(newKey, password);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return employee.GetEnumerator();
        }

        public void Show()
        {
            foreach (var item in employee)
            {
                Console.WriteLine(item);
            }
        }
    }
}
