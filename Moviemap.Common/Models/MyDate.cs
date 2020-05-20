using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class MyDate
    {
        public DateTime Date { get; set; }

        public string DateFormated => $"{Date: yyyy/MM/dd}";

        public override string ToString()
        {
            return $"{Date: yyyy/MM/dd}";
        }
    }
}
