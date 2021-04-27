using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CompanyRepository : IRepository<CompanyEntity>
    {
        private ReservationSystemContext db;

        public CompanyRepository(ReservationSystemContext context)
        {
            this.db = context;
        }
        public IEnumerable<CompanyEntity> GetAll()
        {
            return db.Companies;
        }

        public CompanyEntity Get(int id)
        {
            return db.Companies.Find(id);
        }

        public IEnumerable<CompanyEntity> Find(Func<CompanyEntity, bool> predicate)
        {
            return db.Companies.Where(predicate).ToList();
        }

        public void Create(CompanyEntity item)
        {
            db.Companies.Add(item);
        }

        public void Update(CompanyEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            CompanyEntity company = db.Companies.Find(id);
            if (company != null)
            {
                db.Companies.Remove(company);
            }
        }
    }
}
