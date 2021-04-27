using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.DataContext;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class BookingRepository : IRepository<BookingEntity>
    {
        private ReservationSystemContext db;

        public BookingRepository(ReservationSystemContext context)
        {
            this.db = context;
        }

        public void Create(BookingEntity item)
        {
            db.Bookings.Add(item);
        }

        public void Delete(int id)
        {
            BookingEntity booking = db.Bookings.Find(id);
            if (booking != null)
            {
                db.Bookings.Remove(booking);
            }
        }

        public IEnumerable<BookingEntity> Find(Func<BookingEntity, bool> predicate)
        {
            return db.Bookings.Where(predicate).ToList();
        }

        public BookingEntity Get(int id)
        {
            return db.Bookings.Find(id);
        }

        public IEnumerable<BookingEntity> GetAll()
        {
            return db.Bookings;
        }

        public void Update(BookingEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
