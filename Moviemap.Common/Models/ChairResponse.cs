using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class ChairResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ColumnLocation { get; set; }

        public int RowLocation { get; set; }

        public string ChairType { get; set; }

    }
}
