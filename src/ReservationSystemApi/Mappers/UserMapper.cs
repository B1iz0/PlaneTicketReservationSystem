using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mappers
{
    public class UserMapper
    {
        private readonly Mapper _mapper;

        public UserMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDetails>();
                cfg.CreateMap<UserRegistration, User>();
                cfg.CreateMap<User, UserResponse>();
            });
            _mapper = new Mapper(configuration);
        }

        public UserDetails UserToUserDetails(User user)
        {
            return _mapper.Map<User, UserDetails>(user);
        }

        public User UserRegistrationToUser(UserRegistration user)
        {
            return _mapper.Map<UserRegistration, User>(user);
        }

        public UserResponse UserToUserResponse(User user)
        {
            return _mapper.Map<User, UserResponse>(user);
        }

        public IEnumerable<UserDetails> UserToUserDetails(IEnumerable<User> users)
        {
            return _mapper.Map<IEnumerable<UserDetails>>(users);
        }

        public IEnumerable<UserResponse> UserToUserResponse(IEnumerable<User> users)
        {
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }
    }
}
