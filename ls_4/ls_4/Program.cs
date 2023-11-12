using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if false
            string a = null;
            string b = "";
            string c = string.Empty;
 
            Console.WriteLine(b.Length);
            Console.WriteLine(c.Length);

            Console.WriteLine(string.IsNullOrEmpty(a));
            Console.WriteLine(string.IsNullOrEmpty(b));
            Console.WriteLine(string.IsNullOrEmpty(c));
            Console.WriteLine(string.IsNullOrEmpty(""));

            if (a != null)
            {
                Console.WriteLine(a + " " + a.Length);
            }
            else
            {
                Console.WriteLine("Нет данных!");
            }

            // ?? - оператор обьядинения с null (если у нас  какойто обьект ссылается на null  мы его можем обьеденить с каким то текстом )
            string res = a ?? "Нет данных!";
            Console.WriteLine(res);

            string a2 = "Test";
            res = a2 ?? "Нет данных!";
            Console.WriteLine(res);

#endif

#if false
            // Обьявление и инициализация, конструкторы, перебор  символов
            string message = "Всем доброе утро!";
            Console.WriteLine(message);

            //for
            //foreach

            //Обьединение строк: метод Concat или операторы + , +=
            message += "!!!!";
            Console.WriteLine(message);
            message = string.Concat(message," Черная пятница!");
            Console.WriteLine(message);
            Console.WriteLine(string.Concat(message, " Черная пятница!"));

            // Для обьединения последовательности(массива, коллекции) с разделением

            var result = string.Join(", ", "зима", "весна", "лето", "осень");
            Console.WriteLine(result);

            string[] arr = new string[] { "Маркс", "Рыжик", "Скителс", "Пират" };
            result = string.Join("; ", arr);
            Console.WriteLine(result);

            int[] maxInt = new int[] { 1, 2, 3, 4, 5, };
            result = string.Join("  ", maxInt);
            Console.WriteLine(result);

            // Смена регистра ToLower ToUpper
            Console.WriteLine(message.ToUpper());
            Console.WriteLine(message.ToLower());

            message = message.ToLower();
            message = char.ToUpper(message[0]) + message.Substring(1);
            Console.WriteLine(message);


            // ToCharArray() - получаем из строки массив символов
            char[] arr_char = message.ToCharArray();
            Console.WriteLine("Массив символов: ", arr_char);
            Console.WriteLine(string.Join(", ", arr_char));

            // Задача осуществить реверс строки
            string test = "Скоро Новый Год!";
            Console.WriteLine(test);

            char[] arr_char2 = test.ToCharArray();
            Array.Reverse(arr_char2);
            Console.WriteLine(arr_char2);
            string res1 = new string(arr_char2);
            Console.WriteLine("Строка: {0}", res1);

            //Console.WriteLine(test);
            //test.Reverse();
            //Console.WriteLine(test);

            // Метод CopyTo - копируем заданное кол-во символов в массив типа char
            char[] arr_char3 = new char[20];
            test = "Скоро Новый Год!";
            // с 6-го индекса строки скопировали 5 символов в массив символов с индекса 0
            test.CopyTo(6, arr_char3, 0, 5);
            Console.WriteLine(arr_char3);

#endif

