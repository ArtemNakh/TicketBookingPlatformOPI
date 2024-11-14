using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Models
{
    public class ReservationCreate
    {
        public int EventId { get; set; }  
        public DateTime DateReservation { get; set; }
    }
}
