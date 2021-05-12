using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneRepository : IRepository<AirplaneEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirplaneEntity> _airplanes;

        public AirplaneRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airplanes = _db.Airplanes;
        }
        public IEnumerable<AirplaneEntity> GetAll()
        {
            return _airplanes;
        }

        public AirplaneEntity Get(int id)
        {
            return _airplanes.Find(id);
        }

        public IEnumerable<AirplaneEntity> Find(Func<AirplaneEntity, bool> predicate)
        {
            return _airplanes.Where(predicate).ToList();
        }

        public void Create(AirplaneEntity item)
        {
            _airplanes.Add(item);
            _db.SaveChanges();
        }

        public void Update(int id, AirplaneEntity item)
        {
            item.Id = id;
            _airplanes.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            AirplaneEntity airplane = _airplanes.Find(id);
            if (airplane != null)
            {
                _airplanes.Remove(airplane);
                _db.SaveChanges();
            }
        }
    }
}
