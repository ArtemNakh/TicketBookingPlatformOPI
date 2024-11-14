using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Interfaces
{
    public interface IEventService
    {
        public Task<Events> AddingEvent(Events events);
        public Task DeleteEvent(int id);
        public Task UpdateEvent(Events events);
        public Task<IEnumerable<Events>> GetEvents();
        public Task<Events> GetEventById(int id);

    }
}
