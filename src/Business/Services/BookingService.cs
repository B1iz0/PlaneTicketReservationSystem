using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookings;

        private readonly IMapper _bookingMapper;

        public BookingService(IBookingRepository bookings, IMapper mapper)
        {
            _bookings = bookings;
            _bookingMapper = mapper;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var bookings = _bookingMapper.Map<IEnumerable<Booking>>(await _bookings.GetAllAsync());
            return bookings;
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            var bookingEntity = await _bookings.GetAsync(id);
            if (bookingEntity == null)
            {
                throw new ElementNotFoundException($"No such booking with id: {id}");
            }
            var booking = _bookingMapper.Map<Booking>(bookingEntity);
            return booking;
        }

        public async Task PostAsync(Booking item)
        {
            await _bookings.CreateAsync(_bookingMapper.Map<BookingEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isBookingExisting = await _bookings.IsExistingAsync(id);
            if (!isBookingExisting)
            {
                throw new ElementNotFoundException($"No such booking with id: {id}");
            }
            await _bookings.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Booking item)
        {
            bool isBookingExisting = await _bookings.IsExistingAsync(id);
            if (!isBookingExisting)
            {
                throw new ElementNotFoundException($"No such booking with id: {id}");
            }
            item.Id = id;
            var bookingEntity = _bookingMapper.Map<BookingEntity>(item);
            await _bookings.UpdateAsync(bookingEntity);
        }
    }
}
