using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PlaceRepository : IRepository<PlaceEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<PlaceEntity> _places;

        public PlaceRepository(ReservationSystemContext context)
        {
            this._db = context;
            _places = _db.Places;
        }

        public async Task<IEnumerable<PlaceEntity>> GetAllAsync()
        {
            return await _places.ToListAsync();
        }

        public async Task<PlaceEntity> GetAsync(int id)
        {
            return await _places.FindAsync(id);
        }

        public IEnumerable<PlaceEntity> Find(Func<PlaceEntity, bool> predicate)
        {
            return _places.Where(predicate).ToList();
        }

        public async Task CreateAsync(PlaceEntity item)
        {
            await _places.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PlaceEntity item)
        {
            item.Id = id;
            _places.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PlaceEntity place = await _places.FindAsync(id);
            if (place != null)
            {
                _places.Remove(place);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _places.AnyAsync(x => x.Id == id);
        }
    }
}
