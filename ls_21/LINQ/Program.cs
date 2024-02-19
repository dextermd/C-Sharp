
int[] m = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

IEnumerable<int> query = from x in m where x > 0 select x;

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

m[0] = -200;

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

// Использования метода расширения
IEnumerable<int> query2 = m.Where(x => x > 0);

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query2)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

// Использования метода класса
IEnumerable<int> query3 = Enumerable.Where(m, x => x > 0);

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query3)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

// Сформировать запрос на получение положительных значений в отсартированном виде
int[] m2 = { 25, -12, 15, -5, 12, 5, 6, -11, -7 };

var query4 = from x in m2
                 where x > 0
                 orderby x  // По умолчанию - по возрастанию
                 select x;

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query4)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

var query5 = from x in m2
             where x > 0
             orderby x descending //  по убыванию
             select x;

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query5)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

var query6 = m2
    .Where(x => x > 0)
    .OrderByDescending(x => x);

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query6)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");

var query7 = Enumerable.OrderByDescending(Enumerable.Where(m2, x => x > 0), x => x);

Console.WriteLine("Положительные значения массива: ");
// Выполнения запроса:
foreach (var item in query6)
{
    Console.Write($"{item} ");
}

Console.WriteLine("\n______________________________________________\n");
