using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.DataContext;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneRepository : IRepository<AirplaneEntity>
    {
        private ReservationSystemContext db;

        public AirplaneRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<AirplaneEntity> GetAll()
        {
            return db.Airplanes;
        }

        public AirplaneEntity Get(int id)
        {
            return db.Airplanes.Find(id);
        }

        public IEnumerable<AirplaneEntity> Find(Func<AirplaneEntity, bool> predicate)
        {
            return db.Airplanes.Where(predicate).ToList();
        }

        public void Create(AirplaneEntity item)
        {
            db.Airplanes.Add(item);
        }

        public void Update(AirplaneEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AirplaneEntity airplane = db.Airplanes.Find(id);
            if (airplane != null)
            {
                db.Airplanes.Remove(airplane);
            }
        }
    }
}
