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
            var countries = _countryMapper.Map<IEnumerable<Country>>(await _countries.GetAllAsync());
            return countries;
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            bool isCountryExisting = await _countries.IsExistingAsync(id);
            if (!isCountryExisting)
            {
                throw new ElementNotFoundException($"No such country with id: {id}");
            }

            var country = _countryMapper.Map<Country>(await _countries.GetAsync(id));
            return country;
        }

        public async Task PostAsync(Country item)
        {
            bool isCountryExisting = _countries.Find(x => x.Name == item.Name).Any();
            if (isCountryExisting)
            {
                throw new ElementAlreadyExistException($"Country {item.Name} is already exist");
            }
            await _countries.CreateAsync(_countryMapper.Map<CountryEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isCountryExisting = await _countries.IsExistingAsync(id);
            if (!isCountryExisting)
            {
                throw new ElementNotFoundException($"No such country with id: {id}");
            }
            await _countries.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Country item)
        {
            bool isCountryExisting = await _countries.IsExistingAsync(id);
            if (!isCountryExisting)
            {
                throw new ElementNotFoundException($"No such country with id: {id}");
            }
            item.Id = id;
            await _countries.UpdateAsync(_countryMapper.Map<CountryEntity>(item));
        }
    }
}
