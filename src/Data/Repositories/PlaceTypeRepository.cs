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
    public class PlaceTypeRepository : IRepository<PlaceTypeEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<PlaceTypeEntity> _placeTypes;

        public PlaceTypeRepository(ReservationSystemContext context)
        {
            this._db = context;
            _placeTypes = _db.PlaceTypes;
        }

        public async Task<IEnumerable<PlaceTypeEntity>> GetAllAsync()
        {
            return await _placeTypes.ToListAsync();
        }

        public async Task<PlaceTypeEntity> GetAsync(int id)
        {
            return await _placeTypes.FindAsync(id);
        }

        public IQueryable<PlaceTypeEntity> Find(Expression<Func<PlaceTypeEntity, bool>> predicate)
        {
            return _placeTypes.Where(predicate);
        }

        public IQueryable<PlaceTypeEntity> FindWithLimitAndOffset(Expression<Func<PlaceTypeEntity, bool>> predicate, int offset, int limit)
        {
            return _placeTypes.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(PlaceTypeEntity item)
        {
            await _placeTypes.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PlaceTypeEntity item)
        {
            item.Id = id;
            _placeTypes.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PlaceTypeEntity placeType = await _placeTypes.FindAsync(id);
            if (placeType != null)
            {
                _placeTypes.Remove(placeType);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _placeTypes.AnyAsync(x => x.Id == id);
        }
    }
}
