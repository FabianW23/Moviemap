using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class MyHour
    {
        public DateTime HourOfDate { get; set; }

        public string DateFormated => $"{HourOfDate: hh:mm tt}";

        public override string ToString()
        {
            return $"{HourOfDate: hh:mm tt}";
        }
    }
}
