using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Core.Interfaces
{
    public interface IReservationService
    {
        public Task<Reservation> AddReservation(Reservation reservation);
        public Task DeleteReservation(int id);
        public Task<Reservation> GetReservation(int id);
        public Task<IEnumerable<Reservation>> GetReservationByEvent(int Id);
        public Task<IEnumerable<Reservation>> GetReservations();

    }
}
