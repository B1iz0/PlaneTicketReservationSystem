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
        private readonly ReservationSystemContext _db;
        private readonly DbSet<UserEntity> _users;

        public UserRepository(ReservationSystemContext context)
        {
            this._db = context;
            _users = context.Users;
        }

        public void Create(UserEntity item)
        {
            _users.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            UserEntity user = _users.Find(id);
            if (user != null)
            {
                _users.Remove(user);
                _db.SaveChanges();
            }
        }

        public IEnumerable<UserEntity> Find(Func<UserEntity, bool> predicate)
        {
            return _users.Where(predicate).ToList();
        }

        public UserEntity Get(int id)
        {
            return _users.Find(id);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _users;
        }

        public void Update(int id, UserEntity item)
        {
            if (!_users.Any(x => x.Id == id)) throw new Exception("No such id");
            item.Id = id;
            _users.Update(item);
            _db.SaveChanges();
        }
    }
}
