using Microsoft.AspNetCore.Mvc;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;
using TicketBookingPlatform.Models;

namespace TicketBookingPlatform.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IEventService _eventService;
        private readonly IUserService _userService;

        public ReservationController(IReservationService reservationService, IEventService eventService, IUserService userService)
        {
            _reservationService = reservationService;
            _eventService = eventService;
            _userService = userService;
        }

        //  Reservation
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationService.GetReservations();
            return View(reservations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _reservationService.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        public async Task<IActionResult> Create()
        {
            var events = await _eventService.GetEvents();
            ViewBag.Events = events;
            return View(new ReservationCreate());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreate reservation)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    ModelState.AddModelError("", "Користувача не знайдено в сесії.");
                    return View(reservation);
                }

                var user = await _userService.GetUserById(userId.Value);
                if (user == null)
                {
                    ModelState.AddModelError("", "Користувача не знайдено.");
                    return View(reservation);
                }

                var eventItem = await _eventService.GetEventById(reservation.EventId);
                if (eventItem == null)
                {
                    ModelState.AddModelError("", "Подію не знайдено.");
                    return View(reservation);
                }

                var newReservation = new Reservation
                {
                    User = user,
                    Event = eventItem,
                    DateReservation = reservation.DateReservation,
                };

                await _reservationService.AddReservation(newReservation);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Events = await _eventService.GetEvents();
            return View(reservation);
        }





        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationService.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reservationService.DeleteReservation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
