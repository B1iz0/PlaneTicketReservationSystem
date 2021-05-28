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
    public class UserRepository : IRepository<UserEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<UserEntity> _users;

        public UserRepository(ReservationSystemContext context)
        {
            this._db = context;
            _users = context.Users;
        }

        public async Task CreateAsync(UserEntity item)
        {
            await _users.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            UserEntity user = await _users.FindAsync(id);
            if (user != null)
            {
                _users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<UserEntity> Find(Expression<Func<UserEntity, bool>> predicate)
        {
            return _users.Where(predicate);
        }

        public IQueryable<UserEntity> FindWithLimitAndOffset(Expression<Func<UserEntity, bool>> predicate, int offset, int limit)
        {
            return _users.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _users.ToListAsync();
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _users.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, UserEntity item)
        {
            item.Id = id;
            _users.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
