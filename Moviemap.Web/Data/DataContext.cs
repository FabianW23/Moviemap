using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data.Entities;

namespace Moviemap.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ReservationEntity> Reservations { get; set; }

        public DbSet<MovieEntity> Movies { get; set; }

        public DbSet<HourEntity> Hours { get; set; }

        public DbSet<CinemaEntity> Cinemas { get; set; }

        public DbSet<RoomEntity> Rooms { get; set; }

        public DbSet<ChairEntity> Chairs { get; set; }
    }
}

