
/*
 Объявить и проинициализировать jagget массив.
Записать в двоичный файл. 
Считать из файла в другой массив, вывести на экран.
 */
namespace _21_2_Запись_jagget_array_в_файл
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] array =
             {
                new int[]{2,6,-12,9,4,89,3},
                new int[]{200,6,5,9},
                new int[] {-4,-9,78,25,3,6,9,100}
            };
            foreach (int[] row in array)
            {
                foreach (int value in row)
                {
                    Console.Write($"{value,6}");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"array.Length:  {array.Length}");//3

            //string? a = null;

            string path = @"..\..\..\array.txt";

            using(FileStream fs = new FileStream(path, FileMode.Create))
            using(BufferedStream bs = new BufferedStream(fs))
            using(BinaryWriter bw = new BinaryWriter(bs))
            {
                // Запись количества строк
                bw.Write(array.Length);
                foreach (int[] row in array)
                {
                    bw.Write(row.Length);// запись количества элементов текущей строки
                    foreach (var item in row)
                    {
                        bw.Write(item);
                    }
                }
                //bw.Flush();//***
                Console.WriteLine("Массив записан в двоичный файл");
            }
            int[][]? arrayFromFile = null;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                int row = br.ReadInt32();   // читаем количество строк
                arrayFromFile = new int[row][];
                
                for (int i = 0; i < row; i++)
                {
                    int col = br.ReadInt32(); // читаем количество элементов каждой строки
                    arrayFromFile[i]=new int[col];
                    for (int j = 0; j < col; j++)
                    {
                        arrayFromFile[i][j]=br.ReadInt32();
                    }
                }
                Console.WriteLine("Массив из файла");

                foreach (int[] rows in arrayFromFile)
                {
                    foreach (int value in rows)
                    {
                        Console.Write($"{value,6}");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("---------------------------------");
            foreach (int[] rows in arrayFromFile)
            {
                foreach (int value in rows)
                {
                    Console.Write($"{value,6}");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}



/*
// Запись двоичных данных
using (FileStream fileStream = new FileStream("file.bin", FileMode.Create))
using (BufferedStream bufferedStream = new BufferedStream(fileStream))
using (BinaryWriter writer = new BinaryWriter(bufferedStream))
{
    // запись..
}

// Чтение двоичных данных
using (FileStream fileStreamRead = File.OpenRead("file.bin"))
using (BufferedStream bufferedStreamRead = new BufferedStream(fileStreamRead))
using (BinaryReader reader = new BinaryReader(bufferedStreamRead))
{
    // Чтение и вывод двоичных данных...
}
*/

/*

BufferedStream используется вместе с FileStream 
для записи и чтения файла. 

BufferedStream предоставляет буферизацию для улучшения производительности, 
кэшируя данные и выполняя операции ввода-вывода блоками, 
что может сделать операции более эффективными.

Обратите внимание, что в приведенном выше примере
StreamWriter и StreamReader используют BufferedStream 
для более эффективной работы с данными в файле.
 
 */

/*
 BufferedStream в большинстве случаев автоматически управляет 
буферизацией данных и вызовом Flush(). 
Когда вы вызываете метод записи (например, StreamWriter.Write()), 
BufferedStream может накапливать данные в буфере, 
а затем записывать их в файл, когда буфер заполняется или когда вызывается Flush().

В приведенном вами коде для StreamWriter, 
не требуется явно вызывать bufferedStream.Flush(). 

Закрытие StreamWriter (в конце блока using) автоматически вызовет Flush(), 
и любые данные, которые были буферизованы, будут записаны в файл.

Однако, если  нужно явно управлять буферизацией 
(например, в случае необходимости записи данных в файл без закрытия StreamWriter), 
вы можете вызвать Flush() метод явно.
 
 */
