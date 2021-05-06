using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mappers
{
    public class AuthenticateMapper
    {
        private readonly Mapper _mapper;

        public AuthenticateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthenticateRequest, Authenticate>();
            });
            _mapper = new Mapper(configuration);
        }

        public Authenticate AuthenticateRequestToAuthenticate(AuthenticateRequest login)
        {
            return _mapper.Map<AuthenticateRequest, Authenticate>(login);
        }

    }
}
