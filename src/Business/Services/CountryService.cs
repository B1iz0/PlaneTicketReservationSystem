using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CountryService : IDataService<Country>
    {
        private readonly CountryRepository _countries;
        private readonly Mapper _countryMapper;

        public CountryService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _countries = new CountryRepository(context);
            _countryMapper = new Mapper(conf.AirlineConfiguration);
        }

        public IEnumerable<Country> GetAll()
        {
            return _countryMapper.Map<IEnumerable<Country>>(_countries.GetAll());
        }

        public Country GetById(int id)
        {
            if (!_countries.Find(x => x.Id == id).Any())
                throw new Exception($"No such country with id: {id}");
            return _countryMapper.Map<Country>(_countries.Get(id));
        }

        public void Post(Country item)
        {
            if (_countries.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Country {item.Name} is already exist");
            _countries.Create(_countryMapper.Map<CountryEntity>(item));
        }

        public void Delete(int id)
        {
            if (!_countries.Find(x => x.Id == id).Any())
                throw new Exception($"No such country with id: {id}");
            _countries.Delete(id);
        }

        public void Update(int id, Country item)
        {
            if (!_countries.Find(x => x.Id == id).Any())
                throw new Exception($"No such country with id: {id}");
            _countries.Update(id, _countryMapper.Map<CountryEntity>(item));
        }
    }
}
