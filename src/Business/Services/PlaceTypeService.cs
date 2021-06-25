using System.Collections.Generic;
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
    public class PlaceTypeService : IPlaceTypeService
    {
        private readonly IPlaceTypeRepository _placeTypes;

        private readonly IMapper _placeTypeMapper;

        public PlaceTypeService(IPlaceTypeRepository placeTypes, IMapper mapper)
        {
            _placeTypes = placeTypes;
            _placeTypeMapper = mapper;
        }

        public async Task<IEnumerable<PlaceType>> GetAllAsync()
        {
            IEnumerable<PlaceTypeEntity> placeTypeEntities = await _placeTypes.GetAllAsync();
            var placeTypes = _placeTypeMapper.Map<IEnumerable<PlaceType>>(placeTypeEntities);
            return placeTypes;
        }

        public async Task PostAsync(PlaceType item)
        {
            bool isTypeExisting = _placeTypes.Find(x => x.Name == item.Name).Any();
            if (isTypeExisting)
            {
                throw new ElementAlreadyExistException("Such place type is already exist");
            }
            var placeTypeEntity = _placeTypeMapper.Map<PlaceTypeEntity>(item);
            await _placeTypes.CreateAsync(placeTypeEntity);
        }

        public async Task UpdateAsync(int id, PlaceType item)
        {
            bool isTypeExisting = await _placeTypes.IsExistingAsync(id);
            if (!isTypeExisting)
            {
                throw new ElementNotFoundException("No such place type");
            }
            item.Id = id;
            var placeTypeEntity = _placeTypeMapper.Map<PlaceTypeEntity>(item);
            await _placeTypes.UpdateAsync(placeTypeEntity);
        }
    }
}
