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
            var countries = _countryMapper.Map<IEnumerable<Country>>(await _countries.GetAllAsync());
            return countries;
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
