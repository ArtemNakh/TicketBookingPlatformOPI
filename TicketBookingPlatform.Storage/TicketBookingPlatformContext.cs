using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Storage
{
    public class TicketBookingPlatformContext: DbContext
    {
        public TicketBookingPlatformContext(DbContextOptions<TicketBookingPlatformContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Administration> Administrations { get; set; }
    }
}
