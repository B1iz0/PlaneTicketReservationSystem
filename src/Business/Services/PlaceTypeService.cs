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
    public class PlaceTypeService : IDataService<PlaceType>
    {
        private readonly PlaceTypeRepository _placeTypes;

        private readonly Mapper _placeTypeMapper;

        public PlaceTypeService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _placeTypes = new PlaceTypeRepository(context);
            _placeTypeMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<PlaceType>> GetAllAsync()
        {
            var placeTypes = _placeTypeMapper.Map<IEnumerable<PlaceType>>(await _placeTypes.GetAllAsync());
            return placeTypes;
        }

        public async Task<PlaceType> GetByIdAsync(int id)
        {
            bool isTypeExisting = await _placeTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException($"No such place type with id: {id}");
            }
            var placeType = _placeTypeMapper.Map<PlaceType>(await _placeTypes.GetAsync(id));
            return placeType;
        }

        public async Task PostAsync(PlaceType item)
        {
            bool isTypeExisting = _placeTypes.Find(x => x.Name == item.Name).Any();
            if (isTypeExisting)
            {
                throw new ElementAlreadyExistException("Such place type is already exist");
            }
            await _placeTypes.CreateAsync(_placeTypeMapper.Map<PlaceTypeEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isTypeExisting = await _placeTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException("No such place type");
            }
            await _placeTypes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, PlaceType item)
        {
            bool isTypeExisting = await _placeTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException("No such place type");
            }
            item.Id = id;
            await _placeTypes.UpdateAsync(_placeTypeMapper.Map<PlaceTypeEntity>(item));
        }
    }
}
