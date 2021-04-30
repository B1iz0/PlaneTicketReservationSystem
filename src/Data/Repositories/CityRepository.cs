using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CityRepository : IRepository<CityEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<CityEntity> _cities;

        public CityRepository(ReservationSystemContext context)
        {
            this._db = context;
            _cities = context.Cities;
        }
        public void Create(CityEntity item)
        {
            _cities.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            CityEntity city = _cities.Find(id);
            if (city != null)
            {
                _cities.Remove(city);
                _db.SaveChanges();
            }
        }

        public IEnumerable<CityEntity> Find(Func<CityEntity, bool> predicate)
        {
            return _cities.Where(predicate).ToList();
        }

        public CityEntity Get(int id)
        {
            return _cities.Find(id);
        }

        public IEnumerable<CityEntity> GetAll()
        {
            return _cities;
        }

        public void Update(CityEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
