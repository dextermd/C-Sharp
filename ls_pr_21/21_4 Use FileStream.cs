/*
 FileStream представляет доступ к файлам на уровне байтов, 
 поэтому, например, если надо считать или записать одну или несколько строк в текстовый файл, 
 то массив байтов надо преобразовать в строки, 
 используя специальные методы. 
 Поэтому для работы с текстовыми файлами применяются другие классы.

 В то же время при работе с различными бинарными файлами, 
 имеющими определенную структуру, 
 FileStream может быть очень даже полезен 
 для извлечения определенных порций информации и ее обработки.
 */

using System.Text;

namespace _21_2_Use_FileStream
{
    internal class Program
    {
        static async Task Main(string[] args)  
        //static void Main(string[] args)
        {

#if false
            // using System.Text;
            // -----------------Запись и чтение, текстовый файл---------------------------
            string textFilePath = "example.txt";

            // Запись в текстовый файл
            using (FileStream fsTxt = new FileStream(textFilePath, FileMode.Create, FileAccess.Write))
            {
                // Преобразуем строку в байты и записываем их в файл
                string textToWrite = "Hello, World!";
                byte[] masBytes = Encoding.UTF8.GetBytes(textToWrite);
                fsTxt.Write(masBytes, 0, masBytes.Length);

                // !!! для записи различных типов данных в файл надо использовать другие 
                // инструменты StreamWriter и StreamReader

                //fsTxt.WriteByte(24);// в файле это будет не читабельно и при считывании тоже
            }

            // Чтение из текстового файла
            using (FileStream fsTxt = new FileStream(textFilePath, FileMode.Open, FileAccess.Read))
            {
                // Читаем байты из файла и преобразуем их в строку
                byte[] readBytes = new byte[fsTxt.Length];
                fsTxt.Read(readBytes, 0, readBytes.Length);
                string fromFile = Encoding.UTF8.GetString(readBytes);
                Console.WriteLine("Содержимое текстового файла: " + fromFile);

                //// Читаем побайтово:
                //Console.WriteLine("Содержимое текстового файла(побайтовое чтение): ");
                //int i;
                //do
                //{
                //    i = fsTxt.ReadByte();
                //    if (i != -1) Console.Write((char)i);
                //} while (i != -1);
            }
#endif

#if false

            // -----------------Запись и чтение, бинарный файл---------------------------
            // Путь к двоичному файлу
            string binaryFilePath = "example.bin";

            // Запись в двоичный файл
            using (FileStream fileStreamBin = new FileStream(binaryFilePath, FileMode.Create, FileAccess.Write))
            {
                // Пример данных для записи в двоичный файл (в данном случае - массив чисел)
                int[] numbersToWrite = { 1, 2, 3, 4, 5 };

                // Преобразуем каждое число в байты и записываем их в файл
                foreach (int number in numbersToWrite)
                {
                    byte[] numberBytes = BitConverter.GetBytes(number);
                    fileStreamBin.Write(numberBytes, 0, numberBytes.Length);
                }
            }

            // Чтение из двоичного файла
            using (FileStream fileStreamBin = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            {
                // Определяем размер данных в файле
                int fileSize = (int)fileStreamBin.Length;

                // Создаем массив байтов для хранения данных
                byte[] readBytes = new byte[fileSize];

                // Читаем данные из файла
                fileStreamBin.Read(readBytes, 0, fileSize);

                // Преобразуем байты в массив чисел (в данном случае - int)
                int[] numbersRead = new int[fileSize / sizeof(int)];
                Buffer.BlockCopy(readBytes, 0, numbersRead, 0, fileSize);

                Console.WriteLine("Содержимое двоичного файла: " + string.Join(", ", numbersRead));
            }

#endif
#if false

            //--------------------Произвольный доступ к файлам------------------
            // Чтение из текстового файла
            string textFilePath = "example.txt";

            using (FileStream fs = new FileStream(textFilePath, FileMode.Open, FileAccess.Read))
            {
                // перемещаем указатель в конец файла, до конца файла- пять байт
                fs.Seek(-6, SeekOrigin.End); // минус 6 символов с конца потока

                // считываем четыре символов с текущей позиции
                byte[] readBytes = new byte[6];
                //await fs.ReadAsync(readBytes, 0, readBytes.Length);
                fs.Read(readBytes, 0, readBytes.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.UTF8.GetString(readBytes);

                Console.WriteLine("Содержимое текстового файла(-6 байт с конца): " + textFromFile);
            }

#endif

#if true
            //--------------------Произвольный доступ к файлам------------------
            string textFilePath = "example.txt";

            using (FileStream fstream = new FileStream(textFilePath, FileMode.OpenOrCreate))
            {
                // заменим в файле слово world на слово МИР!!!
                string replaceText = "МИР!!!";
                fstream.Seek(-6, SeekOrigin.End); // минус 6 символов с конца потока
                byte[] input = Encoding.UTF8.GetBytes(replaceText);
                await fstream.WriteAsync(input, 0, input.Length);

                // считываем весь файл
                // возвращаем указатель в начало файла
                fstream.Seek(0, SeekOrigin.Begin);
                byte[] output = new byte[fstream.Length];
                await fstream.ReadAsync(output, 0, output.Length);

                // декодируем байты в строку
                string textFromFile = Encoding.UTF8.GetString(output);
                Console.WriteLine($"Текст из файла: {textFromFile}"); // hello МИР!!!
            }
#endif

            Console.Read();
        }
    }
}


//----------------------------------------------------------
/*
 Класс FileStream представляет возможности по считыванию из файла и записи в файл. 
Он позволяет работать как с текстовыми файлами, так и с бинарными.
 
Для создания объекта FileStream можно использовать как конструкторы этого класса, 
так и статические методы класса File. 

1 Способ -   Конструктор класса:
    Конструктор FileStream имеет множество перегруженных версий, 
    из которых рассмотрим самую простую и используемую:

    FileStream(string filename, FileMode mode)

2 Способ - статические методы класса File:
    
    FileStream File.Open(string file, FileMode mode);
    FileStream File.OpenRead(string file);
    FileStream File.OpenWrite(string file);


Для корректного закрытия можно вызвать метод Close(), который вызывает метод Dispose.
 
 */
//----------------------------------------------------------
/*
 FileStream представляет доступ к файлам на уровне байтов, 
 поэтому, например, если надо считать или записать одну или несколько строк в текстовый файл, 
 то массив байтов надо преобразовать в строки, 
 используя специальные методы. 
 Поэтому для работы с текстовыми файлами применяются другие классы.

 В то же время при работе с различными бинарными файлами, 
 имеющими определенную структуру, 
 FileStream может быть очень даже полезен для извлечения определенных порций информации и ее обработки.
 */

//----------------------------------------------------------
/*
 --------Перечисление FileMode -  режим доступа к файлу, значения:

Append:     если файл существует, то текст добавляется в конец файл. Если файла нет, то он создается.
            Файл открывается только для записи.

Create:     создается новый файл. Если такой файл уже существует, то он перезаписывается

CreateNew:  создается новый файл. Если такой файл уже существует, то приложение выбрасывает ошибку

Open:       открывает файл. Если файл не существует, выбрасывается исключение

OpenOrCreate: если файл существует, он открывается, если нет - создается новый

Truncate:   если файл существует, то он перезаписывается. Файл открывается только для записи.
 
 */

/*
 ----------- Свойства и методы FileStream
 ----------- Наиболее важные свойства класса FileStream:

Свойство Length: возвращает длину потока в байтах

Свойство Position: возвращает текущую позицию в потоке

Свойство Name: возвращает абсолютный путь к файлу, открытому в FileStream

 ----------- Для чтения/записи файлов можно применять следующие методы класса FileStream:

void CopyTo(Stream destination): копирует данные из текущего потока в поток destination

Task CopyToAsync(Stream destination): асинхронная версия метода CopyTo

void Flush(): сбрасывает содержимое буфера в файл

Task FlushAsync(): асинхронная версия метода Flush

int Read(byte[] array, int offset, int count): считывает данные из файла в массив байтов 
                        и возвращает количество успешно считанных байтов. 
                        Принимает три параметра:

        array - массив байтов, куда будут помещены считываемые из файла данные

        offset представляет смещение в байтах в массиве array, в который считанные байты будут помещены

        count - максимальное число байтов, предназначенных для чтения. Если в файле находится меньшее количество байтов, то все они будут считаны.

Task<int> ReadAsync(byte[] array, int offset, int count): асинхронная версия метода Read

long Seek(long offset, SeekOrigin origin): устанавливает позицию в потоке со смещением на количество байт, указанных в параметре offset.

void Write(byte[] array, int offset, int count): записывает в файл данные из массива байтов. Принимает три параметра:

        array - массив байтов, откуда данные будут записываться в файл

        offset - смещение в байтах в массиве array, откуда начинается запись байтов в поток

        count - максимальное число байтов, предназначенных для записи

Task WriteAsync(byte[] array, int offset, int count): асинхронная версия метода Write
 */

/*
 ----------- Произвольный доступ к файлам
 ----------- Нередко бинарные файлы представляют определенную структуру. 
 И, зная эту структуру, мы можем взять из файла нужную порцию информации 
 или наоброт записать в определенном месте файла определенный набор байтов. 
 
 Например, в wav-файлах непосредственно звуковые данные начинаются с 44 байта, 
 а до 44 байта идут различные метаданные - количество каналов аудио, частота дискретизации и т.д.

 ----------- С помощью метода Seek() можно управлять положением курсора потока, 
  начиная с которого производится считывание или запись в файл. 

 Этот метод принимает два параметра: offset (смещение) и позиция в файле. 

Позиция в файле описывается тремя значениями:

SeekOrigin.Begin: начало файла

SeekOrigin.End: конец файла

SeekOrigin.Current: текущая позиция в файле

Курсор потока, с которого начинается чтение или запись, 
смещается вперед на значение offset относительно позиции, 
указанной в качестве второго параметра. 

Смещение может быть отрицательным, тогда курсор сдвигается назад, 
если положительное - то вперед.
 */