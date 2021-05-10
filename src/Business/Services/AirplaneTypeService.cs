using System;
using System.Collections.Generic;
using AutoMapper;
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

        public IEnumerable<AirplaneType> GetAll()
        {
            return _airplaneTypeMapper.Map<IEnumerable<AirplaneType>>(_airplaneTypes.GetAll());
        }

        public AirplaneType GetById(int id)
        {
            return _airplaneTypeMapper.Map<AirplaneType>(_airplaneTypes.Get(id));
        }

        public void Post(AirplaneType item)
        {
            _airplaneTypes.Create(_airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }

        public void Delete(int id)
        {
            _airplaneTypes.Delete(id);
        }

        public void Update(int id, AirplaneType item)
        {
            _airplaneTypes.Update(id, _airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }
    }
}
