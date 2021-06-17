using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using PlaneTicketReservationSystem.Business;
using PlaneTicketReservationSystem.Business.Constants;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using Xunit;

namespace Business.Tests
{
    public class TokenProviderTests
    {
        private static Mock<IOptions<TokenSettings>> _mockTokenSettings;

        private static Mock<IRoleRepository> _mockRoleRepository;

        private static Mock<IUserRepository> _mockUserRepository;

        private static Mock<BusinessMappingsConfiguration> _mockMapperConf;

        private static TokenSettings _tokenSettings;

        public TokenProviderTests()
        {
            InitConfiguration();
        }

        private static void InitConfiguration()
        {
            _mockTokenSettings = new Mock<IOptions<TokenSettings>>();
            _mockRoleRepository = new Mock<IRoleRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapperConf = new Mock<BusinessMappingsConfiguration>();
            _tokenSettings = new TokenSettings();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            config.GetSection("AuthOptions").Bind(_tokenSettings);
        }

        [Theory]
        [ClassData(typeof(TokenProviderUsersTestData))]
        public async void GenerateJwtTokenTest(User user)
        {
            // Arrange
            _mockRoleRepository.Setup(rep => rep.GetAsync(user.RoleId)).Returns(GetTestRole(user));
            _mockTokenSettings.Setup(m => m.Value).Returns(_tokenSettings);
            var tokenProvider = new TokenProvider(_mockTokenSettings.Object, _mockUserRepository.Object, _mockRoleRepository.Object, _mockMapperConf.Object);

            // Act
            var result = await tokenProvider.GenerateJwtTokenAsync(user);

            // Assert
            //Assert.IsType(expected, result);
        }

        private static async Task<RoleEntity> GetTestRole(User user)
        {
            int roleId = user.RoleId;

            var roles = new List<RoleEntity>
            {
                new RoleEntity {Id = ApiRoles.AdminAppId, Name = ApiRoles.AdminApp},
                new RoleEntity {Id = ApiRoles.AdminId, Name = ApiRoles.Admin},
                new RoleEntity {Id = ApiRoles.UserId, Name = ApiRoles.User},
            };

            var roleResult = await Task.Run(() => roles.FirstOrDefault(role => role.Id == roleId));

            return roleResult;
        }
    }
}
