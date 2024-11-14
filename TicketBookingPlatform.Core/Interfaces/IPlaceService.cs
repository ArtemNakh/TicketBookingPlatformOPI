using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Interfaces
{
    public interface IPlaceService
    {
       public Task<Place> AddingPlace(Place place);
        public Task DeletePlacec(int id);
        public Task<Place> UpdatePlace(Place place);
        public Task<Place> GetPlaceById(int id);
        public Task<IEnumerable<Place>> GetPlaces();

        public Task<Place> GetPlaceByEvent(int eventId);
    }
}
