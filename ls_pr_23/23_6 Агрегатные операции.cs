namespace _23_6_Агрегатные_операции
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             К агрегатным операциям относят различные операции над выборкой, 
             например, получение числа элементов, получение минимального, 
             максимального и среднего значения в выборке, а также суммирование значений.
             */

            //------------------------------------------------------------------
            //-------------------Метод Aggregate--------------------------------
            //Метод Aggregate выполняет общую агрегацию элементов коллекции
            //в зависимости от указанного выражения. 

            int[] numbers = { 1, 2, 3, 4, 5 };

            int query = numbers.Aggregate((x, y) => x - y);// int query = 1 - 2 - 3 - 4 - 5
            Console.WriteLine(query);   // -13

            query = numbers.Aggregate((x, y) => x + y);
            Console.WriteLine(query);  //15

            query = numbers.Aggregate((x, y) => x * y);
            Console.WriteLine(query);  //120

            //Одна версия метода позволяет задать начальное значение,
            //с которого начинается цепь агрегатных операций:

            string[] subjects = { "C#", "JavaScript", "DataBase", "C++", "Python" };
            var sentence = subjects.Aggregate("Предметы:", (first, next) => $"{first} {next}");

            Console.WriteLine(sentence);  // Text: Gaudeamus igitur Juvenes dum sumus

            //В данном случае объединяются все элементы массива words,
            //но первым элемент агрегатной операции будет строка "Предметы:".

            Console.WriteLine("------------------------------------------------");
            //------------------------------------------------------------------


            //------------------- Получение размера выборки. Метод Count
            int[] mas = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            int size = mas.Count();  // 10
            Console.WriteLine(size);

            //  количество четных чисел, которые больше 10
            int result = mas.Count(i => i % 2 == 0 && i > 10);
            Console.WriteLine(result);    // 3

            Console.WriteLine("------------------------------------------------");

            //------------------------------------------------------------------
            //------------------- Получение суммы. Метод Sum
            int sum = mas.Sum();
            Console.WriteLine(sum);//

            Purchase[] purchase = { new Purchase("Хлеб", 15), new Purchase("Сметана", 23),
                new Purchase("Конфеты", 50.45) };

            double purchaseSum = purchase.Sum(p => p.Price);
            Console.WriteLine($"Стоимость покупки: {purchaseSum:F2}");     // 
            Console.WriteLine("------------------------------------------------");


            //------------------------------------------------------------------
            //------------------- Максимальное, минимальное и среднее значения
            int min = mas.Min();
            int max = mas.Max();
            double average = mas.Average();

            Console.WriteLine($"Min: {min}");           // Min: 1
            Console.WriteLine($"Max: {max}");           // Max: 88
            Console.WriteLine($"Average: {average}");   // Average: 34


            //-------------------Объекты пользовательсеого класса
            //в методы передается делегат, который принимает свойство, применяемое в вычислениях

            double minPrice = purchase.Min(p => p.Price);
            double maxPrice = purchase.Max(p => p.Price);
            double averagePrice = purchase.Average(p => p.Price);

            Console.WriteLine($"\nMin price: {minPrice}");
            Console.WriteLine($"Max price: {maxPrice}");
            Console.WriteLine($"Average price: {averagePrice:F2}");
            Console.Read();
        }
    }
    record Purchase(string Name, double Price);
}