using Microsoft.AspNetCore.Mvc;
using PROG3A_POE.Models;
using System.Collections.Generic;

namespace PROG3A_POE.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<ApplicationUser> _farmers = new(); // In-memory farmer list
        private static List<FarmerProduct> _products = new();  // In-memory product list

        //  to populate sample data to view
        static EmployeeController()
        {
            // Add sample farmers to view
            if (_farmers.Count == 0)
            {
                _farmers.Add(new ApplicationUser { Id = "1", UserName = "farmer1", Email = "farmer1@agri.com" });
                _farmers.Add(new ApplicationUser { Id = "2", UserName = "farmer2", Email = "farmer2@agri.com" });
                _farmers.Add(new ApplicationUser { Id = "3", UserName = "farmer3", Email = "farmer3@agri.com" });
            


            // Add sample products to view
            _products.Add(new FarmerProduct
            {
                Id = 1,
                Name = "Apples",
                Category = "Fruit",
                ProductionDate = new DateTime(2023, 10, 15),
                FarmerId = "farmer1"   //who added 
            });

            _products.Add(new FarmerProduct
            {
                Id = 2,
                Name = "Carrots",
                Category = "Vegetable",
                ProductionDate = new DateTime(2023, 11, 01),
                FarmerId = "farmer2"
            });

            _products.Add(new FarmerProduct
            {
                Id = 3,
                Name = "Wheat",
                Category = "Grain",
                ProductionDate = new DateTime(2023, 09, 20),
                FarmerId = "farmer1"
            });

            _products.Add(new FarmerProduct
            {
                Id = 4,
                Name = "Tomatoes",
                Category = "Vegetable",
                ProductionDate = new DateTime(2023, 11, 18),
                FarmerId = "farmer2"
            });
        }
    }

        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult AddFarmerProfile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFarmerProfile(ApplicationUser farmer)
        {
            if (ModelState.IsValid)
            {
                // a unique ID for the new farmer
                farmer.Id = (_farmers.Count + 1).ToString();

                // Add the new farmer to the in-memory list
                _farmers.Add(farmer);

                // to show the updated list
                return RedirectToAction("FarmerList");
            }

            //  return the same view with errors if not validated
            return View(farmer);
        }
        //to view farmers
        public IActionResult FarmerList()
        {
            return View(_farmers);
        }
        //view products
        public IActionResult ViewAllProducts()
        {
            return View(_products);
        }

        [HttpPost] //to search by category
        public IActionResult FilterProducts(string category, string dateRange)
        {
            var filteredProducts = _products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                filteredProducts = filteredProducts.Where(p => p.Category.Contains(category));
            }

            return View("ViewAllProducts", filteredProducts.ToList());
        }

    }
}
