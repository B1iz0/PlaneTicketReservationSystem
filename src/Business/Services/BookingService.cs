using System;
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

        private readonly IPlaceRepository _places;

        private readonly IMapper _bookingMapper;

        public BookingService(IBookingRepository bookings, IPlaceRepository places, IMapper mapper)
        {
            _bookings = bookings;
            _places = places;
            _bookingMapper = mapper;
        }

        public async Task<Booking> GetByIdAsync(Guid id)
        {
            var bookingEntity = await _bookings.GetAsync(id);
            if (bookingEntity == null)
            {
                throw new ElementNotFoundException($"No such booking with id: {id}");
            }
            var booking = _bookingMapper.Map<Booking>(bookingEntity);
            return booking;
        }

        public async Task<Guid> PostAsync(Booking item)
        {
            BookingEntity createdBooking = await _bookings.CreateAsync(_bookingMapper.Map<BookingEntity>(item));
            foreach (var placeId in item.PlacesId)
            {
                PlaceEntity currentSelectedPlace = await _places.GetAsync(placeId);
                currentSelectedPlace.BookingId = createdBooking.Id;
                await _places.UpdateAsync(currentSelectedPlace);
            }
            return createdBooking.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            bool isBookingExisting = await _bookings.IsExistingAsync(id);
            if (!isBookingExisting)
            {
                throw new ElementNotFoundException($"No such booking with id: {id}");
            }
            await _bookings.DeleteAsync(id);
        }
    }
}
