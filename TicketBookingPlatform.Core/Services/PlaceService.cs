using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IRepository _repository;

        public PlaceService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Place> AddingPlace(Place place)
        {
            return await _repository.Add(place);
        }

        public async Task DeletePlacec(int id)
        {
            await _repository.Delete<Place>(id);
        }

        public async Task<Place> UpdatePlace(Place place)
        {
            return await _repository.Update(place);
        }

        public async Task<Place> GetPlaceById(int id)
        {
            return await _repository.GetById<Place>(id);
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            return await _repository.GetAll<Place>().ToListAsync();
        }

        public async Task<Place> GetPlaceByEvent(int eventId)
        {
            Events events= await _repository.GetById<Events>(eventId);
            return events.Venue;
        }

        
    }
}
