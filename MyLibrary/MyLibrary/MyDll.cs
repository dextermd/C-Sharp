using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class MyDll
    {
        static public void ShowColorArr(int[] arr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int i in arr)
            {
                Console.Write($"({i})    ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
