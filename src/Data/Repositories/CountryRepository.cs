using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<CountryEntity>> GetAllAsync()
        {
            return await _countries.ToListAsync();
        }

        public async Task<CountryEntity> GetAsync(int id)
        {
            return await _countries.FindAsync(id);
        }

        public IQueryable<CountryEntity> Find(Expression<Func<CountryEntity, bool>> predicate)
        {
            return _countries.Where(predicate);
        }

        public IQueryable<CountryEntity> FindWithLimitAndOffset(Expression<Func<CountryEntity, bool>> predicate, int offset, int limit)
        {
            return _countries.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(CountryEntity item)
        {
            await _countries.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CountryEntity item)
        {
            item.Id = id;
            _countries.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CountryEntity country = await _countries.FindAsync(id);
            if (country != null)
            {
                _countries.Remove(country);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _countries.AnyAsync(x => x.Id == id);
        }
    }
}
