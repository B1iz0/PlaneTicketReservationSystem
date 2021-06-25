using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllAsync();

        Task<Company> GetByIdAsync(int id);

        Task PostAsync(Company item);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, Company item);

        IEnumerable<Company> GetFilteredCompanies(int offset, int limit, string companyName, string countryName);

        int GetFilteredCompaniesCount(string companyName, string countryName);
    }
}
