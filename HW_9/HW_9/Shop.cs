using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_9
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
        private int area;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Description { get => description; set => description = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int Area { get => area;
            set 
            { 
                area = value;
                if (area < 0)
                    area = 0;
            }
        }

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

        public Shop(Shop obj)
        {
            Name = obj.Name;
            Address = obj.Address;
            Description = obj.Description;
            Phone = obj.Phone;
            Email = obj.Email;
            Area = obj.Area;
        }

        public Shop()
        {
            Name = "No Name";
            Address = "No Address";
            Description = "No Description";
            Phone = "No Phone";
            Email = "No Email";
            Area = 0;
        }
        public Shop(string name, string address, string description, string phone, string email, int area)
        {
            Name = name;
            Address = address;
            Description = description;
            Phone = phone;
            Email = email;
            Area = area;
        }

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
            Console.WriteLine($"Area: {area}");
        }

        public override string ToString()
        {
            return $"\nНазвание:      {Name}\n" +
                   $"Адрес:         {address}\n" +
                   $"Описание:      {description}\n" +
                   $"Телефон:       {phone}\n" +
                   $"E-mail:        {email}\n" +
                   $"Площадь:       {area}\n";
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static Shop operator +(Shop a, int b)
        {
            return new Shop()
            {
                Name = a.name,
                Address = a.address,
                Description = a.description,
                Phone = a.phone,
                Email = a.email,
                Area = a.Area + b
            };
        }
        public static Shop operator -(Shop a, int b)
        {
            return new Shop() 
            {
                Name = a.name,
                Address = a.address,
                Description = a.description,
                Phone = a.phone,
                Email = a.email,
                Area = a.Area - b
            };
        }
        public static bool operator ==(Shop shopLeft, Shop shopRight)
        {
            return shopLeft.Area == shopRight.Area;
        }
        public static bool operator !=(Shop shopLeft, Shop shopRight)
        {
            return shopLeft.Area != shopRight.Area;
        }
        public static bool operator <(Shop shopLeft, Shop shopRight)
        {
            return shopLeft.Area < shopRight.Area;
        }
        public static bool operator >(Shop shopLeft, Shop shopRight)
        {
            return shopLeft.Area > shopRight.Area;
        }
    }
}
