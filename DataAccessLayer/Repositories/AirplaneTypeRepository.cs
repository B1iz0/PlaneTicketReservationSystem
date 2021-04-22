using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class AirplaneTypeRepository : IRepository<AirplaneType>
    {
        private ReservationSystemContext db;

        public AirplaneTypeRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<AirplaneType> GetAll()
        {
            return db.AirplaneTypes;
        }

        public AirplaneType Get(int id)
        {
            return db.AirplaneTypes.Find(id);
        }

        public IEnumerable<AirplaneType> Find(Func<AirplaneType, bool> predicate)
        {
            return db.AirplaneTypes.Where(predicate).ToList();
        }

        public void Create(AirplaneType item)
        {
            db.AirplaneTypes.Add(item);
        }

        public void Update(AirplaneType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AirplaneType type = db.AirplaneTypes.Find(id);
            if (type != null)
            {
                db.AirplaneTypes.Remove(type);
            }
        }
    }
}
