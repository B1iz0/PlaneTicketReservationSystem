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
    public class CityRepository : IRepository<CityEntity>
    {
        private ReservationSystemContext db;

        public CityRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public void Create(CityEntity item)
        {
            db.Cities.Add(item);
        }

        public void Delete(int id)
        {
            CityEntity city = db.Cities.Find(id);
            if (city != null)
            {
                db.Cities.Remove(city);
            }
        }

        public IEnumerable<CityEntity> Find(Func<CityEntity, bool> predicate)
        {
            return db.Cities.Where(predicate).ToList();
        }

        public CityEntity Get(int id)
        {
            return db.Cities.Find(id);
        }

        public IEnumerable<CityEntity> GetAll()
        {
            return db.Cities;
        }

        public void Update(CityEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
