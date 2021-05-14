using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class RoleRepository : IRepository<RoleEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<RoleEntity> _roles;

        public RoleRepository(ReservationSystemContext context)
        {
            this._db = context;
            _roles = context.Roles;
        }
        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await _roles.ToListAsync();
        }

        public async Task<RoleEntity> GetAsync(int id)
        {
            return await _roles.FindAsync(id);
        }

        public IEnumerable<RoleEntity> Find(Func<RoleEntity, bool> predicate)
        {
            return _roles.Where(predicate).ToList();
        }

        public async Task CreateAsync(RoleEntity item)
        {
            await _roles.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, RoleEntity item)
        {
            item.Id = id;
            _roles.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            RoleEntity role = await _roles.FindAsync(id);
            if (role != null)
            {
                _roles.Remove(role);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _roles.AnyAsync(x => x.Id == id);
        }
    }
}
