using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mappers
{
    public class ApiMappingsConfiguration
    {
        public readonly MapperConfiguration UserMapperConfiguration;
        public readonly MapperConfiguration AuthMapperConfiguration;
        public readonly MapperConfiguration RoleMapperConfiguration;
        public readonly MapperConfiguration AirplaneMapperConfiguration;
        public readonly MapperConfiguration AirplaneTypeMapperConfiguration;
        public readonly MapperConfiguration AirportConfiguration;
        public readonly MapperConfiguration BookingMapperConfiguration;
        public readonly MapperConfiguration CityMapperConfiguration;
        public readonly MapperConfiguration CompanyMapperConfiguration;
        public readonly MapperConfiguration CountryMapperConfiguration;
        public readonly MapperConfiguration FlightMapperConfiguration;

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
            AirplaneMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airplane, AirplaneDetails>();
                x.CreateMap<Airplane, AirplaneResponse>();
                x.CreateMap<AirplaneRegistration, Airplane>();
                x.CreateMap<AirplaneType, AirplaneResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Flight, FlightResponse>();
            });
            AirplaneTypeMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneType, AirplaneTypeDetails>();
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<AirplaneTypeRegistration, AirplaneType>();
                x.CreateMap<Airplane, AirplaneResponse>();
            });
            AirportConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airport, AirportDetails>();
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<AirportRegistration, Airport>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Flight, FlightResponse>();
            });
            BookingMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Booking, BookingDetails>();
                x.CreateMap<Booking, BookingResponse>();
                x.CreateMap<BookingRegistration, Booking>();
                x.CreateMap<Flight, FlightResponse>();
                x.CreateMap<User, UserResponse>();
            });
            CityMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<City, CityDetails>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<CityRegistration, City>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Airport, AirportResponse>();
            });
            CompanyMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Company, CompanyDetails>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<CompanyRegistration, Company>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Airplane, AirplaneResponse>();
                x.CreateMap<Airport, AirportResponse>();
            });
            CountryMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Country, CountryDetails>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<CountryRegistration, Country>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Company, CompanyResponse>();
            });
            FlightMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Flight, FlightDetails>();
                x.CreateMap<Flight, FlightResponse>();
                x.CreateMap<FlightRegistration, Flight>();
                x.CreateMap<Airplane, AirplaneResponse>();
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<Booking, BookingResponse>();
            });
        }
    }
}
