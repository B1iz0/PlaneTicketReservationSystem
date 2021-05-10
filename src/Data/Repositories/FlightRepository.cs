using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class FlightRepository : IRepository<FlightEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<FlightEntity> _flights;

        public FlightRepository(ReservationSystemContext context)
        {
            this._db = context;
            _flights = context.Flights;
        }

        public IEnumerable<FlightEntity> GetAll()
        {
            return _flights;
        }

        public FlightEntity Get(int id)
        {
            return _flights.Find(id);
        }

        public IEnumerable<FlightEntity> Find(Func<FlightEntity, bool> predicate)
        {
            return _flights.Where(predicate).ToList();
        }

        public void Create(FlightEntity item)
        {
            _flights.Add(item);
            _db.SaveChanges();
        }

        public void Update(int id, FlightEntity item)
        {
            if (!_flights.Any(x => x.Id == id)) throw new Exception("No such id");
            item.Id = id;
            _flights.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            FlightEntity flight = _flights.Find(id);
            if (flight != null)
            {
                _flights.Remove(flight);
                _db.SaveChanges();
            }
        }
    }
}
