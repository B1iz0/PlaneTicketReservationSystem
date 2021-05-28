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
    public class FlightRepository : IRepository<FlightEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<FlightEntity> _flights;

        public FlightRepository(ReservationSystemContext context)
        {
            this._db = context;
            _flights = context.Flights;
        }

        public async Task<IEnumerable<FlightEntity>> GetAllAsync()
        {
            return await _flights.ToListAsync();
        }

        public async Task<FlightEntity> GetAsync(int id)
        {
            return await _flights.FindAsync(id);
        }

        public IQueryable<FlightEntity> Find(Expression<Func<FlightEntity, bool>> predicate)
        {
            return _flights.Where(predicate);
        }

        public IQueryable<FlightEntity> FindWithLimitAndOffset(Expression<Func<FlightEntity, bool>> predicate, int offset, int limit)
        {
            return _flights.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(FlightEntity item)
        {
            await _flights.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, FlightEntity item)
        {
            item.Id = id;
            _flights.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            FlightEntity flight = await _flights.FindAsync(id);
            if (flight != null)
            {
                _flights.Remove(flight);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _flights.AnyAsync(x => x.Id == id);
        }
    }
}
