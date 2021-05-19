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
    public class AirplaneTypeService : IDataService<AirplaneType>
    {
        private readonly AirplaneTypeRepository _airplaneTypes;
        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypeService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _airplaneTypes = new AirplaneTypeRepository(context);
            _airplaneTypeMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<AirplaneType>> GetAllAsync()
        {
            return _airplaneTypeMapper.Map<IEnumerable<AirplaneType>>(await _airplaneTypes.GetAllAsync());
        }

        public async Task<AirplaneType> GetByIdAsync(int id)
        {
            if (!_airplaneTypes.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such type with id: {id}");
            return _airplaneTypeMapper.Map<AirplaneType>(await _airplaneTypes.GetAsync(id));
        }

        public async Task PostAsync(AirplaneType item)
        {
            if (_airplaneTypes.Find(x => x.TypeName == item.TypeName).Any())
                throw new ElementAlreadyExistException($"Type {item.TypeName} is already exist");
            await _airplaneTypes.CreateAsync(_airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_airplaneTypes.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such type with id: {id}");
            await _airplaneTypes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, AirplaneType item)
        {
            if (!(await _airplaneTypes.IsExistingAsync(id)))
                throw new ElementNotFoundException($"No such type with id: {id}");
            await _airplaneTypes.UpdateAsync(id, _airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }
    }
}
