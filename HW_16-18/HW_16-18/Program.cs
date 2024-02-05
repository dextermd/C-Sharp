using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_16_18
{
    internal class Program
    {
        static void Main(string[] args)
        {

#if true
            //  Задание 1: Создайте generic класс Стека. Реализуйте стандартные методы и свойства для работы стека:
            //    − pop;
            //    − push;
            //    − peek;
            //    − count.
            //  Подробнее об устройстве стека читайте тут: https://en.wikipedia.org/wiki/Stack_(abstract_data_type)

            StackT<int> stack = new StackT<int>();

            stack.Push(254);
            stack.Push(12);
            stack.Push(23);
            stack.Push(101);


            stack.Peek();
            stack.Pop();

            Console.WriteLine();

            stack.Peek();


#endif

#if true
            //  Задание 2: Создайте generic класс Очередь с приоритетами. Реализуйте стандартные методы и
            //  свойства для работы очереди с приоритетами.
            //  Подробности тут: https://en.wikipedia.org/wiki/Priority_queue
#endif

#if true
            //  Задание 3: Создайте приложение для учёта сотрудников.Необходимо хранить следующую
            //  информацию:
            //    − ФИО
            //    − Должность
            //    − Заработная плата
            //    − Рабочий email
            //  Для хранения данных сотрудников используйте класс List<T>.Приложение должно предоставлять такую
            //  функциональность:
            //    − Добавление сотрудников
            //    − Удаление сотрудников
            //    − Изменение информации о сотрудниках
            //    − Поиск сотрудников по параметрам
            //    − Сортировка сотрудников по параметрам
            //  Для удобства использования создайте пользовательское меню. Организуйте возможность тестирования
            //  работы программы на уже готовом списке сотрудников
#endif

            Console.ReadLine();
        }
    }
}
