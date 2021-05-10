using System;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class FlightService : IDataService<Flight>
    {
        private readonly FlightRepository _flights;
        private readonly Mapper _flightMapper;

        public FlightService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _flights = new FlightRepository(context);
            _flightMapper = new Mapper(conf.AirlineConfiguration);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _flightMapper.Map<IEnumerable<Flight>>(_flights.GetAll());
        }

        public Flight GetById(int id)
        {
            return _flightMapper.Map<Flight>(_flights.Get(id));
        }

        public void Post(Flight item)
        {
            _flights.Create(_flightMapper.Map<FlightEntity>(item));
        }

        public void Delete(int id)
        {
            _flights.Delete(id);
        }

        public void Update(int id, Flight item)
        {
            _flights.Update(id, _flightMapper.Map<FlightEntity>(item));
        }
    }
}
