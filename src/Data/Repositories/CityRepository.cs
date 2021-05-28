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
    public class CityRepository : IRepository<CityEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<CityEntity> _cities;

        public CityRepository(ReservationSystemContext context)
        {
            this._db = context;
            _cities = context.Cities;
        }
        public async Task CreateAsync(CityEntity item)
        {
            await _cities.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CityEntity city = await _cities.FindAsync(id);
            if (city != null)
            {
                _cities.Remove(city);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<CityEntity> Find(Expression<Func<CityEntity, bool>> predicate)
        {
            return _cities.Where(predicate);
        }

        public IQueryable<CityEntity> FindWithLimitAndOffset(Expression<Func<CityEntity, bool>> predicate, int offset, int limit)
        {
            return _cities.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task<CityEntity> GetAsync(int id)
        {
            return await _cities.FindAsync(id);
        }

        public async Task<IEnumerable<CityEntity>> GetAllAsync()
        {
            return await _cities.ToListAsync();
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _cities.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, CityEntity item)
        {
            item.Id = id;
            _cities.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
