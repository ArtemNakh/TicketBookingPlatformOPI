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
    public class ReservationService : IReservationService
    {
        private readonly IRepository _repository;

        public ReservationService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            return await _repository.Add(reservation);
        }

        public async Task DeleteReservation(int id)
        {
            await _repository.Delete<Reservation>(id);
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await _repository.GetById<Reservation>(id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationByEvent(int id)
        {
            return await _repository.GetQuery<Reservation>(r => r.Event.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _repository.GetAll<Reservation>().ToListAsync();
        }
    }
}
