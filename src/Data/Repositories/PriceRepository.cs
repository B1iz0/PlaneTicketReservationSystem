using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PriceRepository : IRepository<PriceEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<PriceEntity> _prices;

        public PriceRepository(ReservationSystemContext context)
        {
            this._db = context;
            _prices = _db.Prices;
        }

        public async Task<IEnumerable<PriceEntity>> GetAllAsync()
        {
            return await _prices.ToListAsync();
        }

        public async Task<PriceEntity> GetAsync(int id)
        {
            return await _prices.FindAsync(id);
        }

        public IEnumerable<PriceEntity> Find(Func<PriceEntity, bool> predicate)
        {
            return _prices.Where(predicate).ToList();
        }

        public async Task CreateAsync(PriceEntity item)
        {
            await _prices.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PriceEntity item)
        {
            item.Id = id;
            _prices.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PriceEntity price = await _prices.FindAsync(id);
            if (price != null)
            {
                _prices.Remove(price);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _prices.AnyAsync(x => x.Id == id);
        }
    }
}
