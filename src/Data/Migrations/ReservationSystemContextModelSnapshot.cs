﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaneTicketReservationSystem.Data;

namespace PlaneTicketReservationSystem.Data.Migrations
{
    [DbContext(typeof(ReservationSystemContext))]
    partial class ReservationSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirplaneTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BaggageCapacityInKilograms")
                        .HasColumnType("float");

                    b.Property<int>("Columns")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("int");

                    b.Property<int>("Rows")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneTypeId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirplaneTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("AirplaneTypes");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirportEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BaggageTotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<double>("BaggageWeightInKilograms")
                        .HasColumnType("float");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PlacesTotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.FlightEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirplaneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("FreeBaggageLimitInKilograms")
                        .HasColumnType("float");

                    b.Property<Guid>("FromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("OverweightPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("ToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId")
                        .IsUnique();

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PlaceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirplaneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<Guid?>("LastBlockedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastBlockingExpires")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlaceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("BookingId");

                    b.HasIndex("PlaceTypeId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PlaceTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlaceTypes");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirplaneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("PlaceTypeId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirplaneTypeEntity", "AirplaneType")
                        .WithMany("Airplanes")
                        .HasForeignKey("AirplaneTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Airplanes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirplaneType");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirportEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CityEntity", "City")
                        .WithMany("Airports")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Airports")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.BookingEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.FlightEntity", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.UserEntity", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId");

                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CountryEntity", "Country")
                        .WithMany("Companies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.FlightEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", "Airplane")
                        .WithOne("Flight")
                        .HasForeignKey("PlaneTicketReservationSystem.Data.Entities.FlightEntity", "AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirportEntity", "From")
                        .WithMany("OutgoingAirplanes")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirportEntity", "To")
                        .WithMany("ArrivingAirplanes")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PlaceEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", "Airplane")
                        .WithMany("Places")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.BookingEntity", "Booking")
                        .WithMany("Places")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.PlaceTypeEntity", "PlaceType")
                        .WithMany("Places")
                        .HasForeignKey("PlaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("Booking");

                    b.Navigation("PlaceType");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PriceEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", "Airplane")
                        .WithMany("Prices")
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.PlaceTypeEntity", "PlaceType")
                        .WithMany("Prices")
                        .HasForeignKey("PlaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("PlaceType");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Admins")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PlaneTicketReservationSystem.Data.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("PlaneTicketReservationSystem.Data.Entities.RefreshTokenEntity", "RefreshToken", b1 =>
                        {
                            b1.Property<Guid>("UserEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserEntityId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserEntityId");
                        });

                    b.Navigation("Company");

                    b.Navigation("RefreshToken");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirplaneEntity", b =>
                {
                    b.Navigation("Flight");

                    b.Navigation("Places");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirplaneTypeEntity", b =>
                {
                    b.Navigation("Airplanes");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.AirportEntity", b =>
                {
                    b.Navigation("ArrivingAirplanes");

                    b.Navigation("OutgoingAirplanes");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.BookingEntity", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CityEntity", b =>
                {
                    b.Navigation("Airports");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Airplanes");

                    b.Navigation("Airports");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.CountryEntity", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Companies");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.FlightEntity", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.PlaceTypeEntity", b =>
                {
                    b.Navigation("Places");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PlaneTicketReservationSystem.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
