using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://learn.microsoft.com/ru-ru/dotnet/api/system.object.finalize?view=net-8.0&redirectedfrom=MSDN#System_Object_Finalize

namespace _2_Финализатор
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите Enter для создания объектов...");
            Console.ReadLine();
            Test();

            Person[] obj = new Person[50];
            for (int i = 0; i < 50; i++)
                obj[i] = new Person(i+1);

            // Посмотреть ildasm

            // Явный вызов сборщика мусора
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Объекты созданы. Нажмите Enter для завершения программы...");
            
            Console.ReadLine();
        }
        
        public static void Test()
        {
            Person tom = new Person(111);
        }
    }
    class Person
    {
        public int Id { get; }
        public Person(int id) => Id = id;
        ~Person()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Объект {Id} уничтожен");
            Thread.Sleep(200);
        }
    }
    
}

/*
 Различия в поведении могут возникнуть из-за особенностей среды выполнения и фреймворка. 
В .NET Core и .NET Framework есть некоторые различия, включая способы, 
которыми они обрабатывают финализацию объектов.

В .NET Framework используется механизм CLR (Common Language Runtime), 
который может обеспечивать более предсказуемое поведение финализации объектов.

В .NET Core, который является более новой и кроссплатформенной версией .NET, 
реализация CLR может быть менее предсказуемой из-за адаптации к 
различным операционным системам и архитектурам.

Также, стоит уточнить, что важно избегать зависимости от конкретного поведения 
сборщика мусора в вашем коде, поскольку это может изменяться между версиями 
фреймворка или даже в рамках одной и той же версии в разных условиях выполнения.

Если вам нужно точное управление жизненным циклом объекта, 
лучше использовать интерфейс IDisposable и метод Dispose 
для освобождения ресурсов в явном порядке. 

Финализаторы (~Finalize) в C# следует использовать 
с осторожностью из-за неопределенности времени выполнения.
 
 */