using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mappers
{
    public class ApiMappingsConfiguration
    {
        public readonly MapperConfiguration UserMapperConfiguration;
        public readonly MapperConfiguration AuthMapperConfiguration;
        public readonly MapperConfiguration RoleMapperConfiguration;

        public ApiMappingsConfiguration()
        {
            UserMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<User, UserDetails>();
                x.CreateMap<User, UserResponse>();
                x.CreateMap<UserRegistration, User>();
                x.CreateMap<Role, RoleResponse>().ForMember(r => r.Users, opt => opt.Ignore());
                x.CreateMap<Booking, BookingResponse>().ForMember(b => b.User, opt => opt.Ignore());
            });
            AuthMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AuthenticateRequest, Authenticate>();
            });
            RoleMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Role, RoleResponse>();
                x.CreateMap<RoleRequest, Role>();
                x.CreateMap<User, UserResponse>();
            });
        }
    }
}
