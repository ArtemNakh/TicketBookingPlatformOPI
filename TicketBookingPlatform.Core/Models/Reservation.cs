﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingPlatform.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Events Event { get; set; }
        public DateTime DateReservation { get; set; }













    }
}