#if false

            // Сравнение строк
            // В классе String перезагружаются два оператора: == и !=.
            // Для того чтобы сравнить  является ли строка больше другой  следует вызвать метод Compare()

            // Сравнение строк
            // 1. операторы  == и !=

            string a = "apple";
            string b = "apple";

            Console.WriteLine(a == b); //True
            Console.WriteLine(a == "APPLE"); // False

            // 2. Equals - сравнение на идентичность две строки  аналог ==
            // Может принимать дополнительный параметр StringComparison

            Console.WriteLine(a.Equals("APPLE")); // False по умолчанию работает с учетом регистра
            Console.WriteLine(a.Equals("APPLE", StringComparison.OrdinalIgnoreCase));  // True  StringComparison.OrdinalIgnoreCase -  без учета регистра

            // 3. Compare - может принимать дополнительный параметр StringComparison

            Console.WriteLine(string.Compare("apple", "d banana")); // <  -1
            Console.WriteLine(string.Compare("apple", "apple")); // =  0
            Console.WriteLine(string.Compare("banana", "apple")); // >  1
            Console.WriteLine(string.Compare("apple", "Apple", StringComparison.OrdinalIgnoreCase)); // =  0

            // 4. CompareOrdinal - делает то же, что и метод Compare(),
            // но без учета локальных кстановок

            Console.WriteLine(string.CompareOrdinal("apple", "Apple"));

            // 5. CompareTo() выполняет сравнение строк только с учетом культурной среды
            a = "apple";
            Console.WriteLine(a.CompareTo("orange")); // -1


            // Задача: отсортировать массив строк
            string[] arr = new string[] { "Маркс", "рыжик", "Скителс", "Пират", "атлант" };

            // Array.Sort(arr); // В алфавитном порядке без учета регистра
            // Array.Sort(arr, (x,y) => y.CompareTo(x)); // В обратном порядке без учета регистра
            Array.Sort(arr, StringComparer.Ordinal); // В алфавитном порядке c учетом регистра

            foreach (string s in arr) 
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // Основные методы строк
            // Split - разделяет одну строку на массив строк (Си - лексемы)
            string cat = "          Все с уважением          относятся к        коту, за то, что кот любит чистоту.         \nМаяковский.";
            string[] arrStr = cat.Split(" !,?;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in arrStr)
            {
                Console.WriteLine(item);
            }

            // StartsWith и EndsWith
            // Задача: В массиве строк хранятся имена файлов, вывести все с расширением .exe
            string t = "dectionary.txt";
            Console.WriteLine(t.EndsWith("txt")); // True

            // IndexOf - поиск индекса в строке
            Console.WriteLine(t.IndexOf(".txt"));

            // Обрезка строки:
            // 1. Пробелы: Trim TrimStart TrimEnd
            // 2. Substring
            t = "                dectionary.txt       test.bin                      ";
            Console.WriteLine(t.Trim());

            t = t.Trim();
  
            Console.WriteLine(t);
            t = t.Substring(10, 4);
            Console.WriteLine(t);

            // Insert - вставка строки
            string d = "день";
            d = d.Insert(0, "Очень хороший ");
            Console.WriteLine(d);

            // Remove - удаление части строки
            //Console.WriteLine(d.Remove(0, 5)); // c 0 по 5 удаление
            Console.WriteLine(d.Remove(5)); // удаление части строки с 5 до конца

            // Replace  - замена
            string text = "Человек сказал - Человек сделал! ";
            text = text.Replace("Человек", "Кот");
            Console.WriteLine(text);

            // Дополнение строк:
            // PadLeft
            // PadRight

            string num = "123";
            Console.WriteLine(num.PadLeft(10)); // пробел - по yмолчанию 
            Console.WriteLine(num.PadLeft(10, '0')); // пробел - по yмолчанию 
            Console.WriteLine(num.PadRight(10, '*')); // пробел - по yмолчанию 

#endif

#if true
            // string to int array
            string numbers = "12 89 -256 9854 23 98 -14";
            string[] arr = numbers.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Размер массива: {0}", arr.Length);

            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = int.Parse(arr[i]); 
            }

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

            //Array.Sort(result, (x, y) => y - x);
            Array.Sort(result, (x, y) => y.CompareTo(x));

            Console.WriteLine();

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }


            StringBuilder sb = new StringBuilder("Hello");
            Console.WriteLine("\n" + sb);

            // AppendFormat
            StringBuilder sb4 = new StringBuilder();
            string name = "Александр";
            int age = 30;

            sb4.AppendFormat("Имя: {0}, Возраст: {1}", name, age);
            Console.WriteLine(sb4.ToString());

#endif
            Console.ReadLine();
        }
    }
}
