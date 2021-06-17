using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using PlaneTicketReservationSystem.Business;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using Xunit;

namespace Business.Tests
{
    public class TokenProviderTests
    {
        private readonly Mock<IOptions<TokenSettings>> _mockTokenSettings = new Mock<IOptions<TokenSettings>>();

        private readonly Mock<IRoleRepository> _mockRoleRepository = new Mock<IRoleRepository>();

        private readonly Mock<IUserRepository> _mockUserRepository = new Mock<IUserRepository>();

        private readonly Mock<BusinessMappingsConfiguration> _mockMapperConf = new Mock<BusinessMappingsConfiguration>();

        public static IEnumerable<object[]> TestData
            => new [] {
                new object[] { new User { Id = 1, Email = "test@mail.ru", FirstName = "testFirstName", LastName = "testLAstName", Password = "1234", RoleId = 1 } },
                new object[] { new User() }
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public async void GenerateJwtTokenTest(User user)
        {
            // Arrange
            var tokenSettings = new TokenSettings { Issuer = "AuthServer", Audience = "AuthClient", Key = "DxT9ZNTwWxs4H6ic3LPpVVHsMyW4sPde", LifeTime = 1};
            _mockRoleRepository.Setup(rep => rep.GetAsync(user.RoleId)).Returns(GetTestRole(user.RoleId));
            _mockTokenSettings.Setup(m => m.Value).Returns(tokenSettings);
            var tokenProvider = new TokenProvider(_mockTokenSettings.Object, _mockUserRepository.Object, _mockRoleRepository.Object, _mockMapperConf.Object);

            // Act
            var result = await tokenProvider.GenerateJwtTokenAsync(user);

            // Assert
            var tokenResult = Assert.IsType<string>(result);
        }

        private static async Task<RoleEntity> GetTestRole(int roleId)
        {
            var roles = new List<RoleEntity>
            {
                new RoleEntity {Id = 1, Name = "AdminApp"},
                new RoleEntity {Id = 2, Name = "Admin"},
                new RoleEntity {Id = 3, Name = "User"},
            };

            var roleResult = await Task.Run(() => roles.FirstOrDefault(role => role.Id == roleId));

            return roleResult;
        }
    }
}
