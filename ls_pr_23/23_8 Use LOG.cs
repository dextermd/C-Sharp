﻿
using Serilog;

namespace _18_LOG
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //***Установить пакет Serilog через NuGet Package Manager Console
            //using Serilog;

#if false

            // Тестирование:
            //Настройка логгера
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            // Пример использования логгера
            Log.Information("Привет, это пример логирования в консоли!");
            
            //Важно вызвать CloseAndFlush, чтобы убедиться,
            //что все логи записаны перед завершением программы
            Log.CloseAndFlush();

#endif

#if false

            //-----------------------------------------------
            // Настройка логгера с файловым синком
            //"Синк" (sink) в данном контексте означает место,
            //куда логгер будет направлять свои данные. 
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"..\..\..\mylog.txt")
                .CreateLogger();

            // Пример использования логгера
            Log.Information("Привет, это пример логирования в консоли и файл!");

            // Важно вызвать CloseAndFlush, чтобы убедиться,
            // что все логи записаны перед завершением программы
            Log.CloseAndFlush();

            
#endif
            //---------------------------------------------------
#if false


            // Настройка логгера с форматированием и уровнями логирования
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(@"..\..\..\mylog_level.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .MinimumLevel.Debug()  // Установите желаемый уровень логирования (Debug, Information, Warning, Error, Fatal)
                .CreateLogger();

            // Пример использования логгера с разными уровнями логирования
            Log.Debug("Это сообщение отладки");
            Log.Information("Это информационное сообщение");
            Log.Warning("Это предупреждение");
            Log.Error("Это сообщение об ошибке");
            Log.Fatal("Это фатальная ошибка\n");

            // Важно вызвать CloseAndFlush, чтобы убедиться, что все логи записаны перед завершением программы
            Log.CloseAndFlush();
#endif
            //------------------------------------------------------

#if false

            // Настройка логгера с файловым синком
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"..\..\..\mylog_exp.txt")
                .CreateLogger();

            try
            {
                int[] myArray = new int[3];
                int index = 5; // Попытка обратиться к индексу, выходящему за границы массива

                // Попытка записи значения в массив по неверному индексу
                myArray[index] = 42;
            }
            catch (Exception ex)
            {
                // Запись исключения в лог
                Log.Error(ex, "Произошло исключение при записи в массив");
            }
            finally
            {
                // Важно вызвать CloseAndFlush, чтобы убедиться, что все логи записаны перед завершением программы
                Log.CloseAndFlush();
            }

#endif

#if true

            //-----------------------------------------
            // Настройка логгера с консольным и файловым синками
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"..\..\..\log_func.txt")
                .CreateLogger();

            try
            {
                Log.Information("Приложение начало выполнение.");

                // Пример операции
                int result = Divide(10, 0);

                Log.Information("Результат деления: {Result}", result);

                // Имитация исключения
                int[] myArray = new int[3];
                int index = 5;
                myArray[index] = 42;

                Log.Information("Приложение успешно завершило выполнение.");
            }
            catch (Exception ex)
            {
                // Запись исключения в лог
                Log.Error(ex, "Произошло исключение в приложении.");
            }
            finally
            {
                // Важно вызвать CloseAndFlush, чтобы убедиться, что все логи записаны перед завершением программы
                Log.CloseAndFlush();
            }

            
#endif

            Console.Read();
        }
        static int Divide(int dividend, int divisor)
        {
            try
            {
                // Попытка деления
                return dividend / divisor;
            }
            catch (DivideByZeroException ex)
            {
                // Запись исключения в лог
                Log.Error(ex, "Произошло деление на ноль.");
                throw; // Переброс исключения после записи в лог
            }
        }
    }
    
}

/*
 Методы WriteTo.Console и WriteTo.File в библиотеке Serilog 
 используются для настройки различных синков (мест, куда будут направляться логи). 
 Вот краткое пояснение параметров для этих методов:

WriteTo.Console:  
        outputTemplate (опциональный) - Определяет формат вывода логов в консоль. 
        В примере используется шаблон, который указывает, 
        как должна быть представлена каждая запись лога в консоли. 
        Например, {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception} 
        означает, что будут выводиться время, уровень лога, сообщение, новая строка 
        и, при наличии, информация об исключении.

WriteTo.File:

        outputTemplate (опциональный) - Аналогично WriteTo.Console, определяет формат вывода логов в файл.
        path (обязательный) - Путь к файлу, в который будут записываться логи.
        rollingInterval (опциональный) - Устанавливает интервал для создания новых файлов логов 
        (например, RollingInterval.Day для создания нового файла каждый день).
 
 */
//----------------------------------------------------------------
/*
 Уровни логирования - это способ организации сообщений в журналах (логах) 
 в зависимости от их важности или уровня критичности. 
 Они помогают отслеживать и анализировать работу программы, 
 выявлять проблемы и улучшать производительность. 
 Различные системы логирования могут иметь свои собственные уровни, 
 но общие уровни включают следующие:

TRACE (трассировка): 
                Самый низкий уровень. 
                Используется для наиболее подробных записей, которые обычно не нужны в продакшене. 
                Они могут содержать информацию о том, 
                какой код выполняется и какие значения принимают переменные.

DEBUG (отладка): 
                Используется для записи отладочной информации. 
                Эти сообщения предназначены для помощи в идентификации проблем во время разработки. 
                В продакшене этот уровень логирования обычно отключен из-за избыточной детализации.

INFO (информация): 
                Общие информационные сообщения о ходе выполнения программы. 
                Это может включать в себя важные события или состояния, 
                которые могут быть полезными для мониторинга.

WARN (предупреждение): 
                Информация об условиях, которые, хотя и не являются ошибками, 
                могут привести к нежелательным последствиям. 
                Это может быть использовано для предварительного предупреждения о потенциальных проблемах.

ERROR (ошибка): 
                Сообщения об ошибках, которые привели к некорректному выполнению программы. 
                Эти сообщения помогают идентифицировать и устранять проблемы.

FATAL (фатальная ошибка): 
                Самый высокий уровень. Используется для критических ошибок, 
                после которых невозможно продолжить нормальное выполнение программы. 
                Это может привести к завершению работы приложения.

Выбор уровня логирования зависит от конкретных требований вашего приложения и того,
какие события вы считаете важными для отслеживания. 

В продакшене часто используется комбинация INFO, WARN, ERROR и FATAL,
в то время как во время разработки могут быть полезными также DEBUG и TRACE.
 */