using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepository _companies;

        private readonly Mapper _companyMapper;

        public CompanyService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _companies = new CompanyRepository(context);
            _companyMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = _companyMapper.Map<IEnumerable<Company>>(await _companies.GetAllAsync());
            return companies;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            bool isCompanyExisting = await _companies.IsExistingAsync(id);
            if (!isCompanyExisting)
            {
                throw new ElementNotFoundException($"No such company with id: {id}");
            }

            var company = _companyMapper.Map<Company>(await _companies.GetAsync(id));
            return company;
        }

        public async Task PostAsync(Company item)
        {
            bool isCompanyExisting = _companies.Find(x => x.Name == item.Name).Any();
            if (isCompanyExisting)
            {
                throw new ElementAlreadyExistException($"Company {item.Name} is already exist");
            }
            await _companies.CreateAsync(_companyMapper.Map<CompanyEntity>(item));
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
            await _companies.UpdateAsync(_companyMapper.Map<CompanyEntity>(item));
        }

        public IEnumerable<Company> GetFilteredCompanies(int offset, int limit, string companyName, string countryName)
        {
            IQueryable<CompanyEntity> result = _companies.FindWithLimitAndOffset(c =>
                (string.IsNullOrEmpty(companyName) || c.Name.Contains(companyName))
                && (string.IsNullOrEmpty(countryName) || c.Country.Name.Contains(countryName)),
                offset, limit);

            var companies = _companyMapper.Map<IEnumerable<Company>>(result);
            return companies;
        }

        public int GetFilteredCompaniesCount(string companyName, string countryName)
        {
            var companies = _companies.Find(c => (string.IsNullOrEmpty(companyName) || c.Name.Contains(companyName))
                                                 && (string.IsNullOrEmpty(countryName) || c.Country.Name.Contains(countryName)));
            int count = companies.Count();
            return count;
        }
    }
}
