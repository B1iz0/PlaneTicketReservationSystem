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
        private readonly ReservationSystemContext _db;
        private readonly DbSet<CompanyEntity> _companies;

        public CompanyRepository(ReservationSystemContext context)
        {
            this._db = context;
            _companies = context.Companies;
        }
        public IEnumerable<CompanyEntity> GetAll()
        {
            return _companies;
        }

        public CompanyEntity Get(int id)
        {
            return _companies.Find(id);
        }

        public IEnumerable<CompanyEntity> Find(Func<CompanyEntity, bool> predicate)
        {
            return _companies.Where(predicate).ToList();
        }

        public void Create(CompanyEntity item)
        {
            _companies.Add(item);
            _db.SaveChanges();
        }

        public void Update(int id, CompanyEntity item)
        {
            if (!_companies.Any(x => x.Id == id)) throw new Exception("No such id");
            item.Id = id;
            _companies.Update(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            CompanyEntity company = _companies.Find(id);
            if (company != null)
            {
                _companies.Remove(company);
                _db.SaveChanges();
            }
        }
    }
}
