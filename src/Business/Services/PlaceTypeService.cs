﻿using System;
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
            return _placeTypeMapper.Map<IEnumerable<PlaceType>>(await _placeTypes.GetAllAsync());
        }

        public async Task<PlaceType> GetByIdAsync(int id)
        {
            if (!(await _placeTypes.IsExistingAsync(id)))
                throw new ElementNotFoundException($"No such place type with id: {id}");
            return _placeTypeMapper.Map<PlaceType>(await _placeTypes.GetAsync(id));
        }

        public async Task PostAsync(PlaceType item)
        {
            if (_placeTypes.Find(x => x.Name == item.Name).Any())
                throw new ElementAlreadyExistException("Such place type is already exist");
            await _placeTypes.CreateAsync(_placeTypeMapper.Map<PlaceTypeEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!(await _placeTypes.IsExistingAsync(id)))
                throw new ElementNotFoundException("No such place type");
            await _placeTypes.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, PlaceType item)
        {
            if (!(await _placeTypes.IsExistingAsync(id)))
                throw new ElementNotFoundException("No such place type");
            await _placeTypes.UpdateAsync(id, _placeTypeMapper.Map<PlaceTypeEntity>(item));
        }
    }
}
