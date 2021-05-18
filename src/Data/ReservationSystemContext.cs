using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Data
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
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<AirplaneEntity> Airplanes { get; set; }
        public DbSet<FlightEntity> Flights { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<AirportEntity> Airports { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirplaneEntity>(AirplaneConfigure);
            modelBuilder.Entity<AirplaneTypeEntity>(AirplaneTypeConfigure);
            modelBuilder.Entity<AirportEntity>(AirportConfigure);
            modelBuilder.Entity<BookingEntity>(BookingConfigure);
            modelBuilder.Entity<CityEntity>(CityConfigure);
            modelBuilder.Entity<CompanyEntity>(CompanyConfigure);
            modelBuilder.Entity<CountryEntity>(CountryConfigure);
            modelBuilder.Entity<FlightEntity>(FlightConfigure);
            modelBuilder.Entity<RoleEntity>(RoleConfigure);
            modelBuilder.Entity<UserEntity>(UserConfigure);

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity[]
                {
                    new RoleEntity() {Id = 1, Name = "AdminApp"},
                    new RoleEntity() {Id = 2, Name = "Admin"},
                    new RoleEntity() {Id = 3, Name = "User"}
                });
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity[]
                {
                    new UserEntity()
                    {
                        Id = 1,
                        Email = "admin",
                        Password = PasswordHasher.GenerateHash("12345", PasswordHasher.Salt, SHA256.Create()),
                        FirstName = "admin",
                        LastName = "admin",
                        RoleId = 1
                    }
                });
        }

        public void AirplaneConfigure(EntityTypeBuilder<AirplaneEntity> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.HasOne<CompanyEntity>(a => a.Company)
                .WithMany(c => c.Airplanes)
                .HasForeignKey(a => a.CompanyId);
            modelBuilder.HasOne<AirplaneTypeEntity>(a => a.AirplaneType)
                .WithMany(at => at.Airplanes)
                .HasForeignKey(a => a.AirplaneTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Property(a => a.Id)
                .IsRequired();
            modelBuilder.Property(a => a.AirplaneTypeId)
                .IsRequired();
            modelBuilder.Property(a => a.CompanyId)
                .IsRequired();
            modelBuilder.Property(a => a.ModelNumber)
                .IsRequired();
            modelBuilder.Property(a => a.RegistrationNumber)
                .IsRequired();
            modelBuilder.Property(a => a.Capacity)
                .IsRequired();
        }

        public void AirplaneTypeConfigure(EntityTypeBuilder<AirplaneTypeEntity> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.Property(a => a.Id)
                .IsRequired();
            modelBuilder.Property(a => a.TypeName)
                .IsRequired()
                .HasMaxLength(15);
        }

        public void AirportConfigure(EntityTypeBuilder<AirportEntity> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.HasOne<CompanyEntity>(a => a.Company)
                .WithMany(c => c.Airports)
                .HasForeignKey(a => a.CompanyId);
            modelBuilder.HasOne<CityEntity>(a => a.City)
                .WithMany(c => c.Airports)
                .HasForeignKey(a => a.CityId);
            modelBuilder.Property(a => a.Id)
                .IsRequired();
            modelBuilder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Property(a => a.CityId)
                .IsRequired();
            modelBuilder.Property(a => a.CompanyId)
                .IsRequired();
        }

        public void BookingConfigure(EntityTypeBuilder<BookingEntity> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.HasOne<FlightEntity>(b => b.Flight)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FlightId);
            modelBuilder.HasOne<UserEntity>(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
            modelBuilder.Property(b => b.Id)
                .IsRequired();
            modelBuilder.Property(b => b.FlightId)
                .IsRequired();
            modelBuilder.Property(b => b.UserId)
                .IsRequired();
        }

        public void CityConfigure(EntityTypeBuilder<CityEntity> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.HasOne<CountryEntity>(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);
            modelBuilder.Property(c => c.Id)
                .IsRequired();
            modelBuilder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Property(c => c.CountryId)
                .IsRequired();
        }

        public void CompanyConfigure(EntityTypeBuilder<CompanyEntity> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.HasOne<CountryEntity>(c => c.Country)
                .WithMany(c => c.Companies)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Property(c => c.Id)
                .IsRequired();
            modelBuilder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Property(c => c.CountryId)
                .IsRequired();
        }

        public void CountryConfigure(EntityTypeBuilder<CountryEntity> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.Property(c => c.Id)
                .IsRequired();
            modelBuilder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
        }

        public void FlightConfigure(EntityTypeBuilder<FlightEntity> modelBuilder)
        {
            modelBuilder.HasKey(f => f.Id);
            modelBuilder.HasOne<AirplaneEntity>(f => f.Airplane)
                .WithOne(a => a.Flight)
                .HasForeignKey<FlightEntity>(f => f.AirplaneId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.HasOne<AirportEntity>(f => f.From)
                .WithMany(a => a.OutgoingAirplanes)
                .HasForeignKey(f => f.FromId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.HasOne<AirportEntity>(f => f.To)
                .WithMany(a => a.ArrivingAirplanes)
                .HasForeignKey(f => f.ToId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Property(f => f.Id)
                .IsRequired();
            modelBuilder.Property(f => f.AirplaneId)
                .IsRequired();
            modelBuilder.Property(f => f.FlightNumber)
                .IsRequired();
            modelBuilder.Property(f => f.FromId)
                .IsRequired();
            modelBuilder.Property(f => f.ToId)
                .IsRequired();
            modelBuilder.Property(f => f.DepartureDate)
                .IsRequired();
            modelBuilder.Property(f => f.DepartureTime)
                .IsRequired();
            modelBuilder.Property(f => f.ArrivalDate)
                .IsRequired();
            modelBuilder.Property(f => f.ArrivalTime)
                .IsRequired();
        }

        public void RoleConfigure(EntityTypeBuilder<RoleEntity> modelBuilder)
        {
            modelBuilder.HasKey(r => r.Id);
            modelBuilder.Property(r => r.Id)
                .IsRequired();
            modelBuilder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(20);
        }

        public void UserConfigure(EntityTypeBuilder<UserEntity> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id);
            modelBuilder.HasOne<RoleEntity>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.HasOne<CompanyEntity>(u => u.Company)
                .WithMany(c => c.Admins)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Property(u => u.Id)
                .IsRequired();
            modelBuilder.Property(u => u.Email)
                .IsRequired();
            modelBuilder.Property(u => u.RoleId)
                .IsRequired();
            modelBuilder.Property(u => u.Password)
                .IsRequired();
            modelBuilder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
