using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class PriceService : IPriceService
    {
        private readonly PriceRepository _prices;

        private readonly AirplaneRepository _airplanes;

        private readonly Mapper _pricesMapper;

        public PriceService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _prices = new PriceRepository(context);
            _airplanes = new AirplaneRepository(context);
            _pricesMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            var prices = _pricesMapper.Map<IEnumerable<Price>>(await _prices.GetAllAsync());
            return prices;
        }

        public async Task<Price> GetByIdAsync(int id)
        {
            bool isPriceExisting = await _prices.IsExistingAsync(id);
            if (!isPriceExisting)
            {
                throw new ElementNotFoundException($"No such price with id: {id}");
            }
            var price = _pricesMapper.Map<Price>(await _prices.GetAsync(id));
            return price;
        }

        public async Task<IEnumerable<Price>> GetByAirplaneIdAsync(int airplaneId)
        {
            bool isAirplaneExisting = await _airplanes.IsExistingAsync(airplaneId);
            if (!isAirplaneExisting)
            {
                throw new ElementNotFoundException($"No such airplane with id: {airplaneId}");
            }
            var pricesForAirplane = _pricesMapper.Map<IEnumerable<Price>>(_prices.Find(x => x.AirplaneId == airplaneId));
            return pricesForAirplane;
        }

        public async Task PostAsync(Price item)
        {
            bool isPriceExisting = _prices.Find(x => x.AirplaneId == item.AirplaneId && x.PlaceTypeId == item.PlaceTypeId).Any();
            if (isPriceExisting)
            {
                throw new ElementAlreadyExistException("Such price is already exist");
            }
            await _prices.CreateAsync(_pricesMapper.Map<PriceEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isPriceExisting = await _prices.IsExistingAsync(id);
            if (!isPriceExisting)
            {
                throw new ElementNotFoundException("No such price");
            }
            await _prices.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Price item)
        {
            bool isPriceExisting = await _prices.IsExistingAsync(id);
            if (!isPriceExisting)
            {
                throw new ElementNotFoundException("No such price");
            }
            item.Id = id;
            await _prices.UpdateAsync(_pricesMapper.Map<PriceEntity>(item));
        }
    }
}
