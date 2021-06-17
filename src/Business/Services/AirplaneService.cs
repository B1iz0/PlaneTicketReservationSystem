using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplanes;

        private readonly Mapper _airplaneMapper;

        public AirplaneService(IAirplaneRepository airplanes, BusinessMappingsConfiguration conf)
        {
            _airplanes = airplanes;
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
            item.Id = id;
            await _airplanes.UpdateAsync(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public IEnumerable<Airplane> GetFreeAirplanes()
        {
            var freeAirplanes = _airplaneMapper.Map<IEnumerable<Airplane>>(_airplanes.GetFreeAirplanes());
            return freeAirplanes;
        }

        public IEnumerable<Airplane> GetFilteredAirplanes(int offset, int limit, string airplaneType, string company, string model)
        {
            Expression<Func<AirplaneEntity, bool>> predicate = a =>
                (string.IsNullOrEmpty(airplaneType) || a.AirplaneType.TypeName.Contains(airplaneType))
                && (string.IsNullOrEmpty(company) || a.Company.Name.Contains(company))
                && (string.IsNullOrEmpty(model) || a.Model.Contains(model));
            var airplanes = _airplaneMapper.Map<IEnumerable<Airplane>>(_airplanes.FindWithLimitAndOffset(predicate, offset, limit));
            return airplanes;
        }

        public int GetFilteredAirplanesCount(string airplaneType, string company, string model)
        {
            Expression<Func<AirplaneEntity, bool>> predicate = a =>
                (string.IsNullOrEmpty(airplaneType) || a.AirplaneType.TypeName.Contains(airplaneType))
                && (string.IsNullOrEmpty(company) || a.Company.Name.Contains(company))
                && (string.IsNullOrEmpty(model) || a.Model.Contains(model));
            int count = _airplanes.Find(predicate).Count();
            return count;
        }
    }
}
