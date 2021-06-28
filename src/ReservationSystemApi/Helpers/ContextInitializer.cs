using System.Linq;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using PlaneTicketReservationSystem.Business.Constants;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Helpers
{
    public class ContextInitializer
    {
        private readonly IPasswordService _passwordService;

        private readonly ReservationSystemContext _db;

        private readonly AdminAppOptions _adminOptions;

        public ContextInitializer(IPasswordService passwordService, IOptions<AdminAppOptions> adminOptions, ReservationSystemContext context)
        {
            _passwordService = passwordService;
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
                        Name = ApiRoles.Admin
                    }
                );
            }

            var userRole = _db?.Roles.FirstOrDefault(role => role.Name == ApiRoles.User);
            if (userRole == null)
            {
                _db?.Roles.AddAsync(
                    new RoleEntity
                    {
                        Name = ApiRoles.User
                    }
                );
            }

            _db?.SaveChanges();

            var admin = _db?.Users.FirstOrDefault(user => user.Email == _adminOptions.Email);
            if (admin == null)
            {
                RoleEntity adminAppRoleEntity = _db?.Roles.FirstOrDefault(role => role.Name == ApiRoles.AdminApp);
                if (adminAppRoleEntity != null)
                {
                    _db?.Users.Add(
                        new UserEntity
                        {
                            Email = _adminOptions.Email,
                            Password = _passwordService.GenerateHash(_adminOptions.Password, SHA256.Create()),
                            FirstName = _adminOptions.FirstName,
                            LastName = _adminOptions.LastName,
                            RoleId = adminAppRoleEntity.Id
                        }
                    );
                }
            }

            _db?.SaveChanges();
        }
    }
}
