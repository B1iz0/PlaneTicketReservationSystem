using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business
{
    public class BusinessMappingsConfiguration
    {
        public readonly MapperConfiguration UserMapperConfiguration;

        public BusinessMappingsConfiguration()
        {
            UserMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<UserEntity, User>();
                x.CreateMap<User, UserEntity>();
                x.CreateMap<RoleEntity, Role>();
                x.CreateMap<Role, RoleEntity>();
            });
        }
    }
}
