using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_20
{
    internal class DailyTemperatureRecord
    {
        public DateTime Date { get; set; }
        public double MaxT { get; set; }
        public double MinT { get; set; }

        public DailyTemperatureRecord(DateTime date, double maxT, double minT)
        {
            Date = date;
            MaxT = maxT;
            MinT = minT;
        }
        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}\n" +
                   $"Max Temperature: {MaxT}\n" +
                   $"Min Temperature: {MinT}\n";
        }
    }
}
