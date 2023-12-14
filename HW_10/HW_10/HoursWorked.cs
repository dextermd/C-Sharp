using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    internal class HoursWorked
    {
        private double[] hours;
        private double avg() => hours.Sum();
        public double[] Hours { get => hours; set => hours = value; }

        public HoursWorked()
        {
            hours = new double[5];
        }

        public double this[string day]
        {
            
            get
            {
                switch (day.ToLower())
                {
                    case "понедельник": return hours[0];
                    case "вторник": return hours[1];
                    case "среда": return hours[2];
                    case "четверг": return hours[3];
                    case "пятница": return hours[4];
                    default: throw new IndexOutOfRangeException($"Неверное название дня недели");

                }
            }
            set
            {
                switch (day.ToLower())
                {
                    case "понедельник": hours[0] = value; break;
                    case "вторник": hours[1] = value; break;
                    case "среда": hours[2] = value; break;
                    case "четверг": hours[3] = value; break;
                    case "пятница": hours[4] = value; break;
                    default: throw new IndexOutOfRangeException($"Неверное название дня недели");

                }
            }
        }
        public override string ToString()
        {
            return $"\nДень недели Кол-во часов\n" +
                   $"Понедельник    :   {hours[0]}\n" +
                   $"Вторник        :   {hours[1]}\n" +
                   $"Среда          :   {hours[2]}\n" +
                   $"Четверг        :   {hours[3]}\n" +
                   $"Пятница        :   {hours[4]}\n" +
                   $"Всего часов    :   {avg()}";
        }
    }
}
