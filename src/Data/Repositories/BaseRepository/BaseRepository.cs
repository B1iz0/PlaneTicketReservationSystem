using PlaneTicketReservationSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlaneTicketReservationSystem.Data.Repositories.BaseRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ReservationSystemContext Db;

        protected readonly DbSet<T> DbSet;

        protected BaseRepository(ReservationSystemContext context, DbSet<T> dbSet)
        {
            Db = context;
            this.DbSet = dbSet;
        }

        public async Task<T> CreateAsync(T item)
        {
            var addedEntityEntry = await DbSet.AddAsync(item);
            await Db.SaveChangesAsync();

            return addedEntityEntry.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            T item = await DbSet.FindAsync(id);
            if (item != null)
            {
                DbSet.Remove(item);
                await Db.SaveChangesAsync();
            }
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> FindWithLimitAndOffset(Expression<Func<T, bool>> predicate, int offset, int limit)
        {
            return DbSet.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            bool isItemExisting = (await GetAsync(id) != null);
            return isItemExisting;
        }

        public async Task UpdateAsync(T item)
        {
            DbSet.Update(item);
            await Db.SaveChangesAsync();
        }
    }
}
