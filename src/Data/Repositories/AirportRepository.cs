using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.DataContext;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirportRepository : IRepository<AirportEntity>
    {
        private ReservationSystemContext db;

        public AirportRepository(ReservationSystemContext context)
        {
            this.db = context;
        }

        public void Create(AirportEntity item)
        {
            db.Airports.Add(item);
        }

        public void Delete(int id)
        {
            AirportEntity airport = db.Airports.Find(id);
            if (airport != null)
            {
                db.Airports.Remove(airport);
            }
        }

        public IEnumerable<AirportEntity> Find(Func<AirportEntity, bool> predicate)
        {
            return db.Airports.Where(predicate).ToList();
        }

        public AirportEntity Get(int id)
        {
            return db.Airports.Find(id);
        }

        public IEnumerable<AirportEntity> GetAll()
        {
            return db.Airports;
        }

        public void Update(AirportEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
