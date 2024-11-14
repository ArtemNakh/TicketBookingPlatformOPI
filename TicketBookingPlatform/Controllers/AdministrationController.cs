using Microsoft.AspNetCore.Mvc;
using TicketBookingPlatform.Core.Interfaces;
using TicketBookingPlatform.Core.Models;

namespace TicketBookingPlatform.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IAdministrationService _administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            _administrationService = administrationService;
        }

        //  Administration/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //  Administration/Login
        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            var admin = await _administrationService.Login(username, password);
            if (admin != null)
            {
                HttpContext.Session.SetInt32("UserId", admin.Id);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Невірне ім'я користувача або пароль");
            return View();
        }

        //  Administration/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Administration/Register
        [HttpPost]
        public async Task<ActionResult> Register(Administration admin)
        {
            if (ModelState.IsValid)
            {
                await _administrationService.Registration(admin);
                return RedirectToAction("Login");
            }

            return View(admin);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
