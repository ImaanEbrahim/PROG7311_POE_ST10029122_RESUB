using Microsoft.AspNetCore.Mvc;
using PROG3A_POE.Auth;
using PROG3A_POE.Models;
using System.Threading.Tasks;

namespace PROG3A_POE.Controllers
{
    public class AccountController : Controller
    {
        private readonly CustomUserStore _userStore;

        public AccountController(CustomUserStore userStore)
        {
            _userStore = userStore;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userStore.ValidateUserAsync(username, password);
            if (user != null)
            {
                //  user info in session is saved
                HttpContext.Session.SetString("Username", user.UserName);
                HttpContext.Session.SetString("Role", user.Role);

                // redirect based on role
                if (user.Role == "Farmer")
                {
                    return RedirectToAction("Dashboard", "Farmer");
                }
                else if (user.Role == "Employee")
                {
                    return RedirectToAction("Dashboard", "Employee");
                }
            }
            //if wrong info is inputted
            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
