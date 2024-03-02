namespace Битовые_флаги
{
    internal class Program
    {
        [Flags]
        enum AccessType
        {
            Deny = 0b00,  // двоичный литерал
            ReadOnly = 0b01,
            Write = 0b10,
            ReadWrite = 0b11 //часто используемая комбинация флагов
        }

        [Flags]
        enum Border
        {
            None = 0,
            Left = 1 << 0, //1 
            Top = 1 << 1, //2
            Right = 1 << 2, //4
            Bottom = 1 << 3  //8
        }

        [Flags]
        enum Days
        {
            Not = 0b00000000,
            Mon = 0b00000001,
            Tue = 0b00000010,
            Wed = 0b00000100,
            Thu = 0b00001000,
            Fri = 0b00010000,
            Sat = 0b00100000,
            Sun = 0b01000000,
            //флаги можно комбинировать создавая наборы с помощью констант
            WorkingDays = Mon | Tue | Wed | Thu | Fri, //0b00011111
                                                       //или используя значения
            Weekend = 0b01100000, //Sat|Sun
            StudyDays = Mon | Tue  // 
        }

        //HEX
        [Flags]
        public enum CMYK2 : uint
        {
            None = 0,
            C = 0x1,
            M = 0x2,
            Y = 0x4,
            K = 0x8,
        }

        [FlagsAttribute]
        enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

        
        static void Main(string[] args)
        {
            // Перечисления как битовые флаги

            AccessType accessType = AccessType.Deny;
            Console.WriteLine(accessType + "  " + (int)accessType);

            //--------------------------------------------
            Border border = Border.Right;
            Console.WriteLine(border + "  " + (int)border);
            int totalSize = sizeof(Border) * Enum.GetValues(typeof(Border)).Length;
            Console.WriteLine("\n\nОбъем памяти в байтах одного элемента border: " + sizeof(DayOfWeek));
            Console.WriteLine("Общий объем памяти для перечисления Border: " + totalSize + " байт");


            foreach (string colorName in Enum.GetNames(typeof(Colors)))
            {
                Console.WriteLine("{0} = {1:D}", colorName, Enum.Parse(typeof(Colors), colorName));
            }


            //--------------------------------------------
            var monday = Days.Mon;
            //проверка битового флага
            if ((monday & Days.WorkingDays) != 0)
            {
                Console.WriteLine("Понедельник - рабочий день");
            }
            Console.WriteLine();
            var wdays = Days.WorkingDays;
            Console.WriteLine(wdays);
            Console.WriteLine();

            var goodDays = Days.Thu | Days.Tue;
            var badDays = Days.Fri | Days.Mon;
            Console.WriteLine($"Хорошие дни: {goodDays}");
            Console.WriteLine($"Плохие дни: {badDays}");

            //для установки флага используется оператор |(побитовое или):
            var x = Days.Mon | Days.Tue;
            x |= Days.Fri;
            Console.WriteLine(x);

            //Для проверки флага используется конструкция с оператором & (побитовое и):

            bool flag1 = (x & Days.Fri) == Days.Fri; //true
            //или
            bool flag2 = (x & Days.Fri) != 0; //true

            //Для сброса флага можно использовать оператор ^(xor):

            x = x ^ Days.Tue;
            Console.WriteLine(x);


            Console.WriteLine("\nЗначения типа Days:  ");
            var values_days = Enum.GetValues(typeof(Days));

            Console.WriteLine("Описание типа массива values_days: {0}", values_days.GetType());
            foreach (var value in values_days)
            {
                Console.WriteLine($"{value,-15} {(int)(value)}");
            }


#if true

            Weather day = new Weather();
            day = Weather.Clear | Weather.Rain | Weather.Snow | Weather.Sunny;

            Console.WriteLine(day);//Rain, Snow, Clear, Sunny
            day = day ^ Weather.Snow; // сброс флага
            Console.WriteLine(day);

            Random random = new Random();
            day = (Weather)random.Next(0, 512);
            Console.WriteLine("Случайное заполнение: {0}", day);
            Console.WriteLine();
#endif

#if false


            // Погода за неделю----------------------------
            //const int days = 7;
            Weather[] weathers = new Weather[7] {
                Weather.Sunny|Weather.Clear|Weather.Rain,
                Weather.Fog|Weather.Cloudy|Weather.LightRain|Weather.Clear,
                Weather.Clear|Weather.Rain|Weather.Snow|Weather.Sunny,
                Weather.Storm|Weather.Snow|Weather.Sunny,
                Weather.Fog|Weather.Cloudy|Weather.LightRain|Weather.Clear,
                Weather.Clear|Weather.Rain|Weather.Snow|Weather.Sunny,
                Weather.Sunny,
            };

            Console.WriteLine(weathers.Length);

            int count_sunny = 0;
            Console.Write("Номера солнечных дней в неделю:\n");
            for (int i = 0; i < weathers.Length; i++)
            {
                if ((weathers[i] & Weather.Sunny) == Weather.Sunny)
                {
                    Console.WriteLine(i + 1 + " - " + (Days)(i + 1));
                    count_sunny++;
                }
            }
            Console.WriteLine("Количество солнечных дней в неделю: {0}", count_sunny);

#endif

#if false

            int months = 2;
            int daysInMonth = 31;

            Weather[,] weatherData = new Weather[months, daysInMonth];

            // Заполняем массив информацией о погоде (пример)
            Random random = new Random();
            for (int month = 0; month < months; month++)
            {
                for (int day = 0; day < daysInMonth; day++)
                {
                    // Генерируем случайный тип погоды для каждого дня
                    Weather weather = (Weather)random.Next(1, 512); // 1-255 соответствуют различным типам погоды
                    weatherData[month, day] = weather;
                }
            }

            // Выполняем вычисления согласно вашим справкам
            int sunnyDays = CalculateSunnyDays(weatherData);
            int daysWithPrecipitation = CalculateDaysWithPrecipitation(weatherData);

            Console.WriteLine($"Среднее количество солнечных дней в месяц: {sunnyDays / months}");
            Console.WriteLine($"Общее количество дней в году с осадками: {daysWithPrecipitation}");

            for(int i = 0; i < weatherData.GetLength(0); i++)
            {
                Console.WriteLine("Month {0}", i+1);
                for(int j = 0; j < weatherData.GetLength(1); j++)
                {
                    Weather weather = weatherData[i, j];
                    string colorName = Enum.GetName(typeof(Weather), (int)weather);

                    Console.WriteLine($"День: {j + 1}, Погода: {weather}");
                }
                Console.WriteLine();
            }

            // Ввод данных с клавиатуры
            
            string userInput = "Rain, Storm, Clear";
            string[] weatherDescriptions = userInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Weather userWeather = Weather.NotDefined;

            foreach (string description in weatherDescriptions)
            {
                if (Enum.TryParse(description.Trim(), out Weather weather))
                {
                    userWeather |= weather;
                }
            }


#endif

            Console.Read();
        }
        //--------------------------------------------------------
        [Flags]
        enum Weather
        {
            NotDefined = 0,
            Rain = 1,
            LightRain = 2,
            Storm = 4,
            Snow = 8,
            Fog = 16,
            Cloudy = 32,
            Thunderclouds = 64,
            Clear = 128,
            Sunny = 256

        }
        static int CalculateSunnyDays(Weather[,] data)
        {
            int sunnyDays = 0;
            foreach (Weather weather in data)
            {
                if ((weather & Weather.Sunny) == Weather.Sunny)
                {
                    sunnyDays++;
                }
            }
            return sunnyDays;
        }

        static int CalculateDaysWithPrecipitation(Weather[,] data)
        {
            int daysWithPrecipitation = 0;
            foreach (Weather weather in data)
            {
                if ((weather & (Weather.Rain | Weather.Snow)) != 0)
                {
                    daysWithPrecipitation++;
                }
            }
            return daysWithPrecipitation;
        }
    }
}

