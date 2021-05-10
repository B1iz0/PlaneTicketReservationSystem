using System;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CityService : IDataService<City>
    {
        private readonly CityRepository _cities;
        private readonly Mapper _cityMapper;

        public CityService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _cities = new CityRepository(context);
            _cityMapper = new Mapper(conf.AirlineConfiguration);
        }
        
        public IEnumerable<City> GetAll()
        {
            return _cityMapper.Map<IEnumerable<City>>(_cities.GetAll());
        }

        public City GetById(int id)
        {
            return _cityMapper.Map<City>(_cities.Get(id));
        }

        public void Post(City item)
        {
            _cities.Create(_cityMapper.Map<CityEntity>(item));
        }

        public void Delete(int id)
        {
            _cities.Delete(id);
        }

        public void Update(int id, City item)
        {
            _cities.Update(id, _cityMapper.Map<CityEntity>(item));
        }
    }
}
