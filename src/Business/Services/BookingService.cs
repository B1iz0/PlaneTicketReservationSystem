using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class BookingService : IDataService<Booking>
    {
        private readonly BookingRepository _bookings;
        private readonly Mapper _bookingMapper;

        public BookingService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _bookings = new BookingRepository(context);
            _bookingMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return _bookingMapper.Map<IEnumerable<Booking>>(await _bookings.GetAllAsync());
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            if (!_bookings.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such booking with id: {id}");
            return _bookingMapper.Map<Booking>(await _bookings.GetAsync(id));
        }

        public async Task PostAsync(Booking item)
        {
            await _bookings.CreateAsync(_bookingMapper.Map<BookingEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_bookings.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such booking with id: {id}");
            await _bookings.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Booking item)
        {
            if (!(await _bookings.IsExistingAsync(id)))
                throw new ElementNotFoundException($"No such booking with id: {id}");
            await _bookings.UpdateAsync(id, _bookingMapper.Map<BookingEntity>(item));
        }
    }
}
