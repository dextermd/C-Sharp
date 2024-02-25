// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;


// сохранение данных
using (FileStream fs = new FileStream(@"..\..\..\user.json", FileMode.Create))
{
    Person p = new Person("Alexandr", 37);
    await JsonSerializer.SerializeAsync<Person>(fs, p);

    Console.WriteLine("Data has been saved to file");
}

// чтение данных
using (FileStream fs = new FileStream(@"..\..\..\user.json", FileMode.Open))
{
    //Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);
    //Person person = await JsonSerializer.DeserializeAsync<Person>(fs)??new Person();

    Person person = await JsonSerializer.DeserializeAsync<Person>(fs);
    if (person != null)
    {
        Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
    }
    else
    {
        Console.WriteLine("Ошибка");
    }
}

Console.ReadLine();

//-----------------Описание класса либо ниже, либо в отдельном файле
internal class Person
{
    public string Name { get; }

    //[JsonIgnore]
    public int Age { get; set; }
    public Person(string name="", int age=0)
    {
        Name = name;
        Age = age;
    }
}


/*
 JSON (JavaScript Object Notation) является одним из наиболее популярных форматов 
 для хранения и передачи данных. И платформа .NET предоставляет функционал для работы с JSON.

Основная функциональность по работе с JSON 
сосредоточена в пространстве имен System.Text.Json. 

Ключевым типом является класс JsonSerializer, 
который и позволяет сериализовать объект в json и, 
наоборот, десериализовать код json в объект C#.
 */