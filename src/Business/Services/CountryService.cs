using System;
using System.Collections.Generic;
using AutoMapper;
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
            return _countryMapper.Map<Country>(_countries.Get(id));
        }

        public void Post(Country item)
        {
            _countries.Create(_countryMapper.Map<CountryEntity>(item));
        }

        public void Delete(int id)
        {
            _countries.Delete(id);
        }

        public void Update(int id, Country item)
        {
            _countries.Update(id, _countryMapper.Map<CountryEntity>(item));
        }
    }
}
