using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            // Кортеж
            Tuple<int, int, string, double> tuple = new Tuple<int, int, string, double>(1, 1, "Hello", 25.3);
            Console.WriteLine($"{tuple.Item1} {tuple.Item2} {tuple.Item3} {tuple.Item4}");

            // Неявное определение
            var tuple2 = ("Sokolov", 100_000_000);
            tuple2.Item2 += 500;
            Console.WriteLine($"{tuple2.Item1} {tuple2.Item2}");

            var tuple3 = ("Marks", new List<int> { 10,6,9,12,12,12});
            Console.WriteLine($"{tuple3.Item1} {string.Join(" ", tuple3.Item2)}");

            // Явное определение
            (int, int) tuple4 = (15, 20);

            // Можно задавать имена поля
            var tuple5 = (name: "Skittles", salary: 100);
            Console.WriteLine($"{tuple5.name} {tuple5.salary}");

            string str1 = "C++";
            string str2 = "C#";
            Console.WriteLine($"{str1} {str2}");
            (str1, str2) = (str2, str1); // Обмен значениями
            Console.WriteLine($"{str2} {str1}");

            // Декомпозиция tuple4 на отдельные переменные
            var (a, b) = tuple4;
            Console.WriteLine($"{a}  {b}");

            // Возврат значений из метода
            // Написать метод который подсчитывает кол-во четных, нечетных, полож, отриц
            // Возвращает массива и возвращает результат из функции

            int[] m = new int[] { 12, -25,1,2,4,256,-8,0,23,44,-3};
            var counts = CountValue(m);

            Console.WriteLine($"Кол-во четных: {counts.Item1} \n" +
                              $"Кол-во не четных: {counts.Item2} \n" +
                              $"Кол-во полож: {counts.Item3} \n" +
                              $"Кол-во отриц: {counts.Item4} \n");

#endif

#if false
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
            }
#endif


            Console.WriteLine($"Текущий рабочий каталог: {Environment.CurrentDirectory}");
            //using System.IO;
            // Классы Directory  и DirectoryInfo

#if false

            //----------------------------------------------
            //Создание каталога

            // класс Directory

            //string mypath = "myFolder";
            //string mypath = "C:\\tmp\\2222";
            //string mypath = "C:/tmp/2222";
            string mypath = @"..\..\TEST";

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

            string dirName3 = "J:\\tmp";

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
             который укажет, что папку надо удалять со всем содержимым. 
            
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

            string oldPath = @"J:\tmp\ConsoleApp1";
            string newPath = @"J:\tmp\2";

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

#if false
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
            FileInfo[] files3 = directory_inf.GetFiles("my*.*");

            foreach (FileInfo file in files3)
            {
                Console.WriteLine(file.FullName);
            }

#endif




            //Классы File и FileInfo
            //using System.IO;
#if false

            //---------------------------------------------------
            //Получение информации о файле

            string path = @"J:\tmp\myfile.txt"; // для Windows
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
            string path2 = @"J:\tmp\3.txt";
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

#if false
            //---------------------------------------------------
            //Чтение и запись файлов

            Console.WriteLine();

            string mypath = "1.txt";

            string fileText = File.ReadAllText(mypath);
            Console.WriteLine(fileText);

            //File.AppendAllText(mypath, fileText);

#endif

#if false
            // Текстовые файлы

            string path = "test.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Hello!!!!!");
            sw.Close();
#endif

#if true
            string path = "test1.txt";
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path);
                sw.WriteLine("FFFFFFFF");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            } finally { 
                if (sw != null)
                {
                    Console.WriteLine("Close");
                }
                //sw.Close(); 
                sw.Dispose();
            }
#endif

            Console.Read();
        }
        public static (int, int, int, int) CountValue(int[] arr)
        {
            int even = 0, odd = 0, pos=0, neg =0;
            foreach (var item in arr)
            {
                if (item % 2 == 0) even++;
                else odd++;
                if (item >= 0) pos++;
                else neg++;
            }
            return (even, odd, pos, neg);
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