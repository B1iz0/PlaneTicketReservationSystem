using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PlaneTicketReservationSystem.Business.Models;

namespace Business.Tests
{
    public class TokenProviderUsersTestData : IEnumerable<object[]>
    {
        private readonly List<User> _testData = new List<User>();

        public TokenProviderUsersTestData()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            config.GetSection("UsersTestData").Bind(_testData);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var user in _testData)
            {
                yield return new object[] {user};
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
