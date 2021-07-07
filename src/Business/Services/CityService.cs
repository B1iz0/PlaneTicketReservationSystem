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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cities;

        private readonly IMapper _cityMapper;

        public CityService(ICityRepository cities, IMapper mapper)
        {
            _cities = cities;
            _cityMapper = mapper;
        }
        
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            var citiesEntities = await _cities.GetAllAsync();
            var cities = _cityMapper.Map<IEnumerable<City>>(citiesEntities);
            return cities;
        }

        public async Task PostAsync(City item)
        {
            bool isCityExisting = _cities.Find(x => x.Name == item.Name).Any();
            if (isCityExisting)
            {
                throw new ElementAlreadyExistException($"City {item.Name} is already exist");
            }
            var cityEntity = _cityMapper.Map<CityEntity>(item);
            await _cities.CreateAsync(cityEntity);
        }

        public async Task UpdateAsync(Guid id, City item)
        {
            bool isCityExisting = await _cities.IsExistingAsync(id);
            if (!isCityExisting)
            {
                throw new ElementNotFoundException($"No such city with id: {id}");
            }
            item.Id = id;
            var cityEntity = _cityMapper.Map<CityEntity>(item);
            await _cities.UpdateAsync(cityEntity);
        }
    }
}
