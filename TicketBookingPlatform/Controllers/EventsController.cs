using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Numerics;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;
using TicketBookingPlatform.Core.Services;

namespace TicketBookingPlatform.Controllers
{

    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IPlaceService _placeService;

        public EventsController(IEventService eventService, IPlaceService placeService)
        {
            _eventService = eventService;
            _placeService = placeService;
        }

        // Events
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        public async Task<IActionResult> Create()
        {
            var places = await _placeService.GetPlaces();

            ViewBag.Places = places.ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Events eventItem)
        {
            await _eventService.AddingEvent(eventItem);
            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Edit(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Events eventItem)
        {
            if (id != eventItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _eventService.UpdateEvent(eventItem);
                return RedirectToAction(nameof(Index));
            }
            return View(eventItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEvent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
