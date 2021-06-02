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
    public class AirplaneService : IDataService<Airplane>
    {
        private readonly AirplaneRepository _airplanes;
        private readonly Mapper _airplaneMapper;

        public AirplaneService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _airplanes = new AirplaneRepository(context);
            _airplaneMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Airplane>> GetAllAsync()
        {
            var airplanes = _airplaneMapper.Map<IEnumerable<Airplane>>(await _airplanes.GetAllAsync());
            return airplanes;
        }

        public async Task<Airplane> GetByIdAsync(int id)
        {
            bool isAirplaneExist = await _airplanes.IsExistingAsync(id);
            if (!isAirplaneExist)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            var airplane = _airplaneMapper.Map<Airplane>(await _airplanes.GetAsync(id));
            return airplane;
        }

        public async Task PostAsync(Airplane item)
        {
            bool isAirplaneExisting = _airplanes.Find(x => x.RegistrationNumber == item.RegistrationNumber).Any();
            if (isAirplaneExisting)
            {
                throw new ElementAlreadyExistException($"Airplane with registration number:{item.RegistrationNumber} is already exist");
            }
            await _airplanes.CreateAsync(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isAirplaneExisting = await _airplanes.IsExistingAsync(id);
            if (!isAirplaneExisting)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            await _airplanes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Airplane item)
        {
            bool isAirplaneExisting = await _airplanes.IsExistingAsync(id);
            if (!isAirplaneExisting)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            await _airplanes.UpdateAsync(id, _airplaneMapper.Map<AirplaneEntity>(item));
        }
    }
}
