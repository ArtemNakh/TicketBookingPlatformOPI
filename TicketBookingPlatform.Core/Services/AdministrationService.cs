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
    public class AdministrationService : IAdministrationService
    {
        private readonly IRepository _repository;

        public AdministrationService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Administration> Login(string username, string password)
        {
            var admin = await _repository.GetQuery<Administration>(a => a.Login == username && a.Password == password);
            return admin.FirstOrDefault();
        }

        public async Task<Administration> Registration(Administration admin)
        {
            return await _repository.Add(admin);
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _repository.GetById<Reservation>(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservation()
        {
            return await _repository.GetAll<Reservation>().ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationByEvent(int eventId)
        {
            return await _repository.GetQuery<Reservation>(r => r.Event.Id == eventId);
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _repository.GetAll<Events>().ToListAsync();
        }

        public async Task<Events> GetEventById(int id)
        {
            return await _repository.GetById<Events>(id);
        }

        public async Task<Events> AddingEvent(Events events)
        {
            return await _repository.Add(events);
        }

        public async Task DeleteEvent(int id)
        {
            await _repository.Delete<Events>(id);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetById<User>(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll<User>().ToListAsync();
        }

        public async Task<User> AddUser(User user)
        {
            return await _repository.Add(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _repository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
            await _repository.Delete<User>(id);
        }

       
    }
}
