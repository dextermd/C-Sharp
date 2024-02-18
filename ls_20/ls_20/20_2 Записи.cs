// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

/*
 Records представляют новый ссылочный тип, который появился в C#9. 
Ключевая особенность records состоит в том, 
что они могут представлять неизменяемый (immutable) тип, 
который по умолчанию обладает рядом дополнительных возможностей 
по сравнению с классами и структурами. 

Зачем нам нужны неизменяемые типы? 
    - Такие типы более безопасны в тех ситуациях, когда нам надо гарантировать, 
        что данные объекта не будут изменяться.     
    - Записи также  позволяют упростить создание классов, представляющих данные (Data Classes). 
    - Записи автоматически предоставляют реализацию нескольких часто используемых методов, 
      таких как Equals, GetHashCode, ToString, что делает их удобными для представления данных.

    В .NET в принципе уже есть неизменяемые типы, например, String.

Стоит отметить, что начиная с версии C# 10 добавлена поддержка структур record, 
соответственно мы можем создавать record-классы и record-структуры.
 */

#if false


Console.WriteLine("Hello, World!");

Test test = new Test() { A = 10 };
Console.WriteLine(test.A);


#endif

//----------------------------------------------
ClassMy class1 = new ClassMy() { name = "MyClass" };
ClassMy class2 = new ClassMy() { name = "MyClass" };
Console.WriteLine(class1.name);
Console.WriteLine(class1);
Console.WriteLine($"{class1.Equals(class2)}");// false

Person person = new Person("Kate", 21);
Person person2 = new Person("Kate", 21);
Console.WriteLine(person);//Person { Name = Kate, Age = 21 }
//person.Name = "Timur";// init - неизменяемое поле
//person.Age = 22;
Console.WriteLine(person);
Console.WriteLine($"{person.Equals(person2)}");// true
Console.WriteLine($"{person}=={person2} => {person==person2}");// true
Console.WriteLine($"{person.Name}=={person2.Name} => {person==person2}");// true

// Копия объекта (копия ссылки)
var person3 = person;
Console.WriteLine(person);
person.Age = 22;
Console.WriteLine(person3);

// Оператор with
var person4 = person with { };// независимая копия всего объекта
person.Age = 24;
Console.WriteLine(person4);

var person5 = person with { Name = "Elena"};// в скобках то, что хотим изменить
Console.WriteLine(person5);

// Деконструкция
var (personName,personAge) = person5;
Console.WriteLine($"{personName}  {personAge}");

// Позиционный records -  неизменяемый объект по умолчанию
Product product = new Product("apple", 15.25);
Console.WriteLine(product);
//product.price = 12.14;


Product2 product2 = new Product2("banana", 20.89) { MadeIn = "Moldova" };
Console.WriteLine(product2);//Product2 { name = banana, price = 20,89, MadeIn = Moldova }

//product2.price = 1.12;
//product2.MadeIn = "Африка";
Console.WriteLine(product2);

//Позиционный records - структура - по умолчанию изменяемая
Book book = new Book("Преступление и наказание","Достоевский", 500.56);
Console.WriteLine(book);
//book.price = 1250.00;//+ readonly
Console.WriteLine(book);

Console.Read();

public record   Person
//public record class Person
{
    public string Name { get; /*set*/init; }//immutable
    public int Age { get; set/*init*/; }//immutable
    public Person(string name, int age)=>(Name, Age)=(name, age);
    public void Deconstruct(out string name, out int age)=>(name, age)=(Name, Age);
}

// Позиционный records
public record class Product(string name, double price);

// Позиционный records + стандартное определение свойства
public record class Product2(string name, double price)
{
    public string MadeIn { get; /*set*/init; } = "unknown";
}

//Позиционный records - структура 
public readonly record struct Book(string name, string author, double price);
class ClassMy
{
    public string name ;
}
