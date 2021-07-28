using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplanes;

        private readonly IMapper _airplaneMapper;

        public AirplaneService(IAirplaneRepository airplanes, IMapper mapper)
        {
            _airplanes = airplanes;
            _airplaneMapper = mapper;
        }

        public async Task<Airplane> GetByIdAsync(Guid id)
        {
            var airplaneEntity = await _airplanes.GetAsync(id);
            if (airplaneEntity == null)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            var airplane = _airplaneMapper.Map<Airplane>(airplaneEntity);
            return airplane;
        }

        public async Task<Airplane> PostAsync(Airplane item)
        {
            bool isAirplaneExisting = _airplanes.Find(x => x.RegistrationNumber == item.RegistrationNumber).Any();
            if (isAirplaneExisting)
            {
                throw new ElementAlreadyExistException($"Airplane with registration number:{item.RegistrationNumber} is already exist");
            } 
            AirplaneEntity createdAirplaneEntity = await _airplanes.CreateAsync(_airplaneMapper.Map<AirplaneEntity>(item));
            var createdAirplane = _airplaneMapper.Map<Airplane>(createdAirplaneEntity);
            return createdAirplane;
        }

        public async Task DeleteAsync(Guid id)
        {
            bool isAirplaneExisting = await _airplanes.IsExistingAsync(id);
            if (!isAirplaneExisting)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            await _airplanes.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, Airplane item)
        {
            bool isAirplaneExisting = await _airplanes.IsExistingAsync(id);
            if (!isAirplaneExisting)
            {
                throw new ElementNotFoundException($"Airplane with id:{id} is not found");
            }
            item.Id = id;
            await _airplanes.UpdateAsync(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public IEnumerable<Airplane> GetFreeAirplanes()
        {
            var freeAirplanesEntities = _airplanes.GetFreeAirplanes();
            var freeAirplanes = _airplaneMapper.Map<IEnumerable<Airplane>>(freeAirplanesEntities);
            return freeAirplanes;
        }

        public IEnumerable<Airplane> GetFilteredAirplanes(AirplaneFilter filter, int offset, int limit)
        {
            Expression<Func<AirplaneEntity, bool>> predicate = a =>
                (string.IsNullOrEmpty(filter.AirplaneType) || a.AirplaneType.TypeName.Contains(filter.AirplaneType))
                && (string.IsNullOrEmpty(filter.CompanyName) || a.Company.Name.Contains(filter.CompanyName))
                && (string.IsNullOrEmpty(filter.Model) || a.Model.Contains(filter.Model));
            var airplanesEntities = _airplanes.FindWithLimitAndOffset(predicate, offset, limit);
            var airplanes = _airplaneMapper.Map<IEnumerable<Airplane>>(airplanesEntities);
            return airplanes;
        }

        public int GetFilteredAirplanesCount(AirplaneFilter filter)
        {
            Expression<Func<AirplaneEntity, bool>> predicate = a =>
                (string.IsNullOrEmpty(filter.AirplaneType) || a.AirplaneType.TypeName.Contains(filter.AirplaneType))
                && (string.IsNullOrEmpty(filter.CompanyName) || a.Company.Name.Contains(filter.CompanyName))
                && (string.IsNullOrEmpty(filter.Model) || a.Model.Contains(filter.Model));
            var airplanesEntities = _airplanes.Find(predicate);
            int count = airplanesEntities.Count();
            return count;
        }

        public IEnumerable<AirplaneHint> GetHints(AirplaneFilter filter, int offset, int limit)
        {
            IEnumerable<Airplane> airplanes = GetFilteredAirplanes(filter, offset, limit);
            var hints = _airplaneMapper.Map<IEnumerable<AirplaneHint>>(airplanes);
            return hints;
        }
    }
}
