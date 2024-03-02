namespace Nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string? s = null;
            s = "test";
            
            //int a = null;// ошибка

            int ? n = null;
            //n = 25;
            if(n.HasValue)
            {
                Console.WriteLine("n = " + n);
            }
            else
            {
                Console.WriteLine("В переменной нет значения");
            }

            Console.WriteLine($"n = {n ?? 1}" );//1
            Console.WriteLine($"n = {n.GetValueOrDefault()}" );//0
            Console.WriteLine($"n = {n.GetValueOrDefault(10)}" );//10

            Nullable<int> b = null;
            b = 111;

            DateTime? d = null;

            
            Console.Read();
        }
    }
}