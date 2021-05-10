using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneTypeRepository : IRepository<AirplaneTypeEntity>
    {
        private readonly ReservationSystemContext _db;
        private readonly DbSet<AirplaneTypeEntity> _airplaneTypes;

        public AirplaneTypeRepository(ReservationSystemContext context)
        {
            this._db = context;
            _airplaneTypes = context.AirplaneTypes;
        }
        public IEnumerable<AirplaneTypeEntity> GetAll()
        {
            return _airplaneTypes;
        }

        public AirplaneTypeEntity Get(int id)
        {
            return _airplaneTypes.Find(id);
        }

        public IEnumerable<AirplaneTypeEntity> Find(Func<AirplaneTypeEntity, bool> predicate)
        {
            return _airplaneTypes.Where(predicate).ToList();
        }

        public void Create(AirplaneTypeEntity item)
        {
            _airplaneTypes.Add(item);
            _db.SaveChanges();
        }

        public void Update(int id, AirplaneTypeEntity item)
        {
            if (!_airplaneTypes.Any(x => x.Id == id)) throw new Exception("No such id");
            item.Id = id;
            _airplaneTypes.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            AirplaneTypeEntity type = _airplaneTypes.Find(id);
            if (type != null)
            {
                _airplaneTypes.Remove(type);
                _db.SaveChanges();
            }
        }
    }
}
