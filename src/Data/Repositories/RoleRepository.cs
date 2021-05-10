using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<RoleEntity> GetAll()
        {
            return _roles;
        }

        public RoleEntity Get(int id)
        {
            return _roles.Find(id);
        }

        public IEnumerable<RoleEntity> Find(Func<RoleEntity, bool> predicate)
        {
            return _roles.Where(predicate).ToList();
        }

        public void Create(RoleEntity item)
        {
            _roles.Add(item);
            _db.SaveChanges();
        }

        public void Update(int id, RoleEntity item)
        {
            if (!_roles.Any(x => x.Id == id)) throw new Exception("No such id");
            item.Id = id;
            _roles.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            RoleEntity role = _roles.Find(id);
            if (role != null)
            {
                _roles.Remove(role);
                _db.SaveChanges();
            }
        }
    }
}
