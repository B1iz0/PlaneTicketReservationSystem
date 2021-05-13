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
            if (!_roles.Find(x => x.Id == id).Any())
                throw new Exception($"No such role with id: {id}");
            _roles.Delete(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleMapper.Map<IEnumerable<Role>>(_roles.GetAll());
        }

        public Role GetById(int id)
        {
            if (!_roles.Find(x => x.Id == id).Any())
                throw new Exception($"No such role with id: {id}");
            return _roleMapper.Map<Role>(_roles.Get(id));
        }

        public void Post(Role role)
        {
            if (_roles.Find(x => x.Name == role.Name).Any())
                throw new Exception($"Role {role.Name} is already exist");
            _roles.Create(_roleMapper.Map<RoleEntity>(role));
        }

        public void Update(int id, Role role)
        {
            if (!_roles.IsExisting(id))
                throw new Exception($"No such role with id: {id}");
            _roles.Update(id, _roleMapper.Map<RoleEntity>(role));
        }
    }
}
