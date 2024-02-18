using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_5_Работа_с_файлами
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Классы File и FileInfo
            //using System.IO;
#if true

            //---------------------------------------------------
            //Получение информации о файле

            string path = @"J:\tmp\my1.txt"; // для Windows
            // string path = "/tmp/myfile.txt";  // для MacOS/Linux

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }

#endif

#if false

            //---------------------------------------------------
            //Удаление файла
            string path2 = @"J:\tmp\my1.txt";
            FileInfo fileInf2 = new FileInfo(path2);

            if (fileInf2.Exists)
            {
                fileInf2.Delete();
                // альтернатива с помощью класса File
                // File.Delete(path);
                Console.WriteLine("Файл удален");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

#endif

#if false

            //---------------------------------------------------
            //Перемещение файла

            string path3 = @"J:\tmp\exp.txt";
            string newPath = @"J:\tmp\NewDir\22.txt";// имя может быть другое
            FileInfo fileInf3 = new FileInfo(path3);
            if (fileInf3.Exists)
            {
                // Возможнные Exception, например:
                //System.IO.DirectoryNotFoundException если не найден путь
                //System.IO.IOException: 'Невозможно создать файл, так как он уже существует.
                fileInf3.MoveTo(newPath);

                // альтернатива с помощью класса File
                // File.Move(path, newPath);
                Console.WriteLine("Файл перемещен");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

#endif

#if false

            //---------------------------------------------------
            //Копирование файла

            string path4 = @"J:\tmp\1.txt";
            string newPath4 = @"J:\tmp\copy_1.txt";
            FileInfo fileInf4 = new FileInfo(path4);
            if (fileInf4.Exists)
            {
                fileInf4.CopyTo(newPath4, true);
                // альтернатива с помощью класса File
                // File.Copy(path4, newPath4, true);
                Console.WriteLine("Копия файла создана");
            }

            /*
             Метод CopyTo класса FileInfo принимает два параметра: 
             путь, по которому файл будет копироваться, и булевое значение, которое указывает,
             надо ли при копировании перезаписывать файл 
             (если true, как в случае выше, файл при копировании перезаписывается). 

             Если же в качестве последнего параметра передать значение false, 
             то если такой файл уже существует, приложение выдаст ошибку.

            Метод Copy класса File принимает три параметра: 
            путь к исходному файлу, путь, по которому файл будет копироваться, 
            и булевое значение, указывающее, будет ли файл перезаписываться.
             */

#endif
            //---------------------------------------------------
            //Чтение и запись файлов

            string mypath = "1.txt";

            string fileText = File.ReadAllText(mypath);
            Console.WriteLine(fileText);

            File.AppendAllText(mypath, "С. Есенин");

            fileText = File.ReadAllText(mypath);
            Console.WriteLine(fileText);


            Console.ReadLine();
        }
    }
}


/*
 -----------FileInfo
 -----------Некоторые полезные методы и свойства класса FileInfo:

CopyTo(path): копирует файл в новое место по указанному пути path

Create(): создает файл

Delete(): удаляет файл

MoveTo(destFileName): перемещает файл в новое место

 -----------Свойства:

Свойство Directory: получает родительский каталог в виде объекта DirectoryInfo

Свойство DirectoryName: получает полный путь к родительскому каталогу

Свойство Exists: указывает, существует ли файл

Свойство Length: получает размер файла

Свойство Extension: получает расширение файла

Свойство Name: получает имя файла

Свойство FullName: получает полное имя файла

 -----------File
 -----------Класс File реализует похожую функциональность с помощью статических методов:

Copy(): копирует файл в новое место

Create(): создает файл

Delete(): удаляет файл

Move: перемещает файл в новое место

Exists(file): определяет, существует ли файл
 */


/*
 ----------- Чтение и запись файлов
 ----------- В дополнение к вышерассмотренным методам класс File также предоставляет ряд методов 
             для чтения-записи текстовых и бинарных файлов:

AppendAllLines(String, IEnumerable<String>) / 
AppendAllLinesAsync(String, IEnumerable<String>, CancellationToken)
добавляют в файл набор строк. Если файл не существует, то он создается

AppendAllText(String, String) / 
AppendAllTextAsync(String, String, CancellationToken)
добавляют в файл строку. Если файл не существует, то он создается

byte[] ReadAllBytes (string path) / 
Task<byte[]> ReadAllBytesAsync (string path, CancellationToken cancellationToken)
считывают содержимое бинарного файла в массив байтов

string[] ReadAllLines (string path) / 
Task<string[]> ReadAllLinesAsync (string path, CancellationToken cancellationToken)
считывают содержимое текстового файла в массив строк

string ReadAllText (string path) / 
Task<string> ReadAllTextAsync (string path, CancellationToken cancellationToken)
считывают содержимое текстового файла в строку

IEnumerable<string> ReadLines (string path)
считывают содержимое текстового файла в коллекцию строк

void WriteAllBytes (string path, byte[] bytes) / 
Task WriteAllBytesAsync (string path, byte[] bytes, CancellationToken cancellationToken)
записывают массив байт в бинарный файл. Если файл не существует, он создается. Если существует, то перезаписывается

void WriteAllLines (string path, string[] contents) / 
Task WriteAllLinesAsync (string path, IEnumerable<string> contents, CancellationToken cancellationToken)
записывают массив строк в текстовый файл. Если файл не существует, он создается. Если существует, то перезаписывается

WriteAllText (string path, string? contents) / Task WriteAllTextAsync (string path, string? contents, CancellationToken cancellationToken)
записывают строку в текстовый файл. Если файл не существует, он создается. Если существует, то перезаписывается

Как видно, эти методы покрывают практически все основные сценарии - чтение и запись текстовых и бинарных файлов.
 */


/*
 Несколько причин, по которым асинхронные методы для работы с файлами могут быть полезными:

- Отзывчивость приложения: Асинхронные операции позволяют освободить поток исполнения для выполнения 
        других задач во время ожидания завершения операции ввода/вывода. 
        Это может значительно улучшить отзывчивость вашего приложения, о
        собенно в случае работы с файлами большого размера или на удаленных устройствах.

- Эффективное использование ресурсов: При использовании асинхронных операций ввода/вывода 
        приложение может более эффективно использовать ресурсы, так как оно 
        не блокирует поток в ожидании завершения операции. 
        Вместо этого, поток может быть использован для обработки других задач.

- Масштабируемость: Асинхронные методы особенно полезны в приложениях, 
        которые обслуживают большое количество одновременных запросов. 
        Они позволяют более эффективно масштабировать приложение, 
        обрабатывая множество запросов одновременно без блокировки.
 
 */
