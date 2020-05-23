﻿using Moviemap.Common.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Data.Entities
{
    public class ChairEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int ColumnLocation { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int RowLocation { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public ChairType ChairType { get; set; }

        public RoomEntity Room { get; set; }

        public ICollection<ReservationChairsEntity> ReservationChairs { get; set; }
    }
}
