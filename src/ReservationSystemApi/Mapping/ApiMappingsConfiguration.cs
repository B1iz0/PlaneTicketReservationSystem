using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneType;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Authenticate;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.City;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Place;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceType;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Price;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Role;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.User;

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
                x.CreateMap<User, UserDetailsModel>();
                x.CreateMap<User, UserResponseModel>();
                x.CreateMap<UserRegistrationModel, User>();
                x.CreateMap<Role, RoleResponseModel>().ForMember(r => r.Users, opt => opt.Ignore());
                x.CreateMap<Booking, BookingResponseModel>().ForMember(b => b.User, opt => opt.Ignore());
                x.CreateMap<Flight, FlightResponseModel>();
                x.CreateMap<Airplane, AirplaneResponseModel>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<Airport, AirportResponseModel>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>().ForMember(z => z.Country, opt => opt.Ignore());
                x.CreateMap<Place, PlaceResponseModel>();
                x.CreateMap<Price, PriceResponseModel>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(model => model.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(model => model.PlaceType.Name));
            });
            AuthMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AuthenticateRequestModel, Authenticate>();
                x.CreateMap<Authenticate, AuthenticateResponseModel>();
            });
            RoleMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Role, RoleResponseModel>();
                x.CreateMap<RoleRequestModel, Role>();
                x.CreateMap<User, UserResponseModel>();
            });
            AirplaneMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airplane, AirplaneResponseModel>();
                x.CreateMap<AirplaneRegistrationModel, Airplane>();
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Flight, FlightResponseModel>().ForMember(z => z.Airplane, opt => opt.Ignore());
                x.CreateMap<Airport, AirportResponseModel>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Place, PlaceResponseModel>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name))
                    .ForMember(z => z.IsFree, opt => opt.MapFrom(c => c.Booking == null));
                x.CreateMap<PlaceType, PlaceTypeResponseModel>();
                x.CreateMap<Price, PriceResponseModel>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(c => c.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
            });
            AirplaneTypeMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<AirplaneType, AirplaneTypeDetailsModel>();
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<AirplaneTypeRegistrationModel, AirplaneType>();
                x.CreateMap<Airplane, AirplaneResponseModel>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
            });
            AirportConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Airport, AirportDetailsModel>();
                x.CreateMap<Airport, AirportResponseModel>();
                x.CreateMap<AirportRegistrationModel, Airport>();
                x.CreateMap<Airplane, AirplaneResponseModel>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Flight, FlightResponseModel>();
            });
            BookingMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Booking, BookingResponseModel>();
                x.CreateMap<BookingRegistrationModel, Booking>();
                x.CreateMap<Flight, FlightResponseModel>();
                x.CreateMap<Airplane, AirplaneResponseModel>();
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<Airport, AirportResponseModel>();
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<User, UserResponseModel>();
                x.CreateMap<Place, PlaceResponseModel>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
            });
            CityMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<City, CityDetailsModel>();
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<CityRegistrationModel, City>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Airport, AirportResponseModel>().ForMember(z => z.City, opt => opt.Ignore());
                x.CreateMap<Company, CompanyResponseModel>();
            });
            CompanyMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Company, CompanyDetailsModel>();
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<CompanyRegistrationModel, Company>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Airplane, AirplaneResponseModel>().ForMember(z => z.Company, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<Flight, FlightResponseModel>().ForMember(z => z.Airplane, opt => opt.Ignore());
                x.CreateMap<Airport, AirportResponseModel>();
                x.CreateMap<City, CityResponseModel>();
            });
            CountryMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Country, CountryDetailsModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<CountryRegistrationModel, Country>();
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>().ForMember(z => z.Country, opt => opt.Ignore());
            });
            FlightMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Flight, FlightDetailsModel>();
                x.CreateMap<Flight, FlightResponseModel>();
                x.CreateMap<FlightRegistrationModel, Flight>();
                x.CreateMap<Airplane, AirplaneResponseModel>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<AirplaneType, AirplaneTypeResponseModel>();
                x.CreateMap<Company, CompanyResponseModel>();
                x.CreateMap<Country, CountryResponseModel>();
                x.CreateMap<Place, PlaceResponseModel>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
                x.CreateMap<Price, PriceResponseModel>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(model => model.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(model => model.PlaceType.Name));
                x.CreateMap<Airport, AirportResponseModel>();
                x.CreateMap<City, CityResponseModel>();
                x.CreateMap<Booking, BookingResponseModel>().ForMember(z => z.Flight, opt => opt.Ignore());
                x.CreateMap<User, UserResponseModel>();
            });
            PriceMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Price, PriceResponseModel>()
                    .ForMember(z => z.AirplaneModel, opt => opt.MapFrom(c => c.Airplane.Model))
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
                x.CreateMap<PriceRegistrationModel, Price>();
            });
            PlaceTypeMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<PlaceType, PlaceTypeResponseModel>();
                x.CreateMap<PlaceTypeRegistrationModel, PlaceType>();
            });
            PlaceMapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Place, PlaceResponseModel>()
                    .ForMember(z => z.PlaceType, opt => opt.MapFrom(c => c.PlaceType.Name));
                x.CreateMap<PlaceListRegistrationModel, PlaceListRegistration>();
                x.CreateMap<PlaceRegistrationModel, PlaceRegistration>();
            });
        }
    }
}
