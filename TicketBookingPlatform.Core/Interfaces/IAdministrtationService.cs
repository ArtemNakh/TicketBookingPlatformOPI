using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Interfaces
{
    public  interface IAdministrationService
    {
        public Task<Administration> Login(string username, string password);
        public Task<Administration> Registration(Administration admin);
        
        public Task<Reservation> GetReservationById(int id);
        public Task<IEnumerable<Reservation>> GetReservation();
        public Task<IEnumerable<Reservation>> GetReservationByEvent(int eventId);

        public Task<IEnumerable<Events>> GetEvents();
        public Task<Events> GetEventById(int id);

        public Task<Events> AddingEvent(Events events);
        public Task DeleteEvent(int id);

        public Task<User> GetUserById(int id);
        public Task<IEnumerable<User>> GetUsers();

        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
        public Task DeleteUser(int id);














    }
}
