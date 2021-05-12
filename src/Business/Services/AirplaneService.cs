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
    public class AirplaneService : IDataService<Airplane>
    {
        private readonly AirplaneRepository _airplanes;
        private readonly Mapper _airplaneMapper;

        public AirplaneService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _airplanes = new AirplaneRepository(context);
            _airplaneMapper = new Mapper(conf.AirlineConfiguration);
        }

        public IEnumerable<Airplane> GetAll()
        {
            var res = _airplanes.GetAll();
            return _airplaneMapper.Map<IEnumerable<Airplane>>(res);
        }

        public Airplane GetById(int id)
        {
            if (!_airplanes.Find(x => x.Id == id).Any())
                throw new Exception($"No such airplane with id: {id}");
            return _airplaneMapper.Map<Airplane>(_airplanes.Get(id));
        }

        public void Post(Airplane item)
        {
            if (_airplanes.Find(x => x.RegistrationNumber == item.RegistrationNumber).Any())
                throw new Exception("Such airplane is already exist");
            _airplanes.Create(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public void Delete(int id)
        {
            if (!_airplanes.Find(x => x.Id == id).Any())
                throw new Exception("No such airplane");
            _airplanes.Delete(id);
        }

        public void Update(int id, Airplane item)
        {
            if (!_airplanes.Find(x => x.Id == id).Any())
                throw new Exception("No such airplane");
            _airplanes.Update(id, _airplaneMapper.Map<AirplaneEntity>(item));
        }
    }
}
