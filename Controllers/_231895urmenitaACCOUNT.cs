using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using _231895urmenitaMVCCRUDOPERATION.Data;
using _231895urmenitaMVCCRUDOPERATION.Models;

namespace _231895urmenitaMVCCRUDOPERATION.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("_231895urmenitaLOGIN", new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("_231895urmenitaLOGIN", model);

            var user = _context.Users
                .FirstOrDefault(u => u.USERNAME == model.Username && u.PASSWORD == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View("_231895urmenitaLOGIN", model);
            }

            HttpContext.Session.SetString("LoggedUser", user.USERNAME);
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
