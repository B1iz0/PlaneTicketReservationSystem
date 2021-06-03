using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CompanyRepository : BaseRepository<CompanyEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<CompanyEntity> _companies;

        public CompanyRepository(ReservationSystemContext context) : base(context, context.Companies)
        {
            _db = context;
            _companies = context.Companies;
        }
    }
}
