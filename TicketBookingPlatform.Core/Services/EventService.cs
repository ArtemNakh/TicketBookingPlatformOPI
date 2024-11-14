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
    public class EventService : IEventService
    {
        private readonly IRepository _repository;
        private readonly IPlaceService _placeService;

        public EventService(IRepository repository, IPlaceService placeService)
        {
            _repository = repository;
            _placeService = placeService;
        }

        public async Task<Events> AddingEvent(Events events)
        {
            Place place = await _placeService.GetPlaceById(events.Venue.Id);
            Events newEvent = new Events
            {
                Title = events.Title,
                Description = events.Description,
                DateStart = events.DateStart,
                DateEnd = events.DateEnd,
                Price = events.Price,
                AgeRating = events.AgeRating,
                Venue = place
            };
            return await _repository.Add(newEvent);
        }

        public async Task DeleteEvent(int id)
        {
            await _repository.Delete<Events>(id);
        }

        public async Task UpdateEvent(Events events)
        {
            await _repository.Update(events);
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _repository.GetAll<Events>().ToListAsync();
        }

        public async Task<Events> GetEventById(int id)
        {
            return await _repository.GetById<Events>(id);
        }
    }
}
