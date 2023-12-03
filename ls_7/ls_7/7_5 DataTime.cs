using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_5_DataTime
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //-------------------------------------------------------
            // Тип DateTime
#if true

            Console.WriteLine("Текущая дата: " + DateTime.Now);
            Console.WriteLine("Текущая дата: " + DateTime.UtcNow);
            Console.WriteLine("Текущая дата: " + DateTime.Today);

            DateTime myDate = new DateTime(2023, 10, 25);
            Console.WriteLine("Тип данных: " + myDate.GetType());
            Console.WriteLine("-> The day of: {0} is {1}", myDate.Date, myDate.DayOfWeek);

            // Добавление  времени
            DateTime t = DateTime.Now;
            DateTime t2 = t.AddDays(2).AddHours(2).AddMinutes(30).AddSeconds(12);
            Console.WriteLine("Текущая дата и время: {0}", t);
            Console.WriteLine("К текущему времени добавлено: 2 дня, 2:30:12 -> {0}", t2);

            //Вычитание времени - возвращается тип TimeSpan
            DateTime dateTime = new DateTime(2023, 5, 15, 2, 17, 20);
            Console.WriteLine("\n dateTime: {0}", dateTime.ToString());

            TimeSpan dateTime2 = DateTime.Now - dateTime;
            Console.WriteLine("Вычитание времени: {0}", dateTime2);
            Console.WriteLine("Результат в днях: {0}", dateTime2.Days);

            // Добавление  времени оператор +
            Console.WriteLine("\n dateTime: {0}", dateTime.ToString());
            DateTime test = dateTime + new TimeSpan(12, 10, 15, 0);
            Console.WriteLine("К dateTime добавлено 12 дней 10:15:00 -> {0}", test.ToString());


#endif

#if true
            //-------------------------------------------------------
            /*
             Тип TimeSpan в C# представляет собой структуру данных, 
            которая используется для представления интервалов времени, 
            длительности или временных разниц между двумя датами или моментами времени. 
            
            Он предоставляет удобное и гибкое средство для работы с временными интервалами и 
            может быть использован в различных сценариях программирования, 
            таких как работа с датами и временем, измерение времени выполнения операций и т. д.
             */

            // Создание TimeSpan, представляющего 3 дня
            TimeSpan ts1 = new TimeSpan(3, 0, 0, 0);
            Console.WriteLine(ts1);

            // Создание TimeSpan, представляющего 2 часа и 30 минут
            TimeSpan ts2 = new TimeSpan(2, 30, 0);
            Console.WriteLine(ts2);

            // Создание TimeSpan, представляющего 30 минут
            TimeSpan ts3 = TimeSpan.FromMinutes(30);
            Console.WriteLine(ts3);

            // Вычисление разницы между двумя моментами времени
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddHours(2).AddMinutes(30).AddSeconds(12);

            TimeSpan diff = endTime - startTime;
            Console.WriteLine(diff);

            // Вычисление разницы между двумя датами
            DateTime data = new DateTime(1972, 10, 4);
            DateTime data2 = DateTime.Now;

            TimeSpan ts = data2 - data;// Разница в днях

            Console.WriteLine("-> TimeSpan: {0} ", ts);
            Console.WriteLine("-> Дней: {0} ", ts.Days);
            Console.WriteLine("-> Часов: {0} ", ts.Hours);
            Console.WriteLine("-> Минут: {0} ", ts.Minutes);
            Console.WriteLine("-> Минут: {0} ", ts.Seconds);
            Console.WriteLine("-> Миллисекунд: {0} ", ts.Milliseconds);

            //Тики - это единицы измерения времени, а в C# они эквивалентны 100 наносекундам. 
            Console.WriteLine("\n-> Ticks: {0} ", ts.Ticks);


#endif

#if false


            String d;
            Console.WriteLine("Введите дату dd.MM.yyyy");

            d = Console.ReadLine();

            try
            {
                DateTime dt = DateTime.Parse(d);
                //или
                //DateTime dt = Convert.ToDateTime(d);
                Console.WriteLine(dt.ToLongDateString());

                Console.WriteLine("День недели: " + dt.DayOfWeek + "\nДень в году: " + dt.DayOfYear);
            }
            catch (FormatException)
            {

                Console.WriteLine("Неверный формат даты.");
            }

#endif

#if false
            // Привер ввода даты и выбора формата для ввода:
            //using System.Globalization;
            //TryParseExact

            Console.WriteLine("Выберите формат даты (1 - ММ/дд/гггг, 2 - дд/ММ/гггг, 3 - ММ.dd.гггг, 4 - дд.ММ.гггг, 5 - гггг.ММ.дд): ");
            string formatChoice = Console.ReadLine();

            string dateFormat;
            CultureInfo cultureInfo;

            if (formatChoice == "1")
            {
                dateFormat = "MM/dd/yyyy";
                cultureInfo = CultureInfo.InvariantCulture;
            }
            else if (formatChoice == "2")
            {
                dateFormat = "dd/MM/yyyy";
                cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            }
            else if (formatChoice == "3")
            {
                dateFormat = "MM.dd.yyyy";
                cultureInfo = CultureInfo.InvariantCulture;
            }
            else if (formatChoice == "4")
            {
                dateFormat = "dd.MM.yyyy";
                cultureInfo = CultureInfo.GetCultureInfo("ru-RU");
            }
            else if (formatChoice == "5")
            {
                dateFormat = "yyyy.mm.dd";
                cultureInfo = CultureInfo.InvariantCulture;
            }
            else
            {
                Console.WriteLine("Неверный выбор формата.");
                return;
            }

            Console.WriteLine("Введите дату в выбранном формате: ");
            string userInput = Console.ReadLine();

            if (DateTime.TryParseExact(userInput, dateFormat, cultureInfo, DateTimeStyles.None, out DateTime dateInput))
            {
                Console.WriteLine("Вы ввели дату: " + dateInput);
            }
            else
            {
                Console.WriteLine("Некорректный ввод даты.");
            }

            /*
             CultureInfo.InvariantCulture
             Получает объект System.Globalization.CultureInfo, не зависящий от языка и региональных параметров.
             */
