using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
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

        public async Task<Company> GetByIdAsync(int id)
        {
            CompanyEntity companyEntity = await _companies.GetAsync(id);
            if (companyEntity == null)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }
            var company = _companyMapper.Map<Company>(companyEntity);
            return company;
        }

        public async Task PostAsync(Company item)
        {
            bool isCompanyExisting = _companies.Find(x => x.Name == item.Name).Any();
            if (isCompanyExisting)
            {
                throw new ElementAlreadyExistException($"Company {item.Name} is already exist");
            }
            var companyEntity = _companyMapper.Map<CompanyEntity>(item);
            await _companies.CreateAsync(companyEntity);
        }

        public async Task DeleteAsync(int id)
        {
            bool isCompanyExisting = await _companies.IsExistingAsync(id);
            if (!isCompanyExisting)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }
            await _companies.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Company item)
        {
            bool isCompanyExisting = await _companies.IsExistingAsync(id);
            if (!isCompanyExisting)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }
            item.Id = id;
            var companyEntity = _companyMapper.Map<CompanyEntity>(item);
            await _companies.UpdateAsync(companyEntity);
        }

        public IEnumerable<Company> GetFilteredCompanies(int offset, int limit, string companyName, string countryName)
        {
            Expression<Func<CompanyEntity, bool>> predicate = c =>
                (string.IsNullOrEmpty(companyName) || c.Name.Contains(companyName))
                && (string.IsNullOrEmpty(countryName) || c.Country.Name.Contains(countryName));
            IEnumerable<CompanyEntity> result = _companies.FindWithLimitAndOffset(predicate, offset, limit);
            var companies = _companyMapper.Map<IEnumerable<Company>>(result);
            return companies;
        }

        public int GetFilteredCompaniesCount(string companyName, string countryName)
        {
            Expression<Func<CompanyEntity, bool>> predicate = c =>
                (string.IsNullOrEmpty(companyName) || c.Name.Contains(companyName))
                && (string.IsNullOrEmpty(countryName) || c.Country.Name.Contains(countryName));
            IQueryable<CompanyEntity> companies = _companies.Find(predicate);
            int count = companies.Count();
            return count;
        }
    }
}
