using Microsoft.AspNetCore.Mvc;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;
using TicketBookingPlatform.Core.Services;
using TicketBookingPlatform.Models;

namespace TicketBookingPlatform.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public UserController(IUserService userService, IEventService eventService)
        {
            _userService = userService;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Registration(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserById(id); 

            if (user == null)
            {
                return NotFound();
            }

            return View(user); 
        }

        // Registration
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Registration(user);
                return RedirectToAction(nameof(Login)); 
            }
            return View(user);
        }

        // Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Login(model.Login, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("IndexEvents");
                }
                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);
        }


        public async Task<IActionResult> IndexEvents()
        {
            var events = await _eventService.GetEvents();
            return View(events);
        }
    }
}
