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
    public class AirplaneTypeRepository : IRepository<AirplaneTypeEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirplaneTypeEntity> _airplaneTypes;

        public AirplaneTypeRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airplaneTypes = context.AirplaneTypes;
        }
        public async Task<IEnumerable<AirplaneTypeEntity>> GetAllAsync()
        {
            return await _airplaneTypes.ToListAsync();
        }

        public async Task<AirplaneTypeEntity> GetAsync(int id)
        {
            return await _airplaneTypes.FindAsync(id);
        }

        public IQueryable<AirplaneTypeEntity> Find(Expression<Func<AirplaneTypeEntity, bool>> predicate)
        {
            return _airplaneTypes.Where(predicate);
        }

        public IQueryable<AirplaneTypeEntity> FindWithLimitAndOffset(Expression<Func<AirplaneTypeEntity, bool>> predicate, int offset, int limit)
        {
            return _airplaneTypes.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(AirplaneTypeEntity item)
        {
            await _airplaneTypes.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AirplaneTypeEntity item)
        {
            item.Id = id;
            _airplaneTypes.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AirplaneTypeEntity type = await _airplaneTypes.FindAsync(id);
            if (type != null)
            {
                _airplaneTypes.Remove(type);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _airplaneTypes.AnyAsync(x => x.Id == id);
        }
    }
}
