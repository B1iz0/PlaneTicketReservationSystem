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
        private ReservationSystemContext db;

        public AirplaneTypeRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<AirplaneTypeEntity> GetAll()
        {
            return db.AirplaneTypes;
        }

        public AirplaneTypeEntity Get(int id)
        {
            return db.AirplaneTypes.Find(id);
        }

        public IEnumerable<AirplaneTypeEntity> Find(Func<AirplaneTypeEntity, bool> predicate)
        {
            return db.AirplaneTypes.Where(predicate).ToList();
        }

        public void Create(AirplaneTypeEntity item)
        {
            db.AirplaneTypes.Add(item);
        }

        public void Update(AirplaneTypeEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AirplaneTypeEntity type = db.AirplaneTypes.Find(id);
            if (type != null)
            {
                db.AirplaneTypes.Remove(type);
            }
        }
    }
}
