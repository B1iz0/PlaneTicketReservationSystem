using System;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class RoleService : IDataService<Role>
    {
        private readonly RoleRepository _roles;
        private readonly Mapper _roleMapper;

        public RoleService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _roles = new RoleRepository(context);
            _roleMapper = new Mapper(conf.AirlineConfiguration);
        }

        public void Delete(int id)
        {
            _roles.Delete(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleMapper.Map<IEnumerable<Role>>(_roles.GetAll());
        }

        public Role GetById(int id)
        {
            Role role = _roleMapper.Map<Role>(_roles.Get(id));
            if (role == null) return null;
            return role;
        }

        public void Post(Role role)
        {
            _roles.Create(_roleMapper.Map<RoleEntity>(role));
        }

        public void Update(int id, Role role)
        {
            _roles.Update(id, _roleMapper.Map<RoleEntity>(role));
        }
    }
}
