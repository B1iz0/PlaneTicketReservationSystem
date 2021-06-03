using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class BookingRepository : BaseRepository<BookingEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<BookingEntity> _bookings;

        public BookingRepository(ReservationSystemContext context) : base(context, context.Bookings)
        {
            _db = context;
            _bookings = context.Bookings;
        }
    }
}
