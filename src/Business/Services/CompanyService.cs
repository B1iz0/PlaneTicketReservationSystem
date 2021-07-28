using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companies;

        private readonly IMapper _companyMapper;

        public CompanyService(ICompanyRepository companies, IMapper mapper)
        {
            _companies = companies;
            _companyMapper = mapper;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            IEnumerable<CompanyEntity> companiesEntities = await _companies.GetAllAsync();
            var companies = _companyMapper.Map<IEnumerable<Company>>(companiesEntities);
            return companies;
        }

        public async Task<Company> GetByIdAsync(Guid id)
        {
            CompanyEntity companyEntity = await _companies.GetAsync(id);
            if (companyEntity == null)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }
            var company = _companyMapper.Map<Company>(companyEntity);
            return company;
        }

        public async Task<Company> PostAsync(Company item)
        {
            bool isCompanyExisting = _companies.Find(x => x.Name == item.Name).Any();
            if (isCompanyExisting)
            {
                throw new ElementAlreadyExistException($"Company {item.Name} is already exist");
            }
            var companyEntity = _companyMapper.Map<CompanyEntity>(item);
            CompanyEntity createdCompanyEntity = await _companies.CreateAsync(companyEntity);
            var createdCompany = _companyMapper.Map<Company>(createdCompanyEntity);
            return createdCompany;
        }

        public async Task DeleteAsync(Guid id)
        {
            bool isCompanyExisting = await _companies.IsExistingAsync(id);
            if (!isCompanyExisting)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }
            await _companies.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, Company item)
        {
            item.Id = id;
            var companyEntity = _companyMapper.Map<CompanyEntity>(item);
            await _companies.UpdateAsync(companyEntity);
        }

        public IEnumerable<Company> GetFilteredCompanies(CompanyFilter filter, int offset, int limit)
        {
            Expression<Func<CompanyEntity, bool>> predicate = c =>
                (string.IsNullOrEmpty(filter.CompanyName) || c.Name.Contains(filter.CompanyName))
                && (string.IsNullOrEmpty(filter.CountryName) || c.Country.Name.Contains(filter.CountryName));
            IEnumerable<CompanyEntity> result = _companies.FindWithLimitAndOffset(predicate, offset, limit);
            var companies = _companyMapper.Map<IEnumerable<Company>>(result);
            return companies;
        }

        public int GetFilteredCompaniesCount(CompanyFilter filter)
        {
            Expression<Func<CompanyEntity, bool>> predicate = c =>
                (string.IsNullOrEmpty(filter.CompanyName) || c.Name.Contains(filter.CompanyName))
                && (string.IsNullOrEmpty(filter.CountryName) || c.Country.Name.Contains(filter.CountryName));
            IQueryable<CompanyEntity> companies = _companies.Find(predicate);
            int count = companies.Count();
            return count;
        }

        public IEnumerable<CompanyHint> GetHints(CompanyFilter filter, int offset, int limit)
        {
            IEnumerable<Company> companies = GetFilteredCompanies(filter, offset, limit);
            var hints = _companyMapper.Map<IEnumerable<CompanyHint>>(companies);
            return hints;
        }
    }
}
