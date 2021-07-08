using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _places;

        private readonly IPlaceTypeRepository _placeTypes;

        private readonly IAirplaneRepository _airplanes;

        private readonly IPriceRepository _prices;

        private readonly IMapper _placeMapper;

        public PlaceService(IPlaceRepository places, IPlaceTypeRepository placeTypes, IPriceRepository prices, IAirplaneRepository airplanes, IMapper mapper)
        {
            _places = places;
            _placeTypes = placeTypes;
            _prices = prices;
            _airplanes = airplanes;
            _placeMapper = mapper;
        }

        public async Task<Place> GetByIdAsync(Guid id)
        {
            PlaceEntity placeEntity = await _places.GetAsync(id);
            if (placeEntity == null)
            {
                throw new ElementNotFoundException($"No such place with id: {id}");
            }
            var place = _placeMapper.Map<Place>(placeEntity);
            return place;
        }

        public async Task PostAsync(PlaceListRegistration item)
        {
            AirplaneEntity airplane = await _airplanes.GetAsync(item.AirplaneId);
            int currentRow = 0;
            int currentColumn = 0;
            foreach (var place in item.Places)
            {
                for (int i = 0; i < place.PlaceAmount; i++)
                {
                    if (currentColumn == airplane.Columns)
                    {
                        currentRow++;
                        currentColumn = 0;
                    }
                    PlaceTypeEntity placeType = _placeTypes.Find(type => type.Name == place.PlaceTypeName).FirstOrDefault();
                    if (placeType == null)
                    {
                        var newPlaceType = new PlaceType
                        {
                            Name = place.PlaceTypeName,
                        };
                        var newPlaceTypeEntity = _placeMapper.Map<PlaceTypeEntity>(newPlaceType);
                        placeType = await _placeTypes.CreateAsync(newPlaceTypeEntity);
                    }
                    var price = new PriceEntity
                    {
                        AirplaneId = item.AirplaneId,
                        PlaceTypeId = placeType.Id,
                        TicketPrice = 0,
                    };
                    IQueryable<PriceEntity> existedPrice = _prices.Find(p => (p.PlaceTypeId == placeType.Id) &&
                                                                             (p.AirplaneId == item.AirplaneId));
                    if (!existedPrice.Any())
                    {
                        await _prices.CreateAsync(price);
                    }
                    var newPlace = new Place
                    {
                        AirplaneId = item.AirplaneId,
                        PlaceTypeId = placeType.Id,
                        Row = currentRow,
                        Column = currentColumn
                    };
                    var newPlaceEntity = _placeMapper.Map<PlaceEntity>(newPlace);
                    await _places.CreateAsync(newPlaceEntity);
                    currentColumn++;
                }
            }
        }
    }
}
