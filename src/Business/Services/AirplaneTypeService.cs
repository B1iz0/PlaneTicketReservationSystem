using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public IEnumerable<AirplaneType> GetAll()
        {
            return _airplaneTypeMapper.Map<IEnumerable<AirplaneType>>(_airplaneTypes.GetAll());
        }

        public AirplaneType GetById(int id)
        {
            if (!_airplaneTypes.Find(x => x.Id == id).Any())
                throw new Exception($"No such type with id: {id}");
            return _airplaneTypeMapper.Map<AirplaneType>(_airplaneTypes.Get(id));
        }

        public void Post(AirplaneType item)
        {
            if (_airplaneTypes.Find(x => x.TypeName == item.TypeName).Any())
                throw new Exception($"Type {item.TypeName} is already exist");
            _airplaneTypes.Create(_airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }

        public void Delete(int id)
        {
            if (!_airplaneTypes.Find(x => x.Id == id).Any())
                throw new Exception($"No such type with id: {id}");
            _airplaneTypes.Delete(id);
        }

        public void Update(int id, AirplaneType item)
        {
            if (!_airplaneTypes.IsExisting(id))
                throw new Exception($"No such type with id: {id}");
            _airplaneTypes.Update(id, _airplaneTypeMapper.Map<AirplaneTypeEntity>(item));
        }
    }
}
