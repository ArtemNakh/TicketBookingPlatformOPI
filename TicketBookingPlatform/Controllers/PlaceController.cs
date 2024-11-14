using Microsoft.AspNetCore.Mvc;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        //  Place
        public async Task<IActionResult> Index()
        {
            var places = await _placeService.GetPlaces();
            return View(places);
        }

        public async Task<IActionResult> Details(int id)
        {
            var place = await _placeService.GetPlaceById(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Place place)
        {
            if (ModelState.IsValid)
            {
                await _placeService.AddingPlace(place);
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var place = await _placeService.GetPlaceById(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Place place)
        {
            if (id != place.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _placeService.UpdatePlace(place);
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var place = await _placeService.GetPlaceById(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }
        

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _placeService.DeletePlacec(id); 
            return RedirectToAction(nameof(Index)); 
        }

    }
}

