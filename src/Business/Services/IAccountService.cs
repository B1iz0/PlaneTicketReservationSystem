using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Services
{
    public interface IAccountService
    {
        public string Authenticate(Authenticate model);

        public string GenerateJwtToken(User user);
    }
}
