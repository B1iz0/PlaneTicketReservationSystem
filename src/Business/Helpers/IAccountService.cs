﻿using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IAccountService
    {
        public Authenticate Authenticate(Authenticate model);
        public Authenticate RefreshToken(string token);
        public bool RevokeToken(string token);
        public string GenerateJwtToken(User user);
        public RefreshToken GenerateRefreshToken();
    }
}
