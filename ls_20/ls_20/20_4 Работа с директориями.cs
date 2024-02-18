using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_4_Работа_с_директориями
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Текущий рабочий каталог: {Environment.CurrentDirectory}");


            //using System.IO;

            // Классы Directory  и DirectoryInfo

#if false

            //----------------------------------------------
            //Создание каталога

            // класс Directory

            //string mypath = "myFolder";
            //string mypath = "J:\\tmp\\222222";
            //string mypath = "J:/tmp/123456";
            string mypath = @"..\..\tEST";
            string s = "..\\..\tEST";

            if (!Directory.Exists(mypath))
            {
                Directory.CreateDirectory(mypath);
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

            // Создание подкаталога по пути
            string subpath = @"my_program\C#";
            Directory.CreateDirectory($"{mypath}/{subpath}");



            // Создание каталога
            // класс DirectoryInfo
            DirectoryInfo dirInfo = new DirectoryInfo(@"J:\tmp3");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

#endif

#if false

            //----------------------------------------------
            //Получение информации о каталоге

            string dirName3 = "J:\\ФОТО";

            DirectoryInfo dirInfo3 = new DirectoryInfo(dirName3);

            Console.WriteLine($"Название каталога: {dirInfo3.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo3.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo3.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo3.Root}");

#endif

#if false

            //----------------------------------------------
            //Удаление каталога

            /*
             Если папка не пуста и применить метод Delete, то приложение нам выбросит ошибку. 
             
             Поэтому надо передать в метод Delete дополнительный параметр булевого типа, 
             который укажет, что папку надо удалять со всем содержимым(true). 
            
             Кроме того, перед удалением следует проверить наличие удаляемой папки, 
             иначе приложение выбросит исключение:
             */

            string dirName5 = @"J:\tmp\test";


            DirectoryInfo dirInfo5 = new DirectoryInfo(dirName5);
            //dirInfo5.Delete(true);//System.IO.DirectoryNotFoundException: 

            if (dirInfo5.Exists)
            {
                //dirInfo5.Delete(false); //System.IO.IOException: 'Папка не пуста.
                dirInfo5.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            else
            {
                Console.WriteLine("Каталог не существует");
            }

#endif
            //----------------------------------------------
            //Перемещение каталога

            /*
             При перемещении надо учитывать, что новый каталог, в который мы хотим перемесить все содержимое 
             старого каталога, НЕ должен существовать.

             *** Перемещение каталога в рамках одной папки (как в примере ниже) 
             фактически аналогично переименованию папки
             */
#if false

            string oldPath = @"J:\tmp\bin";
            string newPath = @"J:\tmp\bin2";

            //string newPath = @"J:\tmp";

            DirectoryInfo dirInfo6 = new DirectoryInfo(oldPath);
            if (dirInfo6.Exists && !Directory.Exists(newPath))
            {
                dirInfo6.MoveTo(newPath);
                // или так
                // Directory.Move(oldPath, newPath);
            }
            else
            {
                Console.WriteLine("Каталог не существует");
            }

#endif

#if false


            //Получение списка файлов и подкаталогов
            //1 - Класс Directory

            string path = "J:\\";
            // или
            //string path = @"C:\";

            // если папка существует
            if (Directory.Exists(path))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(path);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }

            Console.WriteLine(new string('-', 20));

            //2 - Класс DirectoryInfo
            //Для создания объекта класса DirectoryInfo применяется конструктор,
            //который в качестве параметра принимает путь к каталогу:

            //string dirName = "J:\\";
            // или
            string dirName = @"J:\";

            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);

            if (directoryInfo.Exists)
            {
                Console.WriteLine("Подкаталоги:");
                DirectoryInfo[] dirs = directoryInfo.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine(dir.FullName);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.FullName);
                }
            }

#endif


#if true
            //-------------------------------------------------
            /*
             Методы получения папок и файлов позволяют выполнять фильтрацию. 
            
            В качестве фильтра в эти методы передается шаблон, 
            который может содержать два плейсхолдера: 
            * или символ-звездочка (соответствует любому количеству символов) 
            ? или вопросительный знак (соответствует одному символу)
             */
            Console.WriteLine("\n-----------------Фильтация файлов и папок-------------");
            //Фильтрация папок и файлов
            string dirName2 = @"J:\tmp\";

            // класс Directory
            string[] files2 = Directory.GetFiles(dirName2, "*.txt");
            foreach (string file in files2)
            {
                // if (File.Exists(file))// можно пропустить
                // {
                Console.WriteLine(file);
                // }
            }
            Console.WriteLine();

            // класс DirectoryInfo
            DirectoryInfo directory_inf = new DirectoryInfo(dirName2);
            FileInfo[] files3 = directory_inf.GetFiles("*.*");

            foreach (FileInfo file in files3)
            {
                Console.WriteLine(file.FullName);
            }

#endif

            Console.ReadLine();
        }
    }
}


/*
 Для работы с каталогами в пространстве имен System.IO предназначены сразу два класса: 
    Directory и DirectoryInfo.

----Класс Directory
    Статический класс Directory предоставляет ряд методов для управления каталогами. Некоторые из этих методов:

        CreateDirectory(path): создает каталог по указанному пути path

        Delete(path): удаляет каталог по указанному пути path

        Exists(path): определяет, существует ли каталог по указанному пути path. Если существует, возвращается true, если не существует, то false

        GetCurrentDirectory(): получает путь к текущей папке

        GetDirectories(path): получает список подкаталогов в каталоге path

        GetFiles(path): получает список файлов в каталоге path

        GetFileSystemEntries(path): получает список подкаталогов и файлов в каталоге path

        Move(sourceDirName, destDirName): перемещает каталог

        GetParent(path): получение родительского каталога

        GetLastWriteTime(path): возвращает время последнего изменения каталога

        GetLastAccessTime(path): возвращает время последнего обращения к каталогу

        GetCreationTime(path): возвращает время создания каталога

----Класс DirectoryInfo
    Данный класс предоставляет функциональность для создания, удаления, перемещения и других операций с каталогами.
    Во многом он похож на Directory, но не является статическим.

    Основные методы класса DirectoryInfo:

        Create(): создает каталог

        CreateSubdirectory(path): создает подкаталог по указанному пути path

        Delete(): удаляет каталог

        GetDirectories(): получает список подкаталогов папки в виде массива DirectoryInfo

        GetFiles(): получает список файлов в папке в виде массива FileInfo

        MoveTo(destDirName): перемещает каталог

    Основные свойства класса DirectoryInfo:

        CreationTime: представляет время создания каталога

        LastAccessTime: представляет время последнего доступа к каталогу

        LastWriteTime: представляет время последнего изменения каталога

        Exists: определяет, существует ли каталог

        Parent: получение родительского каталога

        Root: получение корневого каталога

        Name: имя каталога

        FullName: полный путь к каталогу
 

//-----------------------------

 Оба класса предоставляют похожие возможности. Когда же и что использовать? 

 Если надо совершить одну-две операции с одним каталогом, то проще использовать класс Directory. 

 Если необходимо выполнить последовательность операций с одним и тем же каталогом, 
 то лучше воспользоваться классом DirectoryInfo. 

 Почему? Дело в том, что методы класса Directory выполняют дополнительные проверки безопасности. 
 А для класса DirectoryInfo такие проверки не всегда обязательны.
 */