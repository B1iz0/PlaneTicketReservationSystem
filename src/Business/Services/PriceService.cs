using System;
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
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _prices;

        private readonly IMapper _pricesMapper;

        public PriceService(IPriceRepository prices, IMapper mapper)
        {
            _prices = prices;
            _pricesMapper = mapper;
        }

        public IEnumerable<Price> GetByAirplaneIdAsync(Guid airplaneId)
        {
            IQueryable<PriceEntity> priceEntities = _prices.Find(x => x.AirplaneId == airplaneId);
            if (!priceEntities.Any())
            {
                throw new ElementNotFoundException($"No such airplane with id: {airplaneId}");
            }
            var pricesForAirplane = _pricesMapper.Map<IEnumerable<Price>>(priceEntities);
            return pricesForAirplane;
        }

        public async Task PostAsync(Price item)
        {
            bool isPriceExisting = _prices.Find(x => x.AirplaneId == item.AirplaneId && x.PlaceTypeId == item.PlaceTypeId).Any();
            if (isPriceExisting)
            {
                throw new ElementAlreadyExistException("Such price is already exist");
            }
            var priceEntity = _pricesMapper.Map<PriceEntity>(item);
            await _prices.CreateAsync(priceEntity);
        }

        public async Task UpdateAsync(Guid id, Price item)
        {
            bool isPriceExisting = await _prices.IsExistingAsync(id);
            if (!isPriceExisting)
            {
                throw new ElementNotFoundException("No such price");
            }
            item.Id = id;
            var priceEntity = _pricesMapper.Map<PriceEntity>(item);
            await _prices.UpdateAsync(priceEntity);
        }
    }
}
