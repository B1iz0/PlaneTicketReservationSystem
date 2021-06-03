using System.Linq;
using System.Security.Cryptography;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Data
{
    public class ContextInitializer
    {
        private readonly ReservationSystemContext _db;

        public ContextInitializer(ReservationSystemContext context)
        {
            _db = context;
        }

        public void InitializeContext()
        {
            var adminAppRole = _db?.Roles.FirstOrDefault(r => r.Name == "AdminApp");
            if (adminAppRole == null)
            {
                _db?.Roles.Add(new RoleEntity { Id = 1, Name = "AdminApp" });
            }

            var adminRole = _db?.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (adminRole == null)
            {
                _db?.Roles.Add(new RoleEntity { Id = 2, Name = "Admin" });
            }

            var userRole = _db?.Roles.FirstOrDefault(r => r.Name == "User");
            if (userRole == null)
            {
                _db?.Roles.Add(new RoleEntity { Id = 3, Name = "User" });
            }

            var admin = _db?.Users.FirstOrDefault(u => u.Email == "admin");
            if (admin == null)
            {
                _db?.Users.Add(
                    new UserEntity
                    {
                        Email = "admin",
                        Password = PasswordHasher.GenerateHash("dima2002", PasswordHasher.Salt, SHA256.Create()),
                        FirstName = "admin",
                        LastName = "admin",
                        RoleId = 1
                    }
                );
            }

            _db?.SaveChanges();
        }
    }
}
