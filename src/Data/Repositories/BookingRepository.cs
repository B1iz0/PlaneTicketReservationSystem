using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class BookingRepository : IRepository<BookingEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<BookingEntity> _bookings;

        public BookingRepository(ReservationSystemContext context)
        {
            this._db = context;
            _bookings = context.Bookings;
        }

        public async Task CreateAsync(BookingEntity item)
        {
            await _bookings.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            BookingEntity booking = await _bookings.FindAsync(id);
            if (booking != null)
            {
                _bookings.Remove(booking);
                await _db.SaveChangesAsync();
            }
        }

        public IEnumerable<BookingEntity> Find(Func<BookingEntity, bool> predicate)
        {
            return _bookings.Where(predicate).ToList();
        }

        public async Task<BookingEntity> GetAsync(int id)
        {
            return await _bookings.FindAsync(id);
        }

        public async Task<IEnumerable<BookingEntity>> GetAllAsync()
        {
            return await _bookings.ToListAsync();
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _bookings.AnyAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, BookingEntity item)
        {
            item.Id = id;
            _bookings.Update(item);
            await _db.SaveChangesAsync();
        }
    }
}
