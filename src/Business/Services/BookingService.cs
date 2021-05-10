using System;
using System.Collections.Generic;
using AutoMapper;
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

        public IEnumerable<Booking> GetAll()
        {
            return _bookingMapper.Map<IEnumerable<Booking>>(_bookings.GetAll());
        }

        public Booking GetById(int id)
        {
            return _bookingMapper.Map<Booking>(_bookings.Get(id));
        }

        public void Post(Booking item)
        {
            _bookings.Create(_bookingMapper.Map<BookingEntity>(item));
        }

        public void Delete(int id)
        {
            _bookings.Delete(id);
        }

        public void Update(int id, Booking item)
        {
            _bookings.Update(id, _bookingMapper.Map<BookingEntity>(item));
        }
    }
}