/*
Перечисления можно использовать для хранения битовых флагов, 
благодаря этому экземпляр enum может содержать в себе комбинацию значений констант, 
определенных в списке. 

Для создания перечисления с битовыми флагами, используется атрибут [Flags]. 
Значения констант задаются таким образом, чтобы к ним можно было применять битовые операции.

Для использования перечислений как битовых флагов необходимо соблюдать требования:

- Обязательно включайте в перечисление константу со значением 0, 
обычно используется имя None;

- Константы должны быть степенями двойки 1, 2, 4… 
Это гарантирует что комбинации флагов не будут перекрываться;

- Если сочетания флагов часто используются, добавьте их в перечисление;

- Для констант используйте только положительные значения, 
поскольку отрицательные могут внести неоднозначность.

Определение битовых флагов перечислений.
Поскольку константы должны содержать степени двойки, 
можно задавать их несколькими вариантами:

- Двоичными литералами;
- Числовым литералом с операцией сдвига;
- Числами десятичной системы;
- Литералами шестнадцатеричной системы.
- Для присвоения значений константам, 
проще и нагляднее использовать двоичные литералы:

*/

/*
Самое большое преимущество битовых полей - 
выигрыш в быстродействии по сравнению с другими обычными методами 
(несколькими значениями типа boolean, словарями и т. д.). 

Увеличение быстродействия двойное.
- Во-первых, доступ к памяти. 
Если Вы используете Boolean для сохранении информации об объекте или любую другую информацию, 
то скорее всего Вы захотите устанавливать эти биты совместно. 
Часто пропускаемая оптимизация - кэш процессора.

- Способность комбинировать несколько значений в одном целом числе, 
что позволяет представлять множество состояний 
с использованием одной переменной и удобно работать с флагами и опциями.

*/