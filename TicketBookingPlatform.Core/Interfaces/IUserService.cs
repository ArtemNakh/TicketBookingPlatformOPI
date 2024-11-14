using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Interfaces
{
    public interface IUserService
    {
        public Task<User> Login(string Login, string password);
        public Task<User> Registration(User user);

        public Task<User> GetUserById(int id);
        public Task<IEnumerable<User>> GetUsers();
        public Task<IEnumerable<User>> GetUsersByEvent(int eventId);

        public Task DeleteUser(int id);
        public Task<User> UpdateUser(User user);


    }
}
