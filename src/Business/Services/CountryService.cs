using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countries;

        private readonly IMapper _countryMapper;

        public CountryService(ICountryRepository countries, IMapper mapper)
        {
            _countries = countries;
            _countryMapper = mapper;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            IEnumerable<CountryEntity> countriesEntities = await _countries.GetAllAsync();
            var countries = _countryMapper.Map<IEnumerable<Country>>(countriesEntities);
            return countries;
        }

        public async Task PostAsync(Country item)
        {
            bool isCountryExisting = _countries.Find(x => x.Name == item.Name).Any();
            if (isCountryExisting)
            {
                throw new ElementAlreadyExistException($"Country {item.Name} is already exist");
            }
            var countryEntity = _countryMapper.Map<CountryEntity>(item);
            await _countries.CreateAsync(countryEntity);
        }

        public async Task UpdateAsync(Guid id, Country item)
        {
            bool isCountryExisting = await _countries.IsExistingAsync(id);
            if (!isCountryExisting)
            {
                throw new ElementNotFoundException($"No such country with id: {id}");
            }
            item.Id = id;
            var countryEntity = _countryMapper.Map<CountryEntity>(item);
            await _countries.UpdateAsync(countryEntity);
        }
    }
}
