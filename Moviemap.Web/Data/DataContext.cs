using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moviemap.Web.Data.Entities;

namespace Moviemap.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
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

        public DbSet<UserEntity> Users { get; set; }
    }
}

