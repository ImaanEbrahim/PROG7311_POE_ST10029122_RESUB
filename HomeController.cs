using Microsoft.AspNetCore.Mvc;
using PROG3A_POE.Models;
using System.Diagnostics;


namespace PROG3A_POE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
