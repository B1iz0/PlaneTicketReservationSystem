using System;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AirportService : IDataService<Airport>
    {
        private readonly AirportRepository _airports;
        private readonly Mapper _airportMapper;

        public AirportService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _airports = new AirportRepository(context);
            _airportMapper = new Mapper(conf.AirportConfiguration);
        }

        public IEnumerable<Airport> GetAll()
        {
            return _airportMapper.Map<IEnumerable<Airport>>(_airports.GetAll());
        }

        public Airport GetById(int id)
        {
            return _airportMapper.Map<Airport>(_airports.Get(id));
        }

        public void Post(Airport item)
        {
            _airports.Create(_airportMapper.Map<AirportEntity>(item));
        }

        public void Delete(int id)
        {
            _airports.Delete(id);
        }

        public void Update(int id, Airport item)
        {
            throw new NotImplementedException();
        }
    }
}
