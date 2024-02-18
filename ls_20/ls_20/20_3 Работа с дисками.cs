using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_3_Работа_с_дисками
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //using System.IO;

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

            Console.ReadLine();
        }
    }
}


/*
 Для представления диска в пространстве имен System.IO имеется класс DriveInfo.

Этот класс имеет статический метод GetDrives(), который возвращает имена всех логических дисков компьютера. 
Также он предоставляет ряд полезных свойств:

AvailableFreeSpace: указывает на объем доступного свободного места на диске в байтах

    DriveFormat: получает имя файловой системы

    DriveType: представляет тип диска

    IsReady: готов ли диск (например, DVD-диск может быть не вставлен в дисковод)

    Name: получает имя диска

    RootDirectory: возвращает корневой каталог диска

    TotalFreeSpace: получает общий объем свободного места на диске в байтах

    TotalSize: общий размер диска в байтах

    VolumeLabel: получает или устанавливает метку тома
 */
