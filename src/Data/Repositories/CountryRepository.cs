using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CountryRepository : IRepository<CountryEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<CountryEntity> _countries;

        public CountryRepository(ReservationSystemContext context)
        {
            this._db = context;
            _countries = context.Countries;
        }
        public IEnumerable<CountryEntity> GetAll()
        {
            return _countries;
        }

        public CountryEntity Get(int id)
        {
            return _countries.Find(id);
        }

        public IEnumerable<CountryEntity> Find(Func<CountryEntity, bool> predicate)
        {
            return _countries.Where(predicate).ToList();
        }

        public void Create(CountryEntity item)
        {
            _countries.Add(item);
            _db.SaveChanges();
        }

        public void Update(CountryEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            CountryEntity country = _countries.Find(id);
            if (country != null)
            {
                _countries.Remove(country);
                _db.SaveChanges();
            }
        }
    }
}
