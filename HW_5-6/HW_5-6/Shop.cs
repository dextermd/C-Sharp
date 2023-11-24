using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_6
{
    //Задание 4: Создайте класс “Магазин”. Необходимо хранить в полях класса: название магазина,
    //адрес, описание профиля магазина, контактный телефон, контактный e-mail.Реализуйте методы
    //класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы
    //класса.
    internal class Shop
    {
        private string name;
        private string address;
        private string description;
        private string phone;
        private string email;

        public void SetName(string name) { this.name = name; }
        public void SetAddress(string address) { this.address = address; }
        public void SetDescription(string description) { this.description = description; }
        public void SetPhone(string phone) { this.phone = phone; }
        public void SetEmail(string email) { this.email = email; }
        public string GetName() { return this.name; }
        public string GetAddress() { return this.address; }
        public string GetDescription() { return this.description; }
        public string GetPhone() { return this.phone; }
        public string GetEmail() { return this.email; }

        public void Init()
        {
            Console.Write("Введите название магазина: ");
            name = Console.ReadLine();

            Console.Write("Введите адрес магазина: ");
            address = Console.ReadLine();

            Console.Write("Введите описание магазина: ");
            description = Console.ReadLine();

            Console.Write("Введите телефон магазина: ");
            phone = Console.ReadLine();

            Console.Write("Введите e-mail магазина: ");
            email = Console.ReadLine();
        }
        public void Show()
        {
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Описание: {description}");
            Console.WriteLine($"Телефон: {phone}");
            Console.WriteLine($"E-mail: {email}");
        }

    }
}
