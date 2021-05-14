using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return _countryMapper.Map<IEnumerable<Country>>(await _countries.GetAllAsync());
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            if (!_countries.Find(x => x.Id == id).Any())
                throw new Exception($"No such country with id: {id}");
            return _countryMapper.Map<Country>(await _countries.GetAsync(id));
        }

        public async Task PostAsync(Country item)
        {
            if (_countries.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Country {item.Name} is already exist");
            await _countries.CreateAsync(_countryMapper.Map<CountryEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_countries.Find(x => x.Id == id).Any())
                throw new Exception($"No such country with id: {id}");
            await _countries.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Country item)
        {
            if (!(await _countries.IsExistingAsync(id)))
                throw new Exception($"No such country with id: {id}");
            await _countries.UpdateAsync(id, _countryMapper.Map<CountryEntity>(item));
        }
    }
}
