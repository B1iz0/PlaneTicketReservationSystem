using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class CompanyService : IDataService<Company>
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
            return _companyMapper.Map<IEnumerable<Company>>(await _companies.GetAllAsync());
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            if (!_companies.Find(x => x.Id == id).Any())
                throw new Exception($"No such company with id: {id}");
            return _companyMapper.Map<Company>(await _companies.GetAsync(id));
        }

        public async Task PostAsync(Company item)
        {
            if (_companies.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Company {item.Name} is already exist");
            await _companies.CreateAsync(_companyMapper.Map<CompanyEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_companies.Find(x => x.Id == id).Any())
                throw new Exception($"No such company with id: {id}");
            await _companies.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Company item)
        {
            if (!(await _companies.IsExistingAsync(id)))
                throw new Exception($"No such company with id: {id}");
            await _companies.UpdateAsync(id, _companyMapper.Map<CompanyEntity>(item));
        }
    }
}
