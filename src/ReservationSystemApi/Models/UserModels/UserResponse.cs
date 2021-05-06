﻿namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        // Add List of Bookings for current user.
    }
}
