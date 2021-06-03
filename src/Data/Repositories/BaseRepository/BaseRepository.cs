using PlaneTicketReservationSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlaneTicketReservationSystem.Data.Repositories.BaseRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<T> _dbSet;

        public BaseRepository(ReservationSystemContext context, DbSet<T> dbSet)
        {
            _db = context;
            _dbSet = dbSet;
        }

        public async Task CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T item = await _dbSet.FindAsync(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> FindWithLimitAndOffset(Expression<Func<T, bool>> predicate, int offset, int limit)
        {
            return _dbSet.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            T item = await GetAsync(id);
            bool isItemExisting = (item != null);
            return isItemExisting;
        }

        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
