using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.DataContext;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CountryRepository : IRepository<CountryEntity>
    {
        private ReservationSystemContext db;

        public CountryRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<CountryEntity> GetAll()
        {
            return db.Countries;
        }

        public CountryEntity Get(int id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<CountryEntity> Find(Func<CountryEntity, bool> predicate)
        {
            return db.Countries.Where(predicate).ToList();
        }

        public void Create(CountryEntity item)
        {
            db.Countries.Add(item);
        }

        public void Update(CountryEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CountryEntity country = db.Countries.Find(id);
            if (country != null)
            {
                db.Countries.Remove(country);
            }
        }
    }
}
