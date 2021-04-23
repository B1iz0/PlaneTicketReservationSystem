using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Data.DataContext
{
    public class ReservationSystemContext : DbContext
    {
        public ReservationSystemContext(DbContextOptions<ReservationSystemContext> options)
            : base(options)
        {
        }

        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AirplaneTypeEntity> AirplaneTypes { get; set; }
        public DbSet<AirplaneEntity> Airplanes { get; set; }
        public DbSet<FlightEntity> Flights { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<AirportEntity> Airports { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
    }
}
