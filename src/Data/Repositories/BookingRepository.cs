using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(BookingEntity item)
        {
            _bookings.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            BookingEntity booking = _bookings.Find(id);
            if (booking != null)
            {
                _bookings.Remove(booking);
                _db.SaveChanges();
            }
        }

        public IEnumerable<BookingEntity> Find(Func<BookingEntity, bool> predicate)
        {
            return _bookings.Where(predicate).ToList();
        }

        public BookingEntity Get(int id)
        {
            return _bookings.Find(id);
        }

        public IEnumerable<BookingEntity> GetAll()
        {
            return _bookings;
        }

        public void Update(BookingEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
