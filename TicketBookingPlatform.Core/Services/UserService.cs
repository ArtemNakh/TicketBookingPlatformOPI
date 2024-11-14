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
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _repository.GetQuery<User>(u => u.Login == login && u.Password == password);
            return user.FirstOrDefault();
        }

        public async Task<User> Registration(User user)
        {
            return await _repository.Add(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetById<User>(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll<User>().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByEvent(int eventId)
        {
            IEnumerable<Reservation> Reservations=await _repository.GetQuery<Reservation>(u => u.Event.Id == eventId);
            List<User> users=new List<User>();
            foreach (Reservation reservation in Reservations)
            {
              users.Add(reservation.User);
            }


            return users;
        }

        public async Task DeleteUser(int id)
        {
            await _repository.Delete<User>(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _repository.Update(user);
        }

      
    }
}
