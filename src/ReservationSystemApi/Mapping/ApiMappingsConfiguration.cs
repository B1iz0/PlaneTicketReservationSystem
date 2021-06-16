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
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceTypeModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PriceModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Mapping
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

        public readonly MapperConfiguration PriceMapperConfiguration;

        public readonly MapperConfiguration PlaceTypeMapperConfiguration;

        public readonly MapperConfiguration PlaceMapperConfiguration;

        public ApiMappingsConfiguration()
        {
            UserMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<User, UserDetails>();
                x.CreateMap<User, UserResponse>();
                x.CreateMap<UserRegistration, User>();
                x.CreateMap<Role, RoleResponse>().ForMember(r => r.Users, opt => opt.Ignore());
                x.CreateMap<Booking, BookingResponse>().ForMember(b => b.User, opt => opt.Ignore());
                x.CreateMap<Flight, FlightResponse>();
                x.CreateMap<Airplane, AirplaneResponse>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<Airport, AirportResponse>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Company, CompanyResponse>().ForMember(z => z.Country, opt => opt.Ignore());
                x.CreateMap<Place, PlaceResponse>();
                x.CreateMap<Price, PriceResponse>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(model => model.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(model => model.PlaceType.Name));
            });
            AuthMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AuthenticateRequest, Authenticate>();
                x.CreateMap<Authenticate, AuthenticateResponse>();
            });
            RoleMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Role, RoleResponse>();
                x.CreateMap<RoleRequest, Role>();
                x.CreateMap<User, UserResponse>();
            });
            AirplaneMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airplane, AirplaneResponse>();
                x.CreateMap<AirplaneRegistration, Airplane>();
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Flight, FlightResponse>().ForMember(z => z.Airplane, opt => opt.Ignore());
                x.CreateMap<Airport, AirportResponse>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Place, PlaceResponse>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name))
                    .ForMember(z => z.IsFree, opt => opt.MapFrom(c => c.Booking == null))
                    .ForMember(z => z.TicketPrice, opt => opt.MapFrom(c => c.Price.TicketPrice));
                x.CreateMap<PlaceType, PlaceTypeResponse>();
                x.CreateMap<Price, PriceResponse>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(c => c.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
            });
            AirplaneTypeMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneType, AirplaneTypeDetails>();
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<AirplaneTypeRegistration, AirplaneType>();
                x.CreateMap<Airplane, AirplaneResponse>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Country, CountryResponse>();
            });
            AirportConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airport, AirportDetails>();
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<AirportRegistration, Airport>();
                x.CreateMap<Airplane, AirplaneResponse>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Flight, FlightResponse>();
            });
            BookingMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Booking, BookingResponse>();
                x.CreateMap<BookingRegistration, Booking>();
                x.CreateMap<Flight, FlightResponse>();
                x.CreateMap<Airplane, AirplaneResponse>();
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<User, UserResponse>();
                x.CreateMap<Place, PlaceResponse>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name))
                    .ForMember(z => z.IsFree, opt => opt.MapFrom(c => c.Booking == null))
                    .ForMember(z => z.TicketPrice, opt => opt.MapFrom(c => c.Price.TicketPrice));
            });
            CityMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<City, CityDetails>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<CityRegistration, City>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Airport, AirportResponse>().ForMember(z => z.City, opt => opt.Ignore());
                x.CreateMap<Company, CompanyResponse>();
            });
            CompanyMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Company, CompanyDetails>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<CompanyRegistration, Company>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Airplane, AirplaneResponse>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<Flight, FlightResponse>().ForMember(z => z.Airplane, opt => opt.Ignore());
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<City, CityResponse>();
            });
            CountryMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Country, CountryDetails>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<CountryRegistration, Country>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Company, CompanyResponse>().ForMember(z => z.Country, opt => opt.Ignore());
            });
            FlightMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Flight, FlightDetails>();
                x.CreateMap<Flight, FlightResponse>();
                x.CreateMap<FlightRegistration, Flight>();
                x.CreateMap<Airplane, AirplaneResponse>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponse>();
                x.CreateMap<Company, CompanyResponse>();
                x.CreateMap<Country, CountryResponse>();
                x.CreateMap<Place, PlaceResponse>();
                x.CreateMap<Price, PriceResponse>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(model => model.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(model => model.PlaceType.Name));
                x.CreateMap<Airport, AirportResponse>();
                x.CreateMap<City, CityResponse>();
                x.CreateMap<Booking, BookingResponse>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<User, UserResponse>();
            });
            PriceMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Price, PriceResponse>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(c => c.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
                x.CreateMap<PriceRegistration, Price>();
            });
            PlaceTypeMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<PlaceType, PlaceTypeResponse>();
                x.CreateMap<PlaceTypeRegistration, PlaceType>();
            });
            PlaceMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Place, PlaceResponse>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name))
                    .ForMember(z => z.IsFree, opt => opt.MapFrom(c => c.Booking == null))
                    .ForMember(z => z.TicketPrice, opt => opt.MapFrom(c => c.Price.TicketPrice));
                x.CreateMap<PlaceRegistration, Place>();
            });
        }
    }
}
