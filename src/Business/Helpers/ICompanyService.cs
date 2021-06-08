using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface ICompanyService : IDataService<Company>
    {
        IEnumerable<Company> GetFilteredCompanies(int offset, int limit, string companyName, string countryName);

        int GetFilteredCompaniesCount(string companyName, string countryName);
    }
}
