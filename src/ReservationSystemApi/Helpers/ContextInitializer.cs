using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using PlaneTicketReservationSystem.Business.Constants;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Helpers
{
    public class ContextInitializer
    {
        private readonly IPasswordProvider _passwordProvider;

        private readonly ReservationSystemContext _db;

        private readonly AdminAppOptions _adminOptions;

        public ContextInitializer(IPasswordProvider passwordProvider, IOptions<AdminAppOptions> adminOptions, ReservationSystemContext context)
        {
            _passwordProvider = passwordProvider;
            _db = context;
            _adminOptions = adminOptions.Value;
        }

        public void InitializeContext()
        {
            var adminAppRole = _db?.Roles.FirstOrDefault(role => role.Name == ApiRoles.AdminApp);
            if (adminAppRole == null)
            {
                _db?.Roles.Add(
                    new RoleEntity
                    {
                        Id = ApiRoles.AdminAppId, 
                        Name = ApiRoles.AdminApp
                    }
                );
            }

            var adminRole = _db?.Roles.FirstOrDefault(role => role.Name == ApiRoles.Admin);
            if (adminRole == null)
            {
                _db?.Roles.Add(
                    new RoleEntity
                    {
                        Id = ApiRoles.AdminId, 
                        Name = ApiRoles.Admin
                    }
                );
            }

            var userRole = _db?.Roles.FirstOrDefault(role => role.Name == ApiRoles.User);
            if (userRole == null)
            {
                _db?.Roles.Add(
                    new RoleEntity
                    {
                        Id = ApiRoles.UserId, 
                        Name = ApiRoles.User
                    }
                );
            }

            var admin = _db?.Users.FirstOrDefault(user => user.Email == _adminOptions.Email);
            if (admin == null)
            {
                _db?.Users.Add(
                    new UserEntity
                    {
                        Email = _adminOptions.Email,
                        Password = _passwordProvider.GenerateHash(_adminOptions.Password, SHA256.Create()),
                        FirstName = _adminOptions.FirstName,
                        LastName = _adminOptions.LastName,
                        RoleId = 1
                    }
                );
            }

            _db?.SaveChanges();
        }
    }
}
