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
        private ReservationSystemContext db;

        public RoleRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<RoleEntity> GetAll()
        {
            return db.Roles;
        }

        public RoleEntity Get(int id)
        {
            return db.Roles.Find(id);
        }

        public IEnumerable<RoleEntity> Find(Func<RoleEntity, bool> predicate)
        {
            return db.Roles.Where(predicate).ToList();
        }

        public void Create(RoleEntity item)
        {
            db.Roles.Add(item);
        }

        public void Update(RoleEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            RoleEntity role = db.Roles.Find(id);
            if (role != null)
            {
                db.Roles.Remove(role);
            }        }
    }
}
