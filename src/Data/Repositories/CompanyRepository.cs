using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<CompanyEntity>> GetAllAsync()
        {
            return await _companies.ToListAsync();
        }

        public async Task<CompanyEntity> GetAsync(int id)
        {
            return await _companies.FindAsync(id);
        }

        public IQueryable<CompanyEntity> Find(Expression<Func<CompanyEntity, bool>> predicate)
        {
            return _companies.Where(predicate);
        }

        public IQueryable<CompanyEntity> FindWithLimitAndOffset(Expression<Func<CompanyEntity, bool>> predicate, int offset, int limit)
        {
            return _companies.Where(predicate).Skip(offset).Take(limit);
        }

        public async Task CreateAsync(CompanyEntity item)
        {
            await _companies.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CompanyEntity item)
        {
            item.Id = id;
            _companies.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CompanyEntity company = await _companies.FindAsync(id);
            if (company != null)
            {
                _companies.Remove(company);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExistingAsync(int id)
        {
            return await _companies.AnyAsync(x => x.Id == id);
        }
    }
}
