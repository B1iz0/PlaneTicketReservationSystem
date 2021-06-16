using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class RoleService : IRoleService
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
            bool isRoleExisting = await _roles.IsExistingAsync(id);
            if (!isRoleExisting)
            {
                throw new ElementNotFoundException($"No such role with id: {id}");
            }
            await _roles.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var roles = _roleMapper.Map<IEnumerable<Role>>(await _roles.GetAllAsync());
            return roles;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            bool isRoleExisting = await _roles.IsExistingAsync(id);
            if (!isRoleExisting)
            {
                throw new ElementNotFoundException($"No such role with id: {id}");
            }
            var role = _roleMapper.Map<Role>(await _roles.GetAsync(id));
            return role;
        }

        public async Task PostAsync(Role role)
        {
            bool isRoleExisting = _roles.Find(x => x.Name == role.Name).Any();
            if (isRoleExisting)
            {
                throw new ElementAlreadyExistException($"Role {role.Name} is already exist");
            }
            await _roles.CreateAsync(_roleMapper.Map<RoleEntity>(role));
        }

        public async Task UpdateAsync(int id, Role role)
        {
            bool isRoleExisting = await _roles.IsExistingAsync(id);
            if (!isRoleExisting)
            {
                throw new ElementNotFoundException($"No such role with id: {id}");
            }
            role.Id = id;
            await _roles.UpdateAsync(_roleMapper.Map<RoleEntity>(role));
        }
    }
}
