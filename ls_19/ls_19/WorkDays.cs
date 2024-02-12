using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls_19
{
    internal class WorkDays
    {
        public IEnumerator GetEnumerator()
        {
            yield return "Понедельник";
            yield return "Вторник";
            yield return "Среда";
            yield return "Четверг";
        }
    }
}
