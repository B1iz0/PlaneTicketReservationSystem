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
    public class AirplaneTypeService : IAirplaneTypeService
    {
        private readonly IAirplaneTypeRepository _airplaneTypes;

        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypeService(IAirplaneTypeRepository airplaneTypes, BusinessMappingsConfiguration conf)
        {
            _airplaneTypes = airplaneTypes;
            _airplaneTypeMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<AirplaneType>> GetAllAsync()
        {
            var airplaneTypes = _airplaneTypeMapper.Map<IEnumerable<AirplaneType>>(await _airplaneTypes.GetAllAsync());
            return airplaneTypes;
        }

        public async Task<AirplaneType> GetByIdAsync(int id)
        {
            bool isTypeExisting = await _airplaneTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such type with id: {id}");
            }

            var airplaneType = _airplaneTypeMapper.Map<AirplaneType>(await _airplaneTypes.GetAsync(id));
            return airplaneType;
        }

        public async Task PostAsync(AirplaneType item)
        {
            bool isTypeExisting = _airplaneTypes.Find(x => x.TypeName == item.TypeName).Any();
            if (isTypeExisting)
            {
                throw new ElementAlreadyExistException($"Type {item.TypeName} is already exist");
            }
            await _airplaneTypes.CreateAsync(_airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isTypeExisting = await _airplaneTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such type with id: {id}");
            }
            await _airplaneTypes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, AirplaneType item)
        {
            bool isTypeExisting = await _airplaneTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such type with id: {id}");
            }
            item.Id = id;
            await _airplaneTypes.UpdateAsync(_airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }
    }
}
