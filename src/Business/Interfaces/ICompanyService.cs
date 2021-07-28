using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();

        Task<Company> GetByIdAsync(Guid id);

        Task<Company> PostAsync(Company item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Company item);

        IEnumerable<Company> GetFilteredCompanies(CompanyFilter filter, int offset, int limit);

        int GetFilteredCompaniesCount(CompanyFilter filter);

        IEnumerable<CompanyHint> GetHints(CompanyFilter filter, int offset, int limit);
    }
}
