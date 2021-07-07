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
    public class AirplaneTypeService : IAirplaneTypeService
    {
        private readonly IAirplaneTypeRepository _airplaneTypes;

        private readonly IMapper _airplaneTypeMapper;

        public AirplaneTypeService(IAirplaneTypeRepository airplaneTypes, IMapper mapper)
        {
            _airplaneTypes = airplaneTypes;
            _airplaneTypeMapper = mapper;
        }

        public async Task<IEnumerable<AirplaneType>> GetAllAsync()
        {
            var airplaneTypes = _airplaneTypeMapper.Map<IEnumerable<AirplaneType>>(await _airplaneTypes.GetAllAsync());
            return airplaneTypes;
        }

        public async Task PostAsync(AirplaneType item)
        {
            bool isTypeExisting = _airplaneTypes.Find(x => x.TypeName == item.TypeName).Any();
            if (isTypeExisting)
            {
                throw new ElementAlreadyExistException($"Type {item.TypeName} is already exist");
            }
            var airplaneEntity = _airplaneTypeMapper.Map<AirplaneTypeEntity>(item);
            await _airplaneTypes.CreateAsync(airplaneEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            bool isTypeExisting = await _airplaneTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such type with id: {id}");
            }
            await _airplaneTypes.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, AirplaneType item)
        {
            bool isTypeExisting = await _airplaneTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such type with id: {id}");
            }
            item.Id = id;
            var airplaneEntity = _airplaneTypeMapper.Map<AirplaneTypeEntity>(item);
            await _airplaneTypes.UpdateAsync(airplaneEntity);
        }
    }
}
