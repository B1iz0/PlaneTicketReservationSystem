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
    public class RoleService : IDataService<Role>
    {
        private readonly RoleRepository _roles;
        private readonly Mapper _roleMapper;

        public RoleService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _roles = new RoleRepository(context);
            _roleMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task DeleteAsync(int id)
        {
            if (!_roles.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such role with id: {id}");
            await _roles.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return _roleMapper.Map<IEnumerable<Role>>(await _roles.GetAllAsync());
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            if (!_roles.Find(x => x.Id == id).Any())
                throw new ElementNotFoundException($"No such role with id: {id}");
            return _roleMapper.Map<Role>(await _roles.GetAsync(id));
        }

        public async Task PostAsync(Role role)
        {
            if (_roles.Find(x => x.Name == role.Name).Any())
                throw new ElementAlreadyExistException($"Role {role.Name} is already exist");
            await _roles.CreateAsync(_roleMapper.Map<RoleEntity>(role));
        }

        public async Task UpdateAsync(int id, Role role)
        {
            if (!(await _roles.IsExistingAsync(id)))
                throw new ElementNotFoundException($"No such role with id: {id}");
            await _roles.UpdateAsync(id, _roleMapper.Map<RoleEntity>(role));
        }
    }
}
