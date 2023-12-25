using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//    − void SortAsc() — сортировка по возрастанию;
//    − void SortDesc() — сортировка по убыванию;
//    − void SortByParam(bool isAsc) — сортировка в зависимости от переданного параметра. Если isAsc равен true,
//    сортируем по возрастанию.Если isAsc равен false, сортируем по убыванию.

namespace HW_12
{
    internal interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }
}
