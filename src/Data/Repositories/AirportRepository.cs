using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirportRepository : IRepository<AirportEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirportEntity> _airports;

        public AirportRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airports = context.Airports;
        }

        public void Create(AirportEntity item)
        {
            _airports.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            AirportEntity airport = _airports.Find(id);
            if (airport != null)
            {
                _airports.Remove(airport);
                _db.SaveChanges();
            }
        }

        public IEnumerable<AirportEntity> Find(Func<AirportEntity, bool> predicate)
        {
            return _airports.Where(predicate).ToList();
        }

        public AirportEntity Get(int id)
        {
            return _airports.Find(id);
        }

        public IEnumerable<AirportEntity> GetAll()
        {
            return _airports;
        }

        public void Update(int id, AirportEntity item)
        {
            item.Id = id;
            _airports.Update(item);
            _db.SaveChanges();
        }
    }
}
