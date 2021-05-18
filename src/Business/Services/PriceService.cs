using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class PriceService : IDataService<Price>
    {
        private readonly PriceRepository _prices;
        private readonly Mapper _pricesMapper;

        public PriceService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _prices = new PriceRepository(context);
            _pricesMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return _pricesMapper.Map<IEnumerable<Price>>(await _prices.GetAllAsync());
        }

        public async Task<Price> GetByIdAsync(int id)
        {
            if (!(await _prices.IsExistingAsync(id)))
                throw new Exception($"No such price with id: {id}");
            return _pricesMapper.Map<Price>(await _prices.GetAsync(id));
        }

        public async Task PostAsync(Price item)
        {
            if (_prices.Find(x => x.AirplaneId == item.AirplaneId && x.PlaceTypeId == item.PlaceTypeId).Any())
                throw new Exception("Such price is already exist");
            await _prices.CreateAsync(_pricesMapper.Map<PriceEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!(await _prices.IsExistingAsync(id)))
                throw new Exception("No such price");
            await _prices.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Price item)
        {
            if (!(await _prices.IsExistingAsync(id)))
                throw new Exception("No such price");
            await _prices.UpdateAsync(id, _pricesMapper.Map<PriceEntity>(item));
        }
    }
}
