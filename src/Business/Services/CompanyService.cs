using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Company> GetAll()
        {
            return _companyMapper.Map<IEnumerable<Company>>(_companies.GetAll());
        }

        public Company GetById(int id)
        {
            if (!_companies.Find(x => x.Id == id).Any())
                throw new Exception($"No such company with id: {id}");
            return _companyMapper.Map<Company>(_companies.Get(id));
        }

        public void Post(Company item)
        {
            if (_companies.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Company {item.Name} is already exist");
            _companies.Create(_companyMapper.Map<CompanyEntity>(item));
        }

        public void Delete(int id)
        {
            if (!_companies.Find(x => x.Id == id).Any())
                throw new Exception($"No such company with id: {id}");
            _companies.Delete(id);
        }

        public void Update(int id, Company item)
        {
            if (!_companies.Find(x => x.Id == id).Any())
                throw new Exception($"No such company with id: {id}");
            _companies.Update(id, _companyMapper.Map<CompanyEntity>(item));
        }
    }
}