#endif


#if false

            //--------------------------------------------------------
            // Вывод даты в разных форматах:
            DateTime dt = DateTime.Now;
            Console.WriteLine("\n\nДата в формате d: {0:d}\nВ формате D: {0:D}", dt);
            Console.WriteLine("\nДата в формате f: {0:f}\nВ формате F: {0:F}", dt);
            Console.WriteLine("\nДата в формате g: {0:g}\nВ формате G: {0:G}", dt);
            Console.WriteLine("\nДата в формате m: {0:m}\nВ формате M: {0:M}", dt);
            Console.WriteLine("\nДата в формате r: {0:r}\nВ формате R: {0:R}", dt);
            Console.WriteLine("\nДата в формате o: {0:o}\nВ формате O: {0:O}", dt);
            Console.WriteLine("\nДата в формате s: {0:s}", dt);           
            Console.WriteLine("\nДата в формате t: {0:t}\nВ формате T: {0:T}", dt);
            Console.WriteLine("\nДата в формате u: {0:u}\nВ формате U: {0:U}", dt);
            Console.WriteLine("\nДата в формате y: {0:y}\nВ формате Y: {0:Y}", dt);


            // Вывод даты в настраиваемых форматах:
            Console.WriteLine("---------------------------");
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("hh:mm:ss"));
            Console.WriteLine(now.ToString("dd.MMMM.yyyy"));

            
#endif
            Console.ReadLine();
        }
    }
}



/*
 Спецификаторы формата для дат:

Спецификатор	Формат
D	        Дата в длинной форме
d	        Дата в краткой форме
F	        Дата и время в длинной форме
f	        Дата и время в краткой форме
G	        Дата — в краткой форме, время — в длинной
g	        Дата и время — в краткой форме
М	        Месяц и день
m	        То же, что и М
O	        Формат даты и времени, включая часовой пояс. Строка, составленная в формате О, может быть преобразована обратно в эквивалентную форму вывода даты и времени. Это так называемый "круговой" формат
R	        Дата и время в стандартной форме по Гринвичу
s	        Сортируемый формат представления даты и времени
T	        Время в длинной форме
t	        Время в краткой форме
U	        Длинная форма универсального представления даты и времени; время отображается как универсальное синхронизированное время (UTC)
u	        Краткая форма универсального представления даты и времени
Y	        Месяц и год
 
 */
//-------------------------------------------------------------------------
/*
 Настройка формата времени и даты
Не всегда удобно использование встроенных форматов даты и времени. 
Иногда бывает необходимо задать сообственную форму отображения объекта DateTime. 
В этом случае мы можем составить свой формат из описателей:

Описатель	Описание
d	        Представляет день месяца от 1 до 31. Одноразрядные числа используются без нуля в начале
dd	        Представляет день месяца от 1 до 31. К одноразрядным числам в начале добавляется ноль
ddd	        Сокращенное название дня недели
dddd	    Полное название дня недели
f / fffffff	Представляет миллисекунды. Количество символов f указывает на число разрядов в миллисекундах
g	        Представляет период или эру (например, "н. э.")
h	        Часы в виде от 1 до 12. Часы с одной цифрой не дополняются нулем
hh	        Часы в виде от 01 до 12. Часы с одной цифрой дополняются нулем
H	        Часы в виде от 0 до 23. Часы с одной цифрой не дополняются нулем
HH	        Часы в виде от 0 до 23. Часы с одной цифрой дополняются нулем
K	        Часовой пояс
m	        Минуты от 0 до 59. Минуты с одной цифрой не дополняются начальным нулем
mm	        Минуты от 0 до 59. Минуты с одной цифрой дополняются начальным нулем
M	        Месяц в виде от 1 до 12
MM	        Месяц в виде от 1 до 12. Месяц с одной цифрой дополняется начальным нулем
MMM	        Сокращенное название месяца
MMMM	    Полное название месяца
s	        Секунды в виде числа от 0 до 59. Секунды с одной цифрой не дополняются начальным нулем
ss	        Секунды в виде числа от 0 до 59. Секунды с одной цифрой дополняются начальным нулем
t	        Первые символы в обозначениях AM и PM
tt	        AM или PM
y	        Представляет год как число из одной или двух цифр. Если год имеет более двух цифр, то в результате отображаются только две младшие цифры
yy	        Представляет год как число из одной или двух цифр. Если год имеет более двух цифр, то в результате отображаются только две младшие цифры. Если год имеет одну цифру, то он дополняется начальным нулем
yyy	        Год из трех цифр
yyyy	    Год из четырех цифр
yyyyy	    Год из пяти цифр. Если в году меньше пяти цифр, то он дополняется начальными нулями
z	        Представляет смещение в часах относительно времени UTC
zz	        Представляет смещение в часах относительно времени UTC. Если смещение представляет одну цифру, то она дополняется начальным нулем.


 */
//----------------------------------------------------------------------------------
/*
 Свойство Ticks для типа TimeSpan в C# хранит количество тиков времени, 
которые представляют длительность временного интервала. 

Тики - это единицы измерения времени, а в C# они эквивалентны 100 наносекундам. 

Таким образом, Ticks содержит число, которое представляет 
общее количество 100-наносекундных интервалов в TimeSpan. 

Это свойство может быть использовано для точного измерения и манипуляций с длительностью времени.
 
 */