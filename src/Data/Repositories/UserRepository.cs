using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        private ReservationSystemContext db;

        public UserRepository(ReservationSystemContext context)
        {
            this.db = context;
        }

        public void Create(UserEntity item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            UserEntity user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<UserEntity> Find(Func<UserEntity, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public UserEntity Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return db.Users;
        }

        public void Update(UserEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
