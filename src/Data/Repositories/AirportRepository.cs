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
    public class AirportRepository : IRepository<AirportEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirportEntity> _airports;

        public AirportRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airports = context.Airports;
        }

        public async Task CreateAsync(AirportEntity item)
        {
            await _airports.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AirportEntity airport = await _airports.FindAsync(id);
            if (airport != null)
            {
                _airports.Remove(airport);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<AirportEntity> Find(Expression<Func<AirportEntity, bool>> predicate)
        {
            return _airports.Where(predicate);
        }

        public IQueryable<AirportEntity> FindWithLimitAndOffset(Expression<Func<AirportEntity, bool>> predicate, int offset, int limit)
        {
            return _airports.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task<AirportEntity> GetAsync(int id)
        {
            return await _airports.FindAsync(id);
        }

        public async Task<IEnumerable<AirportEntity>> GetAllAsync()
        {
            return await _airports.ToListAsync();
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _airports.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, AirportEntity item)
        {
            item.Id = id;
            _airports.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
