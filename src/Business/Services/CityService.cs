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
