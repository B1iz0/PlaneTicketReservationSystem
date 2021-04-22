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
    public class AirplaneRepository : IRepository<Airplane>
    {
        private ReservationSystemContext db;

        public AirplaneRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<Airplane> GetAll()
        {
            return db.Airplanes;
        }

        public Airplane Get(int id)
        {
            return db.Airplanes.Find(id);
        }

        public IEnumerable<Airplane> Find(Func<Airplane, bool> predicate)
        {
            return db.Airplanes.Where(predicate).ToList();
        }

        public void Create(Airplane item)
        {
            db.Airplanes.Add(item);
        }

        public void Update(Airplane item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane != null)
            {
                db.Airplanes.Remove(airplane);
            }
        }
    }
}
