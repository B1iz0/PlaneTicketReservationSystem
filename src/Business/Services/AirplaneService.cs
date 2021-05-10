﻿using System.Collections.Generic;
using AutoMapper;
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
            Airplane airplane = _airplaneMapper.Map<Airplane>(_airplanes.Get(id));
            return airplane;
        }

        public void Post(Airplane item)
        {
            _airplanes.Create(_airplaneMapper.Map<AirplaneEntity>(item));
        }

        public void Delete(int id)
        {
            _airplanes.Delete(id);
        }

        public void Update(int id, Airplane item)
        {
            _airplanes.Update(id, _airplaneMapper.Map<AirplaneEntity>(item));
        }
    }
}
