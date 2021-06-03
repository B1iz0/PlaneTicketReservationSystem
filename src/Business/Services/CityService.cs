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
    public class CityService : IDataService<City>
    {
        private readonly CityRepository _cities;

        private readonly Mapper _cityMapper;

        public CityService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _cities = new CityRepository(context);
            _cityMapper = new Mapper(conf.AirlineConfiguration);
        }
        
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            var cities = _cityMapper.Map<IEnumerable<City>>(await _cities.GetAllAsync());
            return cities;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            bool isCityExisting = await _cities.IsExistingAsync(id);
            if (!isCityExisting)
            {
                throw new ElementNotFoundException($"No such city with id: {id}");
            }

            var city = _cityMapper.Map<City>(await _cities.GetAsync(id));
            return city;
        }

        public async Task PostAsync(City item)
        {
            bool isCityExisting = _cities.Find(x => x.Name == item.Name).Any();
            if (isCityExisting)
            {
                throw new ElementAlreadyExistException($"City {item.Name} is already exist");
            }
            await _cities.CreateAsync(_cityMapper.Map<CityEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isCityExisting = await _cities.IsExistingAsync(id);
            if (!isCityExisting)
            {
                throw new ElementNotFoundException($"No such city with id: {id}");
            }
            await _cities.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, City item)
        {
            bool isCityExisting = await _cities.IsExistingAsync(id);
            if (!isCityExisting)
            {
                throw new ElementNotFoundException($"No such city with id: {id}");
            }
            item.Id = id;
            await _cities.UpdateAsync(_cityMapper.Map<CityEntity>(item));
        }
    }
}
