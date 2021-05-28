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
    public class AirplaneRepository : IRepository<AirplaneEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirplaneEntity> _airplanes;

        public AirplaneRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airplanes = _db.Airplanes;
        }
        public async Task<IEnumerable<AirplaneEntity>> GetAllAsync()
        {
            return await _airplanes.ToListAsync();
        }

        public async Task<AirplaneEntity> GetAsync(int id)
        {
            return await _airplanes.FindAsync(id);
        }

        public IQueryable<AirplaneEntity> Find(Expression<Func<AirplaneEntity, bool>> predicate)
        {
            return _airplanes.Where(predicate);
        }

        public IQueryable<AirplaneEntity> FindWithLimitAndOffset(Expression<Func<AirplaneEntity, bool>> predicate, int offset, int limit)
        {
            return _airplanes.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(AirplaneEntity item)
        {
            await _airplanes.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AirplaneEntity item)
        {
            item.Id = id;
            _airplanes.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AirplaneEntity airplane = await _airplanes.FindAsync(id);
            if (airplane != null)
            {
                _airplanes.Remove(airplane);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _airplanes.AnyAsync(x => x.Id == id);
        }
    }
}
