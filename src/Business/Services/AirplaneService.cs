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
            return _airplaneMapper.Map<IEnumerable<Airplane>>(await _airplanes.GetAllAsync());
        }

        public async Task<Airplane> GetByIdAsync(int id)
        {
            if (!_airplanes.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            return _airplaneMapper.Map<Airplane>(await _airplanes.GetAsync(id));
        }

        public async Task PostAsync(Airplane item)
        {
            if (_airplanes.Find(x => x.RegistrationNumber == item.RegistrationNumber).Any())
                throw new ElementAlreadyExistException($"Airplane with registration number:{item.RegistrationNumber} is already exist");
            await _airplanes.CreateAsync(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_airplanes.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            await _airplanes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Airplane item)
        {
            if (!(await _airplanes.IsExistingAsync(id)))
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            await _airplanes.UpdateAsync(id, _airplaneMapper.Map<AirplaneEntity>(item));
        }
    }
}
