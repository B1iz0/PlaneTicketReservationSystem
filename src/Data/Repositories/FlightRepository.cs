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
        private ReservationSystemContext db;

        public FlightRepository(ReservationSystemContext context)
        {
            this.db = context;
        }

        public IEnumerable<FlightEntity> GetAll()
        {
            return db.Flights;
        }

        public FlightEntity Get(int id)
        {
            return db.Flights.Find(id);
        }

        public IEnumerable<FlightEntity> Find(Func<FlightEntity, bool> predicate)
        {
            return db.Flights.Where(predicate).ToList();
        }

        public void Create(FlightEntity item)
        {
            db.Flights.Add(item);
        }

        public void Update(FlightEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            FlightEntity flight = db.Flights.Find(id);
            if (flight != null)
            {
                db.Flights.Remove(flight);
            }
        }
    }
}
