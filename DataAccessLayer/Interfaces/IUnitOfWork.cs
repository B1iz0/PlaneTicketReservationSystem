using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Airplane> Airplanes { get; }
        IRepository<AirplaneType> AirplaneTypes { get; }
        IRepository<Airport> Airports { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<City> Cities { get; }
        IRepository<Country> Countries { get; }
        IRepository<Flight> Flies { get; }
        IRepository<Role> Roles { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
