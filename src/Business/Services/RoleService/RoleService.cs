using PlaneTicketReservationSystem.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roles;
        private readonly Mapper _roleMapper;

        public RoleService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _roles = new RoleRepository(context);
            _roleMapper = new Mapper(conf.UserMapperConfiguration);
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
            throw new NotImplementedException();
        }
    }
}
