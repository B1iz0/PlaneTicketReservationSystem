using System;
using System.Collections.Generic;
using AutoMapper;
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
            return _companyMapper.Map<Company>(_companies.Get(id));
        }

        public void Post(Company item)
        {
            _companies.Create(_companyMapper.Map<CompanyEntity>(item));
        }

        public void Delete(int id)
        {
            _companies.Delete(id);
        }

        public void Update(int id, Company item)
        {
            _companies.Update(id, _companyMapper.Map<CompanyEntity>(item));
        }
    }
}
